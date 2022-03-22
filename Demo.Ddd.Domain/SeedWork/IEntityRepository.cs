using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Ddd.Domain.SeedWork
{
    public interface IEntityRepository<TEntity, TPrimaryKey>
    where TPrimaryKey : struct
    where TEntity : Entity<TPrimaryKey>
    {
        Task AddAsync(TEntity instance);

        Task<TEntity> GetByIdAsync(TPrimaryKey id);

        Task DeleteByIdAsync(TPrimaryKey id);

        void Add(TEntity instance);

        TEntity GetById(TPrimaryKey id);

        void DeleteById(TPrimaryKey id);
    }
}