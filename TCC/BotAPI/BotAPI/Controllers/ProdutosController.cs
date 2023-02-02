using BotAPI.Context;
using BotAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
                return NotFound("Produtos não encontrados...");
            return produtos;
        }

        [HttpGet("{id:int}", Name= "ObterProduto")]
        public ActionResult<Produto> Get(int id) 
        { 
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId== id);
            if (produto is null)
                return NotFound("Id não encontrado, por gentileza, verifique se o número está correto...");
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest("Produto não encontrado..."); 
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

    }
}
