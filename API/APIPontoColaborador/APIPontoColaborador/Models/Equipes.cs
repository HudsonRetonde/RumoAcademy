using System.Security.Cryptography.Xml;

namespace APIPontoColaborador.Models;

public class Equipes
{
    public int EquipeId { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionarios funcionarios { get; set; }  
    public int LiderancaId { get; set; }
    public Liderancas liderancas { get; set; }
    
}
