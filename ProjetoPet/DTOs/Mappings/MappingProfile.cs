using AutoMapper;
using ProjetoPet.Models;

namespace ProjetoPet.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DonoModel, DonoDTO>().ReverseMap();
        CreateMap<DonoModel, DonoCriarDTO>().ReverseMap();
        CreateMap<PetModel, PetDTO>().ReverseMap();
    }
}
