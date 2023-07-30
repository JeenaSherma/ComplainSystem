using AutoMapper;
using ComplaintSystem.Dtos;
using ComplaintSystem.Model;

namespace ComplaintSystem.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Municipality, MunicipalityDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CategoryDto, Category>();
            CreateMap<Complain, ComplainDto>().ReverseMap();
            CreateMap<ComplainerInfo, ComplainerInfoDto>().ReverseMap();
            CreateMap<ComplainStatus, ComplainStatusDto>().ReverseMap();
            CreateMap<QRinfo, QRinfoDto>().ReverseMap();
            CreateMap<Token, TokenDto>().ReverseMap();

            CreateMap<ComplainerInfo, ComplainerInfoDto>()
           .ForMember(dest => dest.ComplainText, opt => opt.MapFrom(src => src.Complain.ComplainText));
            CreateMap<Department, DepartmentDto>()
               .ForMember(dest => dest.MunicipalityName, opt => opt.MapFrom(src => src.Municipality.MunicipalityName));

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<QRinfo, QRinfoDto>()
                 .ForMember(dest => dest.Municipalityname , opt => opt.MapFrom(src => src.Municipality.MunicipalityName));

           

        }

    }
}
