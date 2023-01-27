using System.ComponentModel.DataAnnotations;

namespace APIPontoColaborador.Models
{
    public class Lideranca
    {
        [Key]
        public int LiderancaId { get; set; }
        public string? DescricaoEquipe { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
