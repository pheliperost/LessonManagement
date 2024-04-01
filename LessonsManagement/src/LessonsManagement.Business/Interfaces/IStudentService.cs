using LessonsManagement.Business.Models;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IStudentService : IDisposable
    {
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Guid id);
    }
}
