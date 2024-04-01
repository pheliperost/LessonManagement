using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class LessonImportedService : BaseService, ILessonImportedService
    {
        private readonly ILessonImportedRepository _lessonImportedRepository;

        public LessonImportedService(ILessonImportedRepository lessonImportedRepository,
                                    INotifyer notifyer) : base(notifyer)
        {
            _lessonImportedRepository = lessonImportedRepository;
        }

        public async Task Add(LessonImported lessonImported)
        {
            await _lessonImportedRepository.Add(lessonImported);
        }

        public async Task AddBulk(List<LessonImported> listLesson)
        {
            try
            {
               await _lessonImportedRepository.BulkInsert(listLesson);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<LessonImported>> GetAllLessonsImportedByFile(Guid id)
        {
            return await _lessonImportedRepository.GetAllLessonsImportedByFile(id);
        }

        public async Task Delete(Guid id)
        {
            await _lessonImportedRepository.Remove(id);
        }

        public async Task DeleteAllLessonsImportedByFileId(Guid id)
        {
            await _lessonImportedRepository.DeleteAllLessonsImportedByFileId(id);
        }

        public void Dispose()
        {
            _lessonImportedRepository?.Dispose();
        }

    }
}
