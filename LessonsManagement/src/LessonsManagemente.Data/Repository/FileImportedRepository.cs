using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public class FileImportedRepository : Repository<FileImported>, IFileImportedRepository
    {
        public FileImportedRepository(DataDbContext dataDbContext) : base(dataDbContext) { }

        public async Task<FileImported> GetFileImported(Guid Id)
        {
            return await _dataDbContext.FileImported.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == Id);
        }
    }
}
