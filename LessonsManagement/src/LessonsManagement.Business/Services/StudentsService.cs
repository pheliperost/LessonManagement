using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class StudentsService : BaseService, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsService(IStudentRepository studentRepository,
                               INotifyer notifyer) : base(notifyer)
        {
            _studentRepository = studentRepository;
        }

        public async Task Add(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return;

            await _studentRepository.Add(student);
        }
        public async Task Delete(Guid id)
        {
            if (_studentRepository.GetLessonsByStudent(id).Result.Lessons.Any())
            {
                Notify("Exclusion not allowed! There is lessons assigned to this student.");
                return;
            }

            await _studentRepository.Remove(id);
        }

        public async Task Update(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return;

            await _studentRepository.Update(student);
        }

        public void Dispose()
        {
            _studentRepository?.Dispose();
        }
    }
}
