using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DataDbContext dataDbContext) : base(dataDbContext) { }

        public async Task<Student> GetLessonsByStudent(Guid Id)
        {
            return await _dataDbContext.Student.AsNoTracking().Include(f => f.Lessons)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Student> GetStudent(Guid Id)
        {
            return await GetById(Id);
        }
    }
}
