namespace ProjetoPet.Models;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

    public Usuario(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
    public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}

