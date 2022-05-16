using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IApplicationDbContext Context = null!;

        public GenericRepository(IApplicationDbContext context) => Context = context;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        public virtual async Task<TEntity?> GetByIdAsync(int id) =>
            await Context.Set<TEntity>()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var created = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return created.Entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var isExists = await Context.Set<TEntity>().AnyAsync(e => e.Id == entity.Id);
            if (!isExists)
            {
                return;
            }

            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var existing = await Context.Set<TEntity>().FindAsync(id);
            if (existing == null)
            {
                return;
            }

            Context.Set<TEntity>().Remove(existing);
            await Context.SaveChangesAsync();
        }
    }
}