using ProjetoPet.DTOs;
using ProjetoPet.Models;

namespace ProjetoPet.Services;

public interface IDonoService
{
    Task <IEnumerable<DonoDTO>> BuscarDonos();
    Task <IEnumerable<DonoDTO>> BuscarDonoPet();
    Task <DonoDTO> BuscarDonoPorId(int id);
    Task CriarDono(DonoDTO donoDto);
    Task Atualizar(DonoDTO donoDto);
    Task Deletar(int id);
    Task CriarDono(DonoCriarDTO donoCriarDto);
}
