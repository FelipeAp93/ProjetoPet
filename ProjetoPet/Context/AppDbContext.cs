using Microsoft.EntityFrameworkCore;
using ProjetoPet.Models;
using System.Reflection.Emit;

namespace ProjetoPet.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
    {
    }

    public DbSet<DonoModel> Donos { get; set; }
    public DbSet<PetModel> Pets { get; set; }

    //Fluente API

    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Dono 
        mb.Entity<DonoModel>().HasKey(c => c.Id);
        mb.Entity<DonoModel>().Property(c => c.Nome).HasMaxLength(25).IsRequired();
        mb.Entity<DonoModel>().Property(c => c.Sobrenome).HasMaxLength(30).IsRequired();
        mb.Entity<DonoModel>().Property(c => c.Email).HasMaxLength(50).IsRequired();
        mb.Entity<DonoModel>().Property(c => c.Celular).HasColumnType("decimal(12, 0)");
      


        //Pet

        mb.Entity<PetModel>().HasKey(c => c.Id);
        mb.Entity<PetModel>().Property(c => c.Nome).HasMaxLength(30).IsRequired();
        mb.Entity<PetModel>().Property(c => c.Especie).HasMaxLength(25).IsRequired();
        mb.Entity<PetModel>().Property(c => c.Idade).HasPrecision(2).IsRequired();
        mb.Entity<PetModel>().Property(c => c.Sexo).HasMaxLength(15).IsRequired();
        mb.Entity<PetModel>().Property(c => c.Foto).HasMaxLength(255).IsRequired();

        mb.Entity<DonoModel>()
            .HasMany(g => g.Pets)
            .WithOne(c => c.Dono)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
