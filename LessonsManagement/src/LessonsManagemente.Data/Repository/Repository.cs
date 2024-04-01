using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //protected para somente repositório e quem herdá-lo possa acessar o dbcontext.
        protected readonly DataDbContext _dataDbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
            DbSet = _dataDbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        //virtual é pra permitir dar override no método depois se que quiser.
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid Id)
        {
            DbSet.Remove(new TEntity { Id = Id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dataDbContext.SaveChangesAsync();
        }



        public void Dispose()
        {
            _dataDbContext?.Dispose();
        }
    }
}
