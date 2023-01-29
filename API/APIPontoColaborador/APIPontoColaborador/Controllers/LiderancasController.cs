using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LiderancasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LiderancasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("FuncionariosLiderancas")]
        public ActionResult<IEnumerable<Lideranca>> GetPontosFuncionarios()
        {
            return _context.Liderancas.Include(p => p.Funcionarios).ToList();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lideranca>> Get()
        {
            var liderancas = _context.Liderancas.ToList();
            if (liderancas is null)
            {
                return NotFound("Lideranca não encontrada.");
            }
            return liderancas;
        }

        [HttpGet("{id:int}", Name = "ObterLideranca")]
        public ActionResult<Lideranca> Get(int id)
        {
            var lideranca = _context.Liderancas.FirstOrDefault(p => p.LiderancaId == id);
            if (lideranca is null)
            {
                return NotFound("Este id não existe, por favor digite um id válido.");
            }
            return lideranca;
        }

        [HttpPost]
        public ActionResult Post(Lideranca lideranca)
        {
            if (lideranca is null)
                return BadRequest();

            _context.Liderancas.Add(lideranca);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterLideranca",
                new { id = lideranca.LiderancaId }, lideranca);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Lideranca lideranca)
        {
            if (id != lideranca.LiderancaId)
            {
                return BadRequest("Por gentileza, digite um Id existente...");
            }

            _context.Entry(lideranca).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(lideranca);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var lideranca = _context.Liderancas.FirstOrDefault(p => p.LiderancaId == id);

            if (lideranca is null)
            {
                return NotFound("Liderança não localizada, por gentileza, digite um Id válido.");
            }

            _context.Liderancas.Remove(lideranca);
            _context.SaveChanges();

            return Ok(lideranca);
        }
    }
}
