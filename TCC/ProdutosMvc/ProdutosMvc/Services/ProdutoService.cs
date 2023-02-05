using ProdutosMvc.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ProdutosMvc.Services;

public class ProdutoService : IProdutoService
{
    private const string apiEndpoint = "/api/Produtos/";

    private readonly JsonSerializerOptions _options;
    private readonly IHttpClientFactory _clientFactory;

    private ProdutoViewModel produtoVM;
    private IEnumerable<ProdutoViewModel> produtosVM;

    public ProdutoService(IHttpClientFactory clientFactory)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        _clientFactory = clientFactory;
    }
    public async Task<IEnumerable<ProdutoViewModel>> GetProdutos()
    {
        var client = _clientFactory.CreateClient("ProdutosApi");

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                produtosVM = await JsonSerializer
                            .DeserializeAsync<IEnumerable<ProdutoViewModel>>
                            (apiResponse, _options);                                  
            }
            else
            {
                return null;
            }
            return produtosVM;
        }
    }

    public async Task<ProdutoViewModel> GetProdutoPorId(int id)
    {
        var client = _clientFactory.CreateClient("ProdutosApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                produtoVM = await JsonSerializer                    
                            .DeserializeAsync<ProdutoViewModel>
                            (apiResponse, _options);
            }
            else
            {
                return null;
            }
            return produtoVM;
        }
    }
    public async Task<ProdutoViewModel> CriaProduto(ProdutoViewModel produtoVM)
    {
        var client = _clientFactory.CreateClient("ProdutosApi");

        var categoria = JsonSerializer.Serialize(produtoVM);
        StringContent content = new StringContent(categoria, Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                produtoVM = await JsonSerializer
                            .DeserializeAsync<ProdutoViewModel>
                            (apiResponse, _options);
            }
            else
            {
                return null;
            }
            return produtoVM;
        }
    }          

    public async Task<bool> AtualizaProduto(int id, ProdutoViewModel produtoVM)
    {
        var client = _clientFactory.CreateClient("ProdutosApi");

        using (var response = await client.PutAsJsonAsync(apiEndpoint + id, produtoVM))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public async Task<bool> DeletaProduto(int id)
    {
        var client = _clientFactory.CreateClient("ProdutosApi");

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
