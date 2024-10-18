using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> BuscarTodos();
    Task<Usuario> BuscarPorId(int id);
    Task<Usuario> Incluir(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario);
    Task<Usuario> Deletar(int id);
    
    
   
  
}
