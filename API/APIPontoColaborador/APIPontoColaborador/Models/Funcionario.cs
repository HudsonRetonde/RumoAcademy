using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIPontoColaborador.Models;

public class Funcionario
{

    [Key]
    public int FuncionarioId { get; set; }
    public string? NomeDoFuncionario { get; set; }
    public string? Cpf { get; set; }
    public DateTime NascimentoFuncionario { get; set; }
    public DateTime DataDeAdmissao { get; set; }
    public string? CelularFuncionario { get; set; }
    public string? EmailFuncionario { get; set; }
    public int CargoId { get; set; }
    public virtual Cargo? Cargos { get; set; }

}
