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
            CreateMap<Department, DepartmentDto>()
             //ForMember(dest => dest.MunicipalityName, opt => opt.MapFrom(src => src.Municipality.MunicipalityName))
            .ReverseMap();
            CreateMap<Category, CategoryDto>()
                //.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))

                .ReverseMap();
            //CreateMap<Complain, ComplainDto>()
            //    .ForMember(dest => dest.TokenValue, opt => opt.MapFrom(src => src.Token.TokenValue))
            //    .ReverseMap();
            CreateMap<ComplainerInfo, ComplainerInfoDto>().ReverseMap();
            CreateMap<ComplainStatus, ComplainStatusDto>().ReverseMap();
            CreateMap<QRinfo, QRinfoDto>()
                //.ForMember(dest => dest.Municipalityname, opt => opt.MapFrom(src => src.Municipality.MunicipalityName))
                .ReverseMap();
            CreateMap<Token, TokenDto>().ReverseMap();
            CreateMap<Complain, ComplainAndComplainInfoDto>()
               //.ForMember(dest => dest.TokenValue, opt => opt.MapFrom(src => src.Token.TokenValue))
               .ReverseMap();
            CreateMap<ComplainerInfo, ComplainAndComplainInfoDto>().ReverseMap();
            CreateMap<Municipality, InitializeDto>().ReverseMap();
            CreateMap<Ward, InitializeDto>().ReverseMap();
            CreateMap<Complain, ComplainAndComplainInfoDto>().ReverseMap();
            CreateMap<Complain, ComplainDetailsDto>()
                 //ForMember(dest => dest.complainerInfo , opt => opt.MapFrom(src => src.co ))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.ComplainText, opt => opt.MapFrom(src => src.ComplainText))
            //.ForMember(dest => dest.complainStatus , opt => opt.MapFrom(src => src.ComplainStatus))
            //.ForMember(dest => dest.complainerInfo, opt => opt.MapFrom(src => src.ComplainerInfo))
                .ReverseMap();


        }
    }
}
