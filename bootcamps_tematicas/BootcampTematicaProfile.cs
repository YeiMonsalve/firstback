using AutoMapper;
using FIRSTBACK.BootcampsTematicas;

namespace FIRSTBACK.Mappings
{
    public class BootcampTematicaProfile : Profile
    {
        public BootcampTematicaProfile()
        {
            // Mapeo de BootcampTematicaDto a BootcampTematica (para creación/actualización)
            CreateMap<BootcampTematicaDto, BootcampTematica>();

            // Mapeo de BootcampTematica a BootcampTematicaGetDto (para respuestas)
            CreateMap<BootcampTematica, BootcampTematicaGetDto>()
                .ForMember(dest => dest.NombreBootcamp, opt => opt.MapFrom(src => src.Bootcamp != null ? src.Bootcamp.Nombre : null))
                .ForMember(dest => dest.NombreTematica, opt => opt.MapFrom(src => src.Tematica != null ? src.Tematica.Nombre : null));
        }
    }
}