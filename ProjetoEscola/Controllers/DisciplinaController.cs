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
    public class DisciplinaController : Controller
    {

        private readonly IDisciplinaRepository _discRepository;

        public DisciplinaController(IDisciplinaRepository discrepo)
        {
            _discRepository = discrepo;
        }

        // GET: DisciplinaController
        public async Task<IActionResult> Index()
        {
            return View(await _discRepository.GetDisciplinasAsync());
        }

        // GET: DisciplinaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _discRepository
                .GetDisciplinaByIdAsync(id);
            if (d == null)
            {
                return NotFound();
            }

            return View(d);
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] Disciplina d)
        {
            if (ModelState.IsValid)
            {
                await _discRepository.SaveAsync(d);

                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        // GET: DisciplinaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _discRepository.GetDisciplinaByIdAsync(id);

            if (d == null)
            {
                return NotFound();
            }
            return View(d);
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("id,nome")] Disciplina d)
        {
            if (id != d.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _discRepository.UpdateDisciplinaAsync(d);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        // GET: DisciplinaController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _discRepository.GetDisciplinaByIdAsync(id);

            if (d == null)
            {
                return NotFound();
            }

            return View(d);
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _discRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
