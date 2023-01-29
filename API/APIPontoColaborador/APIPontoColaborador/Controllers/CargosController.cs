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
            return _context.Cargos.AsNoTracking().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCargo")]
        public ActionResult<Cargo> Get(int id)
        {
            var cargo = _context.Cargos.AsNoTracking().FirstOrDefault(p => p.CargoId == id);
            if (cargo is null)
            {
                return NotFound("Este id não existe, por favor digite um id válido.");
            }
            return Ok(cargo);
        }

        [HttpPost]
        public ActionResult Post(Cargo cargo)
        {
            if (cargo is null)
                return BadRequest();

            _context.Cargos.Add(cargo);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCargo",
                new { id = cargo.CargoId }, cargo);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cargo cargo)
        {
            if (id != cargo.CargoId)
            {
                return BadRequest("Por gentileza, digite um Id existente...");
            }

            _context.Entry(cargo).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cargo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cargo = _context.Cargos.FirstOrDefault(p => p.CargoId == id);

            if (cargo is null)
            {
                return NotFound("Cargo não localizado, por gentileza, digite um Id válido.");
            }

            _context.Cargos.Remove(cargo);
            _context.SaveChanges();

            return Ok(cargo);
        }
    }
}
