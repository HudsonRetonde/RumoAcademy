using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPontoColaborador.Models
{
    [Table("Liderancas")]
    public class Lideranca
    {
        [Key]
        public int LiderancaId { get; set; }
        [Required]
        [StringLength(45)]
        public string? DescricaoEquipe { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
