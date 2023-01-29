using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PontosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("FuncionariosPontos")]
        public ActionResult<IEnumerable<Ponto>> GetPontosFuncionarios()
        {
            return _context.Pontos.Include(p => p.Funcionarios).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ponto>> Get() 
        {
            var pontos = _context.Pontos.ToList();
            if (pontos is null)
            {
                return NotFound("Ponto não encontrado.");
            }
            return pontos;
        }

        [HttpGet("{id:int}", Name= "ObterPonto")]
        public ActionResult<Ponto> Get(int id) 
        {
            var ponto = _context.Pontos.FirstOrDefault(p => p.PontoId== id);
            if (ponto is null) 
            {
                return NotFound("Este id não existe, por favor digite um id válido.");
            }
            return ponto;
        }

        [HttpPost]
        public ActionResult Post(Ponto ponto)
        {
            if (ponto is null)            
                return BadRequest();
            
            _context.Pontos.Add(ponto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPonto", 
                new { id = ponto.PontoId }, ponto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Ponto ponto)
        {
            if (id != ponto.PontoId)
            {
                return BadRequest("Por gentileza, digite um Id existente...");
            }

            _context.Entry(ponto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(ponto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var ponto = _context.Pontos.FirstOrDefault(p => p.PontoId== id);

            if (ponto is null)
            {
                return NotFound("Ponto não localizado, por gentileza, digite um Id válido.");
            }

            _context.Pontos.Remove(ponto);
            _context.SaveChanges();

            return Ok(ponto);   
        }
    }
}
