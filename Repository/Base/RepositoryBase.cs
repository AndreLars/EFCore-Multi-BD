using System.Linq.Expressions;
using System.ComponentModel;
using System;
using EFCore_Multi_BD.Context;
using EFCore_Multi_BD.Entities;
using EFCore_Multi_BD.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EFCore_Multi_BD.Repository.Base
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable
        where TEntity : EntityBase<TKey>
        where TKey : struct
    {
        protected readonly DbSet<TEntity> _db;
        protected readonly GasStationContext _context;

        public RepositoryBase(GasStationContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AlterAsync(TEntity entity)
        {
            var currentEntity = await GetByIdAsync(entity.Id).ConfigureAwait(false);
            _context.Entry(currentEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            var query = await _db.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            Expression<Func<TEntity, bool>> predicate = t => t.Id.ToString() == id.ToString();
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}