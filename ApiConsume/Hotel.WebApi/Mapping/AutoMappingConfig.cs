using AutoMapper;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntityLayer.Concrete;

namespace Hotel.WebApi.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig() 
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();
        }
    }
}
