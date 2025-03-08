using AutoMapper;

namespace FIRSTBACK.Instituciones
{
    public class InstitucionProfile : Profile
    {
        public InstitucionProfile()
        {
            // De DTO a Entidad
            CreateMap<InstitucionDTO, Institucion>();
            // De Entidad a DTO
            CreateMap<Institucion, InstitucionDTO>();
        }
    }
}