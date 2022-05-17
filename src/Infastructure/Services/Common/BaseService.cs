using AutoMapper;

namespace Infastructure.Services.Common
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;

        public BaseService(IMapper mapper) => Mapper = mapper;
    }
}