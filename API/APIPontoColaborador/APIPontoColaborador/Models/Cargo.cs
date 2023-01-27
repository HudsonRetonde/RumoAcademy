using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPontoColaborador.Models;

[Table("Cargos")]
public class Cargo
{
    [Key]
    public int CargoId { get; set; }
    [Required]
    [StringLength(40)]
    public string? DescricaoCargo { get; set; }
   
}
