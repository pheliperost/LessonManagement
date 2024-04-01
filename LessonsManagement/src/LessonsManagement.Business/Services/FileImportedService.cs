using LessonsManagement.Business.Conciliation;
using LessonsManagement.Business.FileImporter;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class FileImportedService : BaseService, IFileImportedService
    {
        private readonly IFileImportedRepository _fileImportedRepository;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILessonsService _lessonsService;
        private readonly ILessonImportedService _lessonImportedService;
        private List<Match> lstMatch;
        private List<Lesson> lstOnlyLesson;
        private List<Lesson> lstOnlyLessonImported;
        private List<Divergency> Divergencies;
        private readonly INotifyer notifyer;

        public FileImportedService(IFileImportedRepository fileImportedRepository,
                                   IEventTypeRepository eventTypeRepository,
                                   IStudentRepository studentRepository,
                                   ILessonsService lessonsService,
                                   ILessonImportedService lessonImportedService,
                                   INotifyer notifyer) : base(notifyer)
        {
            _fileImportedRepository = fileImportedRepository;
            _eventTypeRepository = eventTypeRepository;
            _studentRepository = studentRepository;
            _lessonImportedService = lessonImportedService;
            _lessonsService = lessonsService;

            lstMatch = new List<Match>();
            lstOnlyLesson = new List<Lesson>();
            lstOnlyLessonImported = new List<Lesson>();
            Divergencies = new List<Divergency>();
        }

        public async Task Add(FileImported fileImported)
        {
            if (!ExecuteValidation(new FileImportedValidation(), fileImported)) return;

            await _fileImportedRepository.Add(fileImported);

            List<EventType> ListEventType = await _eventTypeRepository.GetAll();
            List<Student> ListStudents = await _studentRepository.GetAll();


            ImporterTxtFile importerTxtFile = new ImporterTxtFile(ListEventType,
                                                                  ListStudents,
                                                                  fileImported.Id,
                                                                   notifyer
                                                                  );
            var ListToImport = importerTxtFile.ImportFile(fileImported.FilePath);
            AddBulkLessonImported(ListToImport);
        }

        private void AddBulkLessonImported(List<LessonImported> listToImport)
        {
            _lessonImportedService.AddBulk(listToImport);
        }

        public async Task Delete(Guid id)
        {
            await _lessonImportedService.DeleteAllLessonsImportedByFileId(id);
            await _fileImportedRepository.Remove(id);
        }

        public async Task<ConciliationList> Conciliation(Guid id)
        {
            try
            {
                FileImported fileImported = await _fileImportedRepository.GetById(id);

                IEnumerable<LessonImported> listLessonImported = await _lessonImportedService.GetAllLessonsImportedByFile(id);
                IEnumerable<Lesson> listLessons = await _lessonsService.GetLessonsByPeriod(fileImported.StartDate, fileImported.EndDate);

                var datesLessonImported = listLessonImported.Select(p => p.ExecutionDate);
                var datesLesson = listLessons.Select(p => p.ExecutionDate);

                var datesExecution = datesLesson.Concat(datesLessonImported).Distinct().OrderBy(p => p);

                foreach (var item in datesExecution)
                {
                    var lessonByDay = listLessons.Where(p => p.ExecutionDate == item);
                    var lessonImportedByDay = listLessonImported.Where(p => p.ExecutionDate == item);

                    lessonByDay = lessonByDay.OrderBy(p => p.ExecutionDate);
                    lessonImportedByDay = lessonImportedByDay.OrderBy(p => p.ExecutionDate);

                    ConciliateLessons(lessonByDay, lessonImportedByDay);
                }

                ConciliationList conciliation = new ConciliationList();
                conciliation.Match = lstMatch;
                conciliation.Divergencies = Divergencies;


                return conciliation;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        private void ConciliateLessons(IEnumerable<Lesson> lstLesson, IEnumerable<LessonImported> lstLessonImported)
        {
            foreach (var lesson in lstLesson)
            {
                foreach (var lessonImported in lstLessonImported)
                {
                    if (CheckMatch(lesson, lessonImported))
                    {

                        lstMatch.Add(ReturnMatchInstance(lesson, lessonImported));
                    }

                    SetDivengencies(lesson, lessonImported);
                }
            }
        }

        private Match ReturnMatchInstance(Lesson lesson, LessonImported lessonImported)
        {
            Match match = new Match();

            match.LessonId = lesson.Id;
            match.LessonImportedId = lessonImported.Id;
            match.StudenName = lesson.Student != null ? lesson.Student.StudentName : " - ";
            match.StudenNameImported = lessonImported.Student != null ? lessonImported.Student.StudentName : " - ";
            match.EventType = lesson.EventType.EventTypeName;
            match.EventTypeImported = lessonImported.EventType != null ? lessonImported.EventType.EventTypeName : " - ";
            match.ExecutionDate = lesson.ExecutionDate;
            match.ExecutionDateImported = lessonImported.ExecutionDate;
            match.Price = lesson.EventType.Price;
            match.PriceImported = lessonImported.Price;

            return match;
        }

        public bool CheckMatch(Lesson lesson, LessonImported lessonImported)
        {
            if (lesson.StudentId == lessonImported.StudentId
                && lesson.ExecutionDate == lessonImported.ExecutionDate
                && lesson.EventTypeId == lessonImported.EventTypeId
                && lesson.EventType.Price == lessonImported.Price)
            {
                return true;
            }

            return false;
        }

        public void SetDivengencies(Lesson lesson, LessonImported lessonImported)
        {
            if (lesson.StudentId != lessonImported.StudentId)
                Divergencies.Add(ReturnDivercencyInstace("Student Id",lesson,lessonImported, lesson.StudentId.ToString(), lessonImported.StudentId.ToString()));

            if(lesson.ExecutionDate != lessonImported.ExecutionDate)
                Divergencies.Add(ReturnDivercencyInstace("Execution Date", lesson, lessonImported, lesson.ExecutionDate.ToString(), lessonImported.ExecutionDate.ToString()));

            if (lesson.EventTypeId != lessonImported.EventTypeId)
                Divergencies.Add(ReturnDivercencyInstace("Event Type ", lesson, lessonImported, lesson.EventTypeId.ToString(), lessonImported.EventTypeId.ToString()));

            if (lesson.EventType.Price != lessonImported.Price)
                Divergencies.Add(ReturnDivercencyInstace("Price ", lesson, lessonImported, lesson.EventType.Price.ToString(), lessonImported.Price.ToString()));

        }

        public Divergency ReturnDivercencyInstace(
                string _type,
                Lesson lesson, 
                LessonImported lessonImported, 
                string lessonValue, 
                string lessonImportedValue )
        {
            Divergency divergency = new Divergency();

            divergency.Message = _type + " different for lesson id " +" (lesson: " + lesson.StudentId.ToString() + " imported: " + lessonImported.StudentId.ToString();

            divergency.TypeError = _type;
            divergency.LessonId = lesson.Id.ToString();
            divergency.LessonImportedId = lessonImported.Id.ToString();
            divergency.LessonValue = lessonValue;
            divergency.LessonImportedValue = lessonImportedValue;

            return divergency;
        }


        public void Dispose()
        {
            _fileImportedRepository?.Dispose();
            _studentRepository?.Dispose();
            _eventTypeRepository?.Dispose();
            _lessonsService?.Dispose();
            _lessonImportedService?.Dispose();

        }

    }
}
