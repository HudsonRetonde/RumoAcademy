using System.ComponentModel.DataAnnotations;

namespace BotAPI.Dtos
{
    public class ProdutoDTO
    {
        
        public int ProdutoId { get; set; }
        
        public string? Valor { get; set; }
        
        public string? Descricao { get; set; }
        
        public DateTime DataDaCaptura { get; set; }
    }
}
