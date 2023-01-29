﻿using APIPontoColaborador.Context;
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
            try
            {
                return _context.Funcionarios.Include(p => p.Cargos).Where(f => f.FuncionarioId <= 10).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> Get()
        {
            try
            {
                var funcionarios = _context.Funcionarios.AsNoTracking().ToList();
                if (funcionarios is null)
                {
                    return NotFound($"Funcionario não encontrado.");
                }
                return funcionarios;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterFuncionario")]
        public ActionResult<Funcionario> Get(int id)
        {
            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(p => p.FuncionarioId == id);
                if (funcionario is null)
                {
                    return NotFound("Este id não existe, por favor digite um id válido.");
                }
                return funcionario;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar a sua solicitação.");
            }
        }

        [HttpPost]
        public ActionResult Post(Funcionario funcionario)
        {
            if (funcionario is null)
                return BadRequest("Funcionário não encontrado");

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterFuncionario",
                new { id = funcionario.FuncionarioId }, funcionario);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return BadRequest($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Entry(funcionario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(funcionario);
        }

        [HttpDelete("{id:int}:min(1)")]
        public ActionResult Delete(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(p => p.FuncionarioId == id);

            if (funcionario is null)
            {
                return NotFound($" O Id {id} não existe, digite um Id válido...");
            }

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();

            return Ok(funcionario);
        }
    }


}
