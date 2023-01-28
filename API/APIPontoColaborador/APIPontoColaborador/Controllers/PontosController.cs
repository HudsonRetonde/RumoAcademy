using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
