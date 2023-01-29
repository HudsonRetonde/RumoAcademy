using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
