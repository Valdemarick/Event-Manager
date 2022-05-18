using Application.Models.Event;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.OrganizerName, opt => opt.MapFrom(src => src.Organizer.Name))
                .ForMember(dest => dest.PlaceName, opt => opt.MapFrom(src => src.Place.Name));

            CreateMap<EventForCreationDto, Event>();

            CreateMap<EventForUpdateDto, Event>();
        }
    }
}