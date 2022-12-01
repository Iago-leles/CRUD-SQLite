using CRUD_SQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_SQLite.Controllers
{
    public class AvioesController : Controller
    {
        private readonly Contexto _contexto;

        public AvioesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Avioes.ToListAsync());
        }

        [HttpGet]
        public IActionResult NovoAviao()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoAviao(Aviao aviao)
        {
            await _contexto.Avioes.AddAsync(aviao);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<ActionResult> AtualizarAviao(int aviaoId)
        {
            Aviao aviao = await _contexto.Avioes.FindAsync(aviaoId);

            return View(aviao);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarAviao(Aviao aviao)
        {
            _contexto.Avioes.Update(aviao);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirAviao(int aviaoId)
        {
            Aviao aviao = await _contexto.Avioes.FindAsync(aviaoId);
            _contexto.Avioes.Remove(aviao);

            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
