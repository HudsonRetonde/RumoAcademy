using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIPontoColaborador.Models
{
    [Table("Pontos")]
    public class Ponto
    {
        [Key] 
        public int PontoId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataHorarioPonto { get; set; }
        public string? Justificativa { get; set; }
        
        public int Funcionario_FuncionarioId { get; set; }
        [JsonIgnore]
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
