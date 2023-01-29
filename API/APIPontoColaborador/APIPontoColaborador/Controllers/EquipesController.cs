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
            return _context.Equipes.Include(p => p.Funcionarios).Where(e => e.EquipeId <= 10).AsNoTracking().ToList();
        }

        [HttpGet("LiderancasEquipes")]
        public ActionResult<IEnumerable<Equipe>> GetEquipesLiderancas()
        {
            return _context.Equipes.Include(p => p.Liderancas).Where(e => e.EquipeId <= 10).AsNoTracking().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipe>> Get()
        {
            var equipes = _context.Equipes.AsNoTracking().ToList();
            if (equipes is null)
            {
                return NotFound("Equipe não encontrada.");
            }
            return equipes;
        }

        [HttpGet("{id:int}", Name = "ObterEquipe")]
        public ActionResult<Equipe> Get(int id)
        {
            var equipe = _context.Equipes.AsNoTracking().FirstOrDefault(p => p.EquipeId == id);
            if (equipe is null)
            {
                return NotFound("Este id não existe, por favor digite um id válido.");
            }
            return equipe;
        }

        [HttpPost]
        public ActionResult Post(Equipe equipe)
        {
            if (equipe is null)
                return BadRequest();

            _context.Equipes.Add(equipe);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEquipe",
                new { id = equipe.EquipeId }, equipe);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Equipe equipe)
        {
            if (id != equipe.EquipeId)
            {
                return BadRequest("Por gentileza, digite um Id existente...");
            }

            _context.Entry(equipe).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(equipe);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var equipe = _context.Equipes.FirstOrDefault(p => p.EquipeId == id);

            if (equipe is null)
            {
                return NotFound("Equipe não localizada, por gentileza, digite um Id válido.");
            }

            _context.Equipes.Remove(equipe);
            _context.SaveChanges();

            return Ok(equipe);
        }
    }
}
