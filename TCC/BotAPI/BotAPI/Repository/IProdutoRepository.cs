using BotAPI.Models;
using BotAPI.Pagination;

namespace BotAPI.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters);
        Task<IEnumerable<Produto>> GetProdutoPorPreco();
    }
}
