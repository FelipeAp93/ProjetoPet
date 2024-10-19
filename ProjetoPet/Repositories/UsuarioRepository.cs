using Microsoft.EntityFrameworkCore;
using ProjetoPet.Data;
using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> BuscarTodos()
    {
        return await _context.Usuarios.ToListAsync();
    }
    public async Task<Usuario> BuscarPorId(int id)
    {
        return await _context.Usuarios.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Usuario> Incluir(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
    public async Task<Usuario> Atualizar(Usuario usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return usuario;
    }
    public async Task<Usuario> Deletar(int id)
    {
        var usuario = await BuscarPorId(id);
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
}
