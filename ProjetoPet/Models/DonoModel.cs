using System.Text.Json.Serialization;

namespace ProjetoPet.Models;

public class DonoModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public string? Email { get; set; }
    public decimal Celular { get; set; }
    [JsonIgnore]
    public ICollection<PetModel>? Pets { get; set; }

}
