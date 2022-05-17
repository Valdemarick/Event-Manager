using Application.Models.Organizer;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile()
        {
            CreateMap<Organizer, OrganizerDto>();

            CreateMap<OrganizerForCreationDto, Organizer>();

            CreateMap<OrganizerForUpdateDto, Organizer>();
        }
    }
}