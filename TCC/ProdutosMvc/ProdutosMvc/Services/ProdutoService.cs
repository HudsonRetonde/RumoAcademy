using ProdutosMvc.Models;
using System.Net.Http;
using System.Text.Json;

namespace ProdutosMvc.Services
{
    public class ProdutoService : IProdutoService
    {
        private const string apiEndpoint = "/api/Produtos/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private ProdutoViewModel produtoVM;
        private IEnumerable<ProdutoViewModel> produtoVMs;

        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
            _clientFactory = clientFactory;
        }

        public async Task<bool> AtualizaProduto(int id, ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoViewModel> CriaProduto(ProdutoViewModel produtoVM)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletaProduto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoViewModel> GetProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
