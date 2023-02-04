using BotAPI.Context;
using BotAPI.Models;
using BotAPI.Pagination;

namespace BotAPI.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters) 
        {
            //return Get()
            //    .OrderBy(on => on.Descricao)
            //    .Skip((produtosParameters.PageNumer -1) * produtosParameters.PageSize)
            //    .Take(produtosParameters.PageSize)
            //    .ToList();

            return PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.ProdutoId),
                produtosParameters.PageNumer, produtosParameters.PageSize);
        }

        public IEnumerable<Produto> GetProdutoPorPreco()
        {
            return Get().OrderBy(c => c.Valor).ToList();
        }
    }
}
