using Microsoft.AspNetCore.Mvc;
using ProdutosMvc.Models;
using ProdutosMvc.Services;

namespace ProdutosMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
        {
            var result = await _produtoService.GetProdutos();

            if(result is null)
                return View("Error");

            return View(result);
        }
    }
}
