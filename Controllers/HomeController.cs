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
            try
            {
                DatabaseService dbs = new DatabaseService();
                dbs.CadastraInteresse(cad);
                return Json(new{status="OK"}); //mensagem que sinaliza no Logs se o formulário foi enviado com sucesso
            }
            catch (Exception e)
            {
                _logger.LogError("REGISTRO DE LOGGS DO CADASTRO!!!" + e.Message);
                return Json(new{status="ERR", mensagem = "Erro ao cadastrar!"});  //mensagem que sinaliza no Logs se o formulário deu erro 
            }

        }

    }
}
