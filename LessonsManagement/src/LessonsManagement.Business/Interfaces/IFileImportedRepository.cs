using LessonsManagement.Business.Models;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IFileImportedRepository : IRepository<FileImported>
    {
        Task<FileImported> GetFileImported(Guid Id);
    }
}
