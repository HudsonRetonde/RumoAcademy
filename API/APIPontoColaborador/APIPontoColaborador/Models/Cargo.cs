using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIPontoColaborador.Models;

public class Cargo
{
    [Key]
    public int CargoId { get; set; }
    public string? DescricaoCargo { get; set; }
   
}
