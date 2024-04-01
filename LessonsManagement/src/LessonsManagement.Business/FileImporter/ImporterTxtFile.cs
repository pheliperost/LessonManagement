using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Services;
using LessonsManagement.Business.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Business.FileImporter
{
    public class ImporterTxtFile : BaseService
    {
        private DateTime _currentDateLesson = DateTime.MinValue;

        private List<string> ListDay = new List<string>();
        private List<EventType> ListEventType = new List<EventType>(); 
        private List<Student> ListStudents = new List<Student>(); 
        private List<LessonImported> ListToImport = new List<LessonImported>(); 
        private Guid _idFileImported;

        public ImporterTxtFile(List<EventType> lstEventType,
                               List<Student> lstStudents,
                               Guid idFileImported,
                               INotifyer notifyer) : base(notifyer)
        {
            ListEventType = lstEventType;
            ListStudents = lstStudents;
            _idFileImported = idFileImported;
        }

        public List<LessonImported> ImportFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    CultureInfo culture = new CultureInfo("pt-BR");

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        GroupLinesByDay(line);
                    }
                }

                return ListToImport;
            }
            else
            {
                throw new InvalidOperationException("File not found: " + filePath);
                
            }
        }

        private void GroupLinesByDay(string line)
        {
            try
            {
                if (Operations.VerifyIfIntValue(line.Split(" ")[0]))
                {
                    if (ListDay.Count > 0) ProcessDateLesson(ListDay);
                    ListDay.Clear();
                }

                if (line.Split(" ")[0].ToLower() == "total")
                {
                    ProcessDateLesson(ListDay);
                }

                if (!line.Contains("negado"))
                    ListDay.Add(line);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void ProcessDateLesson(List<string> listDay)
        {
            try
            {
                _currentDateLesson = DateOperations.ConvertDateStringToDateTime(listDay[0]);
                listDay.RemoveAt(0);

                ProcessLessonsByDay(listDay);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        private void ProcessLessonsByDay(List<string> listDay)
        {
            try
            {
                foreach (var item in listDay)
                {
                    ConvertLineToEntityList(item);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void ConvertLineToEntityList(string line)
        {
            try
            {
                LessonImported lessonImported = new LessonImported();
                lessonImported.ExecutionDate = _currentDateLesson;

                List<string> ListLine = CleanLine(line);

                var eventOrStudent = ListLine.First();
                ListLine.RemoveAt(0);

                var hour = ListLine.First();

                if (Operations.VerifyIfValidTimeFormat(hour))
                {
                    ListLine.RemoveAt(0);
                }
                else
                {
                    ListLine.RemoveAt(0);
                    hour = ListLine.First();
                    ListLine.RemoveAt(0);
                }

                lessonImported.ExecutionDate = _currentDateLesson.Add(TimeSpan.Parse(hour));
                lessonImported.FileImportedId = _idFileImported;

                var price = ListLine.Last();
                ListLine.RemoveAt(ListLine.Count() - 1);

                lessonImported.Price = Convert.ToDecimal(price.Remove(0, 2));

                if (eventOrStudent.ToLower() == "aula" 
                    || eventOrStudent.ToLower() == "reposição")
                {
                    var studentname = ListLine.Aggregate((i, j) => i + " " + j).ToString();

                    lessonImported.EventTypeId = ListEventType.Where(p => p.EventTypeName.ToLower() == "lesson").FirstOrDefault().Id;
                    lessonImported.StudentId = ListStudents.Where(p => p.StudentName.ToLower() == studentname.ToLower()).FirstOrDefault().Id;
                }

                if (eventOrStudent.ToLower() == "ensaio")
                {
                    lessonImported.EventTypeId = ListEventType.Where(p => p.EventTypeName.ToLower() == "rehearsal").FirstOrDefault().Id;
                }

                ListToImport.Add(lessonImported);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<string> CleanLine(string item)
        {
            try
            {
                var itemSplit = item.Split(new char[] { ' ', '\t', ')' });

                var itemList = itemSplit.ToList();

                itemList.RemoveAll(p => p.ToLower() == "de");
                itemList.RemoveAll(p => p.ToLower() == "às");
                itemList.RemoveAll(p => p.ToLower() == "negado");
                itemList.RemoveAll(p => p.ToLower() == "registrado");
                itemList.RemoveAll(p => p.ToLower() == " ");
                itemList.RemoveAll(p => p.ToLower() == "");
                itemList.RemoveAll(p => p.ToLower() == "em");
                itemList.RemoveAll(p => p.ToLower() == "com");
                itemList.RemoveAll(p => p.ToLower() == "guitarra");
                itemList.RemoveAll(p => p.ToLower() == "baixo");
                itemList.RemoveAll(p => p.ToLower().Contains("("));

                return itemList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


    }
}
