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
    }
}
