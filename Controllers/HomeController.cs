using Fiap01.Data;
using Fiap01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.Controllers
{
    public class HomeController : Controller
    {
        private PerguntasContext _context;

        public HomeController(PerguntasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Nome = "Igor";
            //ViewData["NomeDoAluno"] = $"Igor às {DateTime.Now}";

            //var viewModel = new Pergunta() { Id = 1, Descricao = "Que horas é a chamada ?", Autor = "Igor" };

            //return View(viewModel);

            return View(_context.Perguntas.ToList());
        }
        public IActionResult Ajuda()
        {
            return View();
        }
        public IActionResult Sobre()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                await _context.SaveChangesAsync();
            }
            return View();
        }
    }
}
