using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<Organizer> Organizers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
