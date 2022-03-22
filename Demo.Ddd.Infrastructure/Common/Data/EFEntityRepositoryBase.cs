using Demo.Ddd.Domain.SeedWork;
using Demo.Ddd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Ddd.Infrastructure.Common.Data
{
    public class EFEntityRepositoryBase<TEntity, TPrimaryKey> : IEntityRepository<TEntity, TPrimaryKey>
        where TPrimaryKey : struct
        where TEntity : Entity<TPrimaryKey>
    {
        protected readonly DbSet<TEntity> _entities;

        public EFEntityRepositoryBase(BasketContext dbContext)
        {
            _entities = dbContext.Set<TEntity>();
        }

        public void Add(TEntity instance)
        {
            _entities.Add(instance);
        }

        public async Task AddAsync(TEntity instance)
        {
            await _entities.AddAsync(instance);
        }

        public void DeleteById(TPrimaryKey id)
        {
            var entity = GetById(id);
            _entities.Remove(entity);
        }

        public async Task DeleteByIdAsync(TPrimaryKey id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
        }

        public TEntity GetById(TPrimaryKey id)
        {
            return _entities.AsTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await _entities.AsTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}