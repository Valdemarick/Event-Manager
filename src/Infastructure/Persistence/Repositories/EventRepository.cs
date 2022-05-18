using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Persistence.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(IApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<Event>> GetAllAsync() =>
            await Context.Set<Event>()
            .Include(e => e.Organizer)
            .Include(e => e.Place)
            .AsNoTracking()
            .ToListAsync();

        public override async Task<Event?> GetByIdAsync(int id) =>
            await Context.Set<Event>()
            .Include(e => e.Organizer)
            .Include(e => e.Place)
            .FirstOrDefaultAsync();
    }
}