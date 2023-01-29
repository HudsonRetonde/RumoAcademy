using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargosController(AppDbContext context)
        {
            _context = context;
        }
                    
        [HttpGet]
        public ActionResult<IEnumerable<Cargo>> Get()
        {
            try
            {
                return _context.Cargos.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCargo")]
        public ActionResult<Cargo> Get(int id)
        {
            try
            {
                var cargo = _context.Cargos.AsNoTracking().FirstOrDefault(p => p.CargoId == id);
                if (cargo is null)
                {
                    return NotFound($" O Id {id} não existe, digite um Id válido...");
                }
                return Ok(cargo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Cargo cargo)
        {
            if (cargo is null)
                return BadRequest("Cargo não encontrado.");

            _context.Cargos.Add(cargo);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCargo",
                new { id = cargo.CargoId }, cargo);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Cargo cargo)
        {
            if (id != cargo.CargoId)
            {
                return BadRequest($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Entry(cargo).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cargo);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var cargo = _context.Cargos.FirstOrDefault(p => p.CargoId == id);

            if (cargo is null)
            {
                return NotFound($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Cargos.Remove(cargo);
            _context.SaveChanges();

            return Ok(cargo);
        }
    }
}
