using Microsoft.EntityFrameworkCore;
using ProjetoPet.Data;
using ProjetoPet.Models;

namespace ProjetoPet.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PetModel>> BuscarPets()
    {
        return await _context.Pets.ToListAsync();
    }
    public async Task<IEnumerable<PetModel>> BuscarPetDono()
    {
        return await _context.Pets.Include(p => p.Dono).ToListAsync();
    }
    public async Task<PetModel> BuscarPetPorId(int id)
    {
        return await _context.Pets.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
    public async Task<PetModel> CriarPet(PetModel pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }
    public async Task<PetModel> Atualizar(PetModel pet)
    {
        _context.Entry(pet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pet;
    }
    public async Task<PetModel> Deletar(int id)
    {
        var pet = await BuscarPetPorId(id);
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return pet;
    }
}
