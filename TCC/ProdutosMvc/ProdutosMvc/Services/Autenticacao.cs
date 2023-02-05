using ProdutosMvc.Models;
using System.Text;
using System.Text.Json;

namespace ProdutosMvc.Services;

public class Autenticacao : IAutenticacao
{
	private readonly IHttpClientFactory _clienteFactory;
	const string apiEndpointAutentica = "/api/Autorizar/login";
	private readonly JsonSerializerOptions _options;
	private TokenViewModel tokenUsuario;
	public Autenticacao(IHttpClientFactory clienteFactory)
	{
		_clienteFactory = clienteFactory;
		_options = new JsonSerializerOptions { PropertyNameCaseInsensitive= true };
	}

	public async Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usarioVM)
	{
		var client = _clienteFactory.CreateClient("AutenticaApi");
		var usuario = JsonSerializer.Serialize(usarioVM);
		StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

		using (var response = await client.PostAsync(apiEndpointAutentica, content))
		{
			if (response.IsSuccessStatusCode)
			{
				var apiResponse = await response.Content.ReadAsStreamAsync();
				tokenUsuario = await JsonSerializer
									.DeserializeAsync<TokenViewModel>
									(apiResponse, _options);
			}
			else
			{
				return null;
			}
		}
		return tokenUsuario;
	}
}
