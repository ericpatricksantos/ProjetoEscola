using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class CursoController : Controller
    {

        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursorepo)
        {
            _cursoRepository = cursorepo;
        }

        // GET: CursoController
        public async Task<IActionResult> Index()
        {
            return View(await _cursoRepository.GetCursosAsync());
        }

        // GET: CursoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = await _cursoRepository
                .GetCursoByIdAsync(id);
            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] Curso c)
        {
            if (ModelState.IsValid)
            {
                await _cursoRepository.SaveAsync(c);

                return RedirectToAction(nameof(Index));
            }
            return View(c);
        }

        // GET: CursoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = await _cursoRepository.GetCursoByIdAsync(id);

            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("id,nome")] Curso curso)
        {
            if (id != curso.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cursoRepository.UpdateCursoAsync(curso);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: CursoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = await _cursoRepository.GetCursoByIdAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // POST: CursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cursoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
