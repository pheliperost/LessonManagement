using LessonsManagement.Business.Models;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudent(Guid Id);
        Task<Student> GetLessonsByStudent(Guid Id);
    }
}
