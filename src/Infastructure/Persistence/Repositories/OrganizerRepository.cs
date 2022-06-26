using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Infastructure.Persistence.Repositories
{
    public class OrganizerRepository : GenericRepository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(IApplicationDbContext context) : base(context) { }
    }
}