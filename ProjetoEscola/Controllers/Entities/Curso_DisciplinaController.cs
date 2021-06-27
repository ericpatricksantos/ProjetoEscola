using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Models.Entities;
using ProjetoEscola.Repositories.Consultas;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers.Entities
{
    public class Curso_DisciplinaController : Controller
    {
        private readonly ICurso_DisciplinaRepository _DisciplinaRepository;
        private Consultas consultas = new Consultas();

        public Curso_DisciplinaController(ICurso_DisciplinaRepository curso_DisciplinaRepository)
        {
            _DisciplinaRepository = curso_DisciplinaRepository;
        }

        // GET: Curso_DisciplinaController
        public async Task<IActionResult> Index()
        {
            return View(await _DisciplinaRepository.GetCurso_DisciplinaAsync());
        }

        // GET: Curso_DisciplinaController/Details/5
        public async Task<IActionResult> Details(int? curso_id, int? disciplina_id)
        {
            if (curso_id == null && disciplina_id == null)
            {
                return NotFound();
            }

            var d = await _DisciplinaRepository
                .GetCurso_DisciplinaByIdAsync(curso_id,disciplina_id);
            if (d == null)
            {
                return NotFound();
            }

            return View(d);

        }

        // GET: Curso_DisciplinaController/Create
        public ActionResult Create()
        {
            //valor temporario para preencher os valores do dropdown
            ViewBag.listaCursos = consultas.RetornaListaCursos();
            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();

            return View();
        }

        // POST: Curso_DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("curso_id,disciplina_id,data_desativacao")] Curso_Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                await _DisciplinaRepository.SaveAsync(disciplina);

                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        // GET: Curso_DisciplinaController/Edit/5
        public async Task<IActionResult> Edit(int? curso_id, int? disciplina_id)
        {
            Curso_Disciplina disciplina = await _DisciplinaRepository.GetCurso_DisciplinaByIdAsync(curso_id,disciplina_id);

            if (disciplina == null)
            {
                return NotFound();
            }


            ViewBag.listaCursos = consultas.RetornaListaCursos();
            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();
            return View(disciplina);
        }

        // POST: Curso_DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int curso_id, int disciplina_id,[Bind("id,curso_id,disciplina_id,data_desativacao")] Curso_Disciplina curso_Disciplina)
        {
            if (curso_id != curso_Disciplina.curso_id && disciplina_id != curso_Disciplina.disciplina_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _DisciplinaRepository.UpdateCurso_DisciplinaAsync(curso_Disciplina);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso_Disciplina);
        }

        // GET: Curso_DisciplinaController/Delete/5
        public async Task<IActionResult> Delete(int? curso_id, int? disciplina_id)
        {
            if (curso_id == null && disciplina_id == null)
            {
                return NotFound();
            }

            var c = await _DisciplinaRepository.GetCurso_DisciplinaByIdAsync(curso_id,disciplina_id);

            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // POST: Curso_DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? curso_id, int? disciplina_id)
        {
            await _DisciplinaRepository.DeleteAsync(curso_id,disciplina_id);
            return RedirectToAction(nameof(Index));
        }
    }
}
