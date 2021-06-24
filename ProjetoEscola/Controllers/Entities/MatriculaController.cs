using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories.Consultas;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IMatriculaRepository _matRepository;
        private Consultas consultas = new Consultas();

        public MatriculaController(IMatriculaRepository matrepo)
        {
            _matRepository = matrepo;
        }


        // GET: MatriculaController
        public async Task<IActionResult> Index()
        {
            return View(await _matRepository.GetMatriculaAsync());
        }

        // GET: MatriculaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m = await _matRepository
                .GetMatriculaByIdAsync(id);
            if (m == null)
            {
                return NotFound();
            }

            return View(m);
        }

        // GET: MatriculaController/Create
        public ActionResult Create()
        {
           //valor temporario para preencher os valores do dropdown
            ViewBag.listaAluno = consultas.RetornaListaAlunos();
            ViewBag.listaCurso = consultas.RetornaListaCursos();

            return View();
        }

        // POST: MatriculaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ano,semestre,aluno_id,curso_id")] Matricula mat)
        {
            if (ModelState.IsValid)
            {
                await _matRepository.SaveAsync(mat);

                return RedirectToAction(nameof(Index));
            }
            return View(mat);
        }

        // GET: MatriculaController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Matricula m = await _matRepository.GetMatriculaByIdAsync(id);

            if (m == null)
            {
                return NotFound();
            }
            return View(m);
        }

        // POST: MatriculaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("id,ano,semestre,aluno_id,curso_id")] Matricula m)
        {
            if (id != m.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _matRepository.UpdateMatriculaAsync(m);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(m);
        }

        // GET: MatriculaController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m = await _matRepository.GetMatriculaByIdAsync(id);

            if (m == null)
            {
                return NotFound();
            }

            return View(m);
        }

        // POST: MatriculaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _matRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
