using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIPontoColaborador.Models;
[Table("Funcionarios")]
public class Funcionario
{

    [Key]
    public int FuncionarioId { get; set; }
    [Required]
    [StringLength(45, ErrorMessage ="O nome dever ter no mínimo 05 caracter e no máximo 45.", MinimumLength =5)]
    public string? NomeDoFuncionario { get; set; }
    [Required]
    [StringLength(14)]
    public string? Cpf { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime NascimentoFuncionario { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DataDeAdmissao { get; set; }
    [Phone]
    public string? CelularFuncionario { get; set; }
    [Required(ErrorMessage ="Prezado(a) informe o seu e-mail")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Por gentileza, informe um e-mail válido.")]
    public string? EmailFuncionario { get; set; }
    
    public int CargoId { get; set; }
    [JsonIgnore]
    public virtual Cargo? Cargos { get; set; }

}
