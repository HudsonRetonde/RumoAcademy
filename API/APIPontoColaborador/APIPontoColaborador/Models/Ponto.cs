using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPontoColaborador.Models
{
    [Table("Pontos")]
    public class Ponto
    {
        [Key] 
        public int PontoId { get; set; }
        [Required]
        public DateTime DataHorarioPonto { get; set; }
        public string? Justificativa { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
