using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public interface IDonoRepository
{
    Task<IEnumerable<DonoModel>> BuscarDonos();
    Task<IEnumerable<DonoModel>> BuscarDonoPet();
    Task<DonoModel> BuscarDonoPorId(int id );
    Task<DonoModel> CriarDono (DonoModel dono);
    Task<DonoModel> Atualizar (DonoModel dono);
    Task<DonoModel> Deletar (int id);




}
