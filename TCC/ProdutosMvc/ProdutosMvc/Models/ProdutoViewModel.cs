using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdutosMvc.Models;

public class ProdutoViewModel
{
    public int ProdutoId { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(8,2)")]
    [Range(1, 100000, ErrorMessage = "O preço deve estar entre {1} e {2}")]
    public decimal Valor { get; set; }
    [Required]
    [StringLength(200)]
    public string? Descricao { get; set; }
    [Required]
    public DateTime DataDaCaptura { get; set; }
}
