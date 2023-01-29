using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("FuncionariosEquipes")]
        public ActionResult<IEnumerable<Equipe>> GetEquipesFuncionarios()
        {
            try
            {
                return _context.Equipes.Include(p => p.Funcionarios).Where(e => e.EquipeId <= 10).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("LiderancasEquipes")]
        public ActionResult<IEnumerable<Equipe>> GetEquipesLiderancas()
        {
            try
            {
                return _context.Equipes.Include(p => p.Liderancas).Where(e => e.EquipeId <= 10).AsNoTracking().ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipe>> Get()
        {
            try
            {
                var equipes = _context.Equipes.AsNoTracking().ToList();
                if (equipes is null)
                {
                    return NotFound("Equipe não encontrada.");
                }
                return equipes;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterEquipe")]
        public ActionResult<Equipe> Get(int id)
        {
            try
            {
                var equipe = _context.Equipes.AsNoTracking().FirstOrDefault(p => p.EquipeId == id);
                if (equipe is null)
                {
                    return NotFound($" O Id {id} não existe, digite um Id válido...");
                }
                return equipe;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Equipe equipe)
        {
            if (equipe is null)
                return BadRequest("Equipe não encontrada...");

            _context.Equipes.Add(equipe);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEquipe",
                new { id = equipe.EquipeId }, equipe);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Equipe equipe)
        {
            if (id != equipe.EquipeId)
            {
                return BadRequest($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Entry(equipe).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(equipe);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(p => p.EquipeId == id);

            if (equipe is null)
            {
                return NotFound($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Equipes.Remove(equipe);
            _context.SaveChanges();

            return Ok(equipe);
        }
    }
}
