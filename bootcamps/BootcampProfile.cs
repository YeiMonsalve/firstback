using AutoMapper;

namespace firstback.bootcamps
{
    public class BootcampProfile : Profile
    {
        public BootcampProfile()
        {
            CreateMap<Bootcamp, BootcampDTO>();
            CreateMap<BootcampDTO, Bootcamp>();

            CreateMap<Bootcamp, BootcampInstitucionDTO>()
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.id : 0))
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.nombre : null));
        }
    }
}