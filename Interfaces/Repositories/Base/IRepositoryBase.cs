using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore_Multi_BD.Entities;

namespace EFCore_Multi_BD.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TKey> : IDisposable
        where TEntity : EntityBase<TKey>
        where TKey : struct
    {
        Task InsertAsync(TEntity entity);
        Task<TEntity> AlterAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(TKey id);
    }
}