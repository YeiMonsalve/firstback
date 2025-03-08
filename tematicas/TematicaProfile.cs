using AutoMapper;
using FIRSTBACK.Tematicas;

public class TematicaProfile : Profile
{
    public TematicaProfile()
    {
        CreateMap<Tematica, TematicaDTO>().ReverseMap();
    }
}
