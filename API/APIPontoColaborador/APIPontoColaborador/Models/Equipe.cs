using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIPontoColaborador.Models
{
    [Table("Equipes")]
    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        [JsonIgnore]
        public Funcionario? Funcionarios { get; set; }
        
        public int Lideranca_LiderancaId { get; set; }
        [JsonIgnore]
        public Lideranca? Liderancas { get; set; }
    }
}
