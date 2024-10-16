using ProjetoPet.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPet.DTOs;

public class PetDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2)]
    [MaxLength(20)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O espécie é obrigatório.")]
    [MaxLength(20)]
    public string? Especie { get; set; }

    [Required(ErrorMessage = "A idade é obrigatória.")]
    public int Idade { get; set; }

    public string? Sexo { get; set; }
    public string? Foto { get; set; }

    [Required(ErrorMessage = "O ID do dono é obrigatório.")]
    public int DonoId { get; set; }  // Propriedade para associar o dono
    
    public DonoModel? Dono { get; set; } 
}
