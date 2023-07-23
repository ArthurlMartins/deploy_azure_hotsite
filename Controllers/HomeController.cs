using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {
            DatabaseService dbs = new DatabaseService();
            try
            {
                dbs.CadastraInteresse(cad);
                return View("Index", cad);
            }catch(Exception e)
            {
                _logger.LogError("Falha ao cadastrar: " +e.Message);
                Console.WriteLine("Falha ao cadastrar: " +e.Message);
            } 
            return View("Index",cad);
        }

    }
}
