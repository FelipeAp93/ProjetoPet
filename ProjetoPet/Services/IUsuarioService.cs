using ProjetoPet.DTOs;
using ProjetoPet.Models;

namespace ProjetoPet.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> BuscarTodos();
    Task<UsuarioDTO> BuscarPorId(int id);
    Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDto);
    Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDto);
    Task<UsuarioDTO> Deletar(int id);
}
