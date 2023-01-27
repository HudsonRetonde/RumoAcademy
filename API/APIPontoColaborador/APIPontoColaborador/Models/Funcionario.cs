using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPontoColaborador.Models;
[Table("Funcionarios")]
public class Funcionario
{

    [Key]
    public int FuncionarioId { get; set; }
    [Required]
    [StringLength(45)]
    public string? NomeDoFuncionario { get; set; }
    [Required]
    [StringLength(14)]
    public string? Cpf { get; set; }
    [Required]    
    public DateTime NascimentoFuncionario { get; set; }
    [Required]
    public DateTime DataDeAdmissao { get; set; }
    public string? CelularFuncionario { get; set; }
    [Required]
    public string? EmailFuncionario { get; set; }
    public int CargoId { get; set; }
    public virtual Cargo? Cargos { get; set; }

}
