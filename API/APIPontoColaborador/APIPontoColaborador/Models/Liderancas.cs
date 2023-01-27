using System.Collections.ObjectModel;

namespace APIPontoColaborador.Models;

public class Liderancas
{
    public Liderancas() 
    {
        Equipes = new Collection<Equipes>();
    }
    public int LiderancaId { get; set; }
    public int FuncionarioId { get; set; }
    public Funcionarios Funcionarios { get; set; }
    public string DescricaoEquipe { get; set; }
    public ICollection<Equipes> Equipes { get; set; }
}
