using ProjetoPet.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPet.DTOs;

public class DonoDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2)]
    [MaxLength(20)]
    public string? Nome { get; set; }
    [MinLength(2)]
    [MaxLength(20)]
    public string? Sobrenome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de email inválido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O celular é obrigatório.")]
    public decimal Celular { get; set; }
   // [JsonIgnore]
    public ICollection<PetModel>? Pets { get; set; }
}
