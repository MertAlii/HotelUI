using AutoMapper;
using Hotel.EntityLayer.Concrete;
using Hotel.WebUI.Dtos.AboutDto;
using Hotel.WebUI.Dtos.LoginDto;
using Hotel.WebUI.Dtos.ServiceDtos;
using Hotel.WebUI.Dtos.StaffDtos;
using Hotel.WebUI.Dtos.SubscribeDto;


namespace Hotel.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

        }
    }
}
