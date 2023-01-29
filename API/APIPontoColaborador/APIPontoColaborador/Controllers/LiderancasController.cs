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
            try
            {
                return _context.Liderancas.Include(p => p.Funcionarios).Where(l => l.LiderancaId <= 10).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lideranca>> Get()
        {
            try
            {
                var liderancas = _context.Liderancas.AsNoTracking().ToList();
                if (liderancas is null)
                {
                    return NotFound("Lideranca não encontrada.");
                }
                return liderancas;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name = "ObterLideranca")]
        public ActionResult<Lideranca> Get(int id)
        {
            try
            {
                var lideranca = _context.Liderancas.AsNoTracking().FirstOrDefault(p => p.LiderancaId == id);
                if (lideranca is null)
                {
                    return NotFound("Este id não existe, por favor digite um id válido.");
                }
                return lideranca;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Lideranca lideranca)
        {
            if (lideranca is null)
                return BadRequest("Liderança não encontrada.");

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
                return BadRequest($" O Id {id} não existe, digite um Id válido...");
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
                return NotFound($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Liderancas.Remove(lideranca);
            _context.SaveChanges();

            return Ok(lideranca);
        }
    }
}
