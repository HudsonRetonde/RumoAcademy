using BotAPI.Models;
using BotAPI.Pagination;

namespace BotAPI.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters);
        IEnumerable<Produto> GetProdutoPorPreco();
    }
}
