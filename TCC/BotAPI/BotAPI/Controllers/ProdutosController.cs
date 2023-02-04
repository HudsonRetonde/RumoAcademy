using AutoMapper;
using BotAPI.Context;
using BotAPI.Dtos;
using BotAPI.Models;
using BotAPI.Pagination;
using BotAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ProdutosController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosPrecos()
        {
            var produtos = _uof.ProdutoRepository.GetProdutoPorPreco().ToList();
            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

            return produtosDto;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<ProdutoDTO>> Get([FromQuery] ProdutosParameters produtosParameters)
        {
            try
            {
                var produtos = _uof.ProdutoRepository.GetProdutos(produtosParameters);

                var metadata = new
                {
                    produtos.TotalCount,
                    produtos.PageSize,
                    produtos.CurrentPage,
                    produtos.TotalPages,
                    produtos.HasNext,
                    produtos.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);

                return produtosDto;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name= "ObterProduto")]
        public ActionResult<ProdutoDTO> Get(int id) 
        {
            try
            {
                var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

                if (produto is null)
                    return NotFound("Id não encontrado, por gentileza, verifique se o número está correto...");

                var produtoDto = _mapper.Map<ProdutoDTO>(produto);

                return produtoDto;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]ProdutoDTO produtoDto)
        {
            if (produtoDto is null)
                return BadRequest("Houve algum erro, por favor verifique se todos os itens foram preenchidos da forma correta..."); 

            var produto = _mapper.Map<Produto>(produtoDto);

            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produtoDTO);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, [FromBody] ProdutoDTO produtoDto) 
        {
            if (id != produtoDto.ProdutoId)
                return BadRequest($"Produto com o id {id} não encontrado. Verifique se está correto...");

            var produto = _mapper.Map<Produto>(produtoDto);

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return Ok();

        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<ProdutoDTO> Delete(int id) 
        {
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound($"Produto com o id {id} não encontrado. Verifique se está correto...");

            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();

            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return produtoDto;
        }

    }
}
