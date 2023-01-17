using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositorio.Classes;
using PetShop.Repositorio.Entidades;
using PetShop.Util;

namespace PetShop.Controllers
{
	public class ClienteController : Controller
	{
		[HttpGet]
		public IActionResult Listar()
		{
			return View(new List<ClienteModels>());
		}

		[HttpPost]
		public IActionResult Listar(String busca)
		{
            List<ClienteModels> dados = new List<ClienteModels>();

            PetshopContext ctx = new PetshopContext();

			foreach (var cliente in ctx.Clientes.Where(x=>x.Cpf == busca).ToList())
			{
				dados.Add(new ClienteModels() { Codigo = cliente.Id, Nome = cliente.Nome, Cpf = cliente.Cpf, DataNascimento = cliente.DataNascimento });
			}

            return View(dados);
		}

		[HttpGet]
		public IActionResult Cadastrar() {
			return View();
		}

		[HttpPost]
		public IActionResult Cadastrar(ClienteModels model)
		{
			if (!ValidaUtil.IsCpf(model.Cpf))
				ModelState.AddModelError("cpf","CPF inválido");

			if ((DateTime.Now.Year - model.DataNascimento.Year) < 16)
                ModelState.AddModelError("DataNascimento", "Menor 16 anos");

            if (ModelState.ErrorCount > 0)
			{
				return View(model);
			}
			else
			{
				PetshopContext ctx = new PetshopContext();

				Cliente cliente = new Cliente();
				cliente.Nome = model.Nome;
				cliente.Cpf = model.Cpf;
				cliente.DataNascimento = model.DataNascimento;

				ctx.Add(cliente);

				if (ctx.SaveChanges() > 0)
					return RedirectToAction("Listar");
				else
					throw new Exception("Erro genérico ao salvar dados");
            }	
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			PetshopContext ctx = new PetshopContext();
			Cliente cliente = ctx.Clientes.Where(x => x.Id == id).FirstOrDefault();

			ctx.Remove(cliente);
			ctx.SaveChanges();

			return RedirectToAction("Listar");
		}

        [HttpGet]
        public IActionResult Aniversariante() { 
			return View(new List<ClienteModels>());	
		}

        [HttpPost]
        public IActionResult Aniversariante(int mes)
        {
			List<ClienteModels> lista = new List<ClienteModels>();
			PetshopContext ctx = new PetshopContext();
            foreach (var cliente in ctx.Clientes.Where(x => x.DataNascimento.Month == mes).ToList())
			{
				lista.Add(new ClienteModels()
				{
					Codigo = cliente.Id,
					Cpf = cliente.Cpf,
					DataNascimento = cliente.DataNascimento,
					Nome = cliente.Nome
				});
			}
            return View(lista);
        }

    }
}
