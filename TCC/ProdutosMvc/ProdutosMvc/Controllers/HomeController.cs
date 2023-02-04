using Microsoft.AspNetCore.Mvc;
using ProdutosMvc.Models;
using System.Diagnostics;

namespace ProdutosMvc.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }       
    }
}