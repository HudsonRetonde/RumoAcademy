using BotAPI.Context;
using BotAPI.Models;
using BotAPI.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BotAPI.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public async Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters) 
        {            
            return await PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.ProdutoId),
                produtosParameters.PageNumer, produtosParameters.PageSize);
        }

        public async Task<IEnumerable<Produto>> GetProdutoPorPreco()
        {
            return await Get().OrderBy(c => c.Valor).ToListAsync();
        }
    }
}
