namespace ProjetoPet.Models;

public class PetModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Especie { get; set; }
    public int Idade { get; set; }

    public string? Sexo { get; set; }
    public string? Foto { get; set; }

    public int DonoId { get; set; }
    public DonoModel? Dono { get; set; }
  
}
