using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotAPI.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(10)]
        public string? Valor { get; set; }
        [Required]
        [StringLength(200)]
        public string? Descricao { get; set;}
        [Required]
        public DateTime DataDaCaptura { get; set; }
    }
}
