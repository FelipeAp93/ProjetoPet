using Microsoft.EntityFrameworkCore;
using ProjetoPet.Data;
using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public class DonoRepository : IDonoRepository
{
    private readonly AppDbContext _context;

    public DonoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DonoModel>> BuscarDonos()
    {
        return await _context.Donos.ToListAsync();
    }
    public async Task<IEnumerable<DonoModel>> BuscarDonoPet()
    {
        return await _context.Donos.Include(c => c.Pets).ToListAsync();
    }
    public async Task<DonoModel> BuscarDonoPorId(int id)
    {
        return await _context.Donos.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<DonoModel> CriarDono(DonoModel dono)
    {
       _context.Donos.Add(dono);
        await _context.SaveChangesAsync();
        return dono;
    }
    public async Task<DonoModel> Atualizar(DonoModel dono)
    {
        _context.Entry(dono).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return dono;
    }
    public async Task<DonoModel> Deletar(int id)
    {
        var dono = await BuscarDonoPorId(id);
        _context.Donos.Remove(dono);
        await _context.SaveChangesAsync();
        return dono;
    }
}
