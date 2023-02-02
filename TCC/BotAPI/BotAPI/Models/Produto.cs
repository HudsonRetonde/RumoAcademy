namespace BotAPI.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }  
        public string? Valor { get; set; }
        public string? Descricao { get; set;}
        public DateTime DataDaCaptura { get; set; }
    }
}
