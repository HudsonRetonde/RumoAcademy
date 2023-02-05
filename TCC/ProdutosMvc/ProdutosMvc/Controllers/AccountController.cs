using Microsoft.AspNetCore.Mvc;
using ProdutosMvc.Models;
using ProdutosMvc.Services;

namespace ProdutosMvc.Controllers;

public class AccountController : Controller
{
	private readonly IAutenticacao _autenticacaoService;

	public AccountController(IAutenticacao autenticacaoService)
	{
		_autenticacaoService = autenticacaoService;
	}

	[HttpGet]
	public ActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<ActionResult> Login(UsuarioViewModel model)
	{
		//verifica se o modelo é válido
		if (!ModelState.IsValid)
		{
			ModelState.AddModelError(string.Empty, "Login Invélido...");
			return View(model);
		}
		//verifica as credenciais do usuáro e retorna um valor
		var result = await _autenticacaoService.AutenticaUsuario(model);

		if (result is null)
		{
			ModelState.AddModelError(string.Empty, "Login Inválido...");
			return View(model);
		}

		Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
		{
			Secure = true,
			HttpOnly = true,
			SameSite = SameSiteMode.Strict
		});
		return Redirect("/");
	}
}
