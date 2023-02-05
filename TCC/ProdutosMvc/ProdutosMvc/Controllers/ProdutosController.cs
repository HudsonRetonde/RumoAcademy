using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProdutosMvc.Models;
using ProdutosMvc.Services;

namespace ProdutosMvc.Controllers
{
	public class ProdutosController : Controller
	{
		private readonly IProdutoService _produtoService;
		private string token = string.Empty;

		public ProdutosController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}		

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
		{
			//extrai o token do cookie
			var result = await _produtoService.GetProdutos(ObtemTokenJwt());

			if (result is null)
				return View("Error");

			return View(result);	
		}
		

		private string ObtemTokenJwt()
		{
			if (HttpContext.Request.Cookies.ContainsKey("X-Access-Token"))
				token = HttpContext.Request.Cookies["X-Access-Token"].ToString();

			return token;
		}
	}

}
