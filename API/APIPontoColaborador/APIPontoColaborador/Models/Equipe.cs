using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPontoColaborador.Models
{
    [Table("Equipes")]
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
