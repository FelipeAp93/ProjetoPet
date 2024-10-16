using ProjetoPet.DTOs;
using ProjetoPet.Models;

namespace ProjetoPet.Services;

public interface IPetService
{
    Task<IEnumerable<PetDTO>> BuscarPets();
    Task<IEnumerable<PetDTO>> BuscarPetDono();
    Task<PetDTO> BuscarPetPorId(int id);
    Task CriarPet(PetDTO petDto);
    Task Atualizar(PetDTO petDto);
    Task Deletar(int id);
}
