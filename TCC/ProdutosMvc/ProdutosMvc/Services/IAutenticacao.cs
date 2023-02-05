using ProdutosMvc.Models;

namespace ProdutosMvc.Services;

public interface IAutenticacao
{
	Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM);
}
