using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Infastructure.Persistence.Repositories
{
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(IApplicationDbContext context) : base(context) { }
    }
}