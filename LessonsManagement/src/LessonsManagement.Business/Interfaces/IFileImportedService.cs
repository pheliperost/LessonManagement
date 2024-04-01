using LessonsManagement.Business.Conciliation;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IFileImportedService : IDisposable
    {
        Task Add(FileImported lesson);
        Task Delete(Guid id);
        Task<ConciliationList> Conciliation(Guid id);
    }
}
