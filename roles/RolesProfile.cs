using AutoMapper;

namespace firstback.roles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Roles, RolesDTO>();
            CreateMap<RolesDTO, Roles>();
        }
    }
}