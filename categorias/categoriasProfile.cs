using AutoMapper;

namespace firstback.categorias
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<Categorias, CategoriasDTO>();
            CreateMap<CategoriasDTO, Categorias>();
        }
    }
}