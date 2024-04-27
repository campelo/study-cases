using AutoMapper;

namespace MapperLib
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(tgt => tgt.Text, opt => opt.MapFrom(src => src.Name))
                .ReverseMap()
                .ForMember(tgt => tgt.Name, opt => opt.MapFrom(src => src.Text));
        }
    }
}
