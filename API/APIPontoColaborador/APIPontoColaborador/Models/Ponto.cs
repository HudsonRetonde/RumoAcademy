namespace APIPontoColaborador.Models;

public class Ponto
{
    public int PontoId { get; set; }
    public DateTime DataHorarioPonto { get; set; }
    public string Justificativa { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionarios Funcionarios { get; set; }  

}
