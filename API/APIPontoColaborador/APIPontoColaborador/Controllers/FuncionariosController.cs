using APIPontoColaborador.Context;
using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Cargos")]
        public ActionResult<IEnumerable<Funcionario>> GetFuncionariosCargos()
        {
            return _context.Funcionarios.Include(p => p.Cargos).Where(f => f.FuncionarioId <= 10).AsNoTracking().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> Get()
        {
            var funcionarios = _context.Funcionarios.AsNoTracking().ToList();
            if (funcionarios is null)
            {
                return NotFound("Funcionario não encontrado.");
            }
            return funcionarios;
        }

        [HttpGet("{id:int}", Name = "ObterFuncionario")]
        public ActionResult<Funcionario> Get(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(p => p.FuncionarioId == id);
            if (funcionario is null)
            {
                return NotFound("Este id não existe, por favor digite um id válido.");
            }
            return funcionario;
        }

        [HttpPost]
        public ActionResult Post(Funcionario funcionario)
        {
            if (funcionario is null)
                return BadRequest();

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterFuncionario",
                new { id = funcionario.FuncionarioId }, funcionario);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return BadRequest("Por gentileza, digite um Id existente...");
            }

            _context.Entry(funcionario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(funcionario);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(p => p.FuncionarioId == id);

            if (funcionario is null)
            {
                return NotFound("Funcionario não localizado, por gentileza, digite um Id válido.");
            }

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();

            return Ok(funcionario);
        }
    }


}
