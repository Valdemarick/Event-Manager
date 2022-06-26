using Application.Models.Place;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceDto>().ReverseMap();

            CreateMap<PlaceForCreationDto, Place>();

            CreateMap<PlaceForUpdateDto, Place>();
        }
    }
}