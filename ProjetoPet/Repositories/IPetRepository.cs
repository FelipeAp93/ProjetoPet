using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public interface IPetRepository
{

    Task<IEnumerable<PetModel>> BuscarPets();
    Task<IEnumerable<PetModel>> BuscarPetDono();
    Task<PetModel> BuscarPetPorId(int id);
    Task<PetModel> CriarPet(PetModel pet);
    Task<PetModel> Atualizar(PetModel pet);
    Task<PetModel> Deletar(int id);
}
