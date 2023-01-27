using System.ComponentModel.DataAnnotations;

namespace APIPontoColaborador.Models
{
    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        public Funcionario? Funcionarios { get; set; }
        public int Lideranca_LiderancaId { get; set; }
        public Lideranca? Liderancas { get; set; }
    }
}
