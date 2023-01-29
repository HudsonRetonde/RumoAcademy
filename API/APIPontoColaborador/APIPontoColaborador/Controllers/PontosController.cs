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
            try
            {
                return _context.Pontos.Include(p => p.Funcionarios).Where(pto => pto.PontoId <= 10).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ponto>> Get() 
        {
            try
            {
                var pontos = _context.Pontos.AsNoTracking().ToList();
                if (pontos is null)
                {
                    return NotFound("Ponto não encontrado.");
                }
                return pontos;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name= "ObterPonto")]
        public ActionResult<Ponto> Get(int id) 
        {
            try
            {
                var ponto = _context.Pontos.AsNoTracking().FirstOrDefault(p => p.PontoId== id);
                if (ponto is null) 
                {
                    return NotFound($" O Id {id} não existe, digite um Id válido...");
                }
                return ponto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Ponto ponto)
        {
            if (ponto is null)            
                return BadRequest("Ponto não encontrado");
            
            _context.Pontos.Add(ponto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPonto", 
                new { id = ponto.PontoId }, ponto);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Ponto ponto)
        {
            if (id != ponto.PontoId)
            {
                return BadRequest($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Entry(ponto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(ponto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var ponto = _context.Pontos.FirstOrDefault(p => p.PontoId== id);

            if (ponto is null)
            {
                return NotFound($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Pontos.Remove(ponto);
            _context.SaveChanges();

            return Ok(ponto);   
        }
    }
}
