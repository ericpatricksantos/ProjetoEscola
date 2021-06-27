using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Models.CRUD;
using ProjetoEscola.Repositories.Consultas;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers.Entities
{
    public class Aluno_DisciplinaController : Controller
    {
        private readonly IAluno_DisciplinaRepository _aluno_DisciplinaRepository;
        private Consultas consultas = new Consultas();

        public Aluno_DisciplinaController(IAluno_DisciplinaRepository aluno_DisciplinaRepository)
        {
            _aluno_DisciplinaRepository = aluno_DisciplinaRepository;
        }


        // GET: Aluno_DisciplinaController
        public async Task<IActionResult> Index()
        {
            return View(await _aluno_DisciplinaRepository.GetAluno_DisciplinaAsync());
        }

        // GET: Aluno_DisciplinaController/Details/5
        public async Task<IActionResult> Details(int? matricula_id,int? aluno_id,int? curso_id, int? disciplina_id)
        {
            if (matricula_id == null && aluno_id == null && curso_id == null && disciplina_id == null)
            {
                return NotFound();
            }

            var d = await _aluno_DisciplinaRepository
                .GetAluno_DisciplinaByIdAsync(matricula_id,aluno_id,curso_id,disciplina_id);
            if (d == null)
            {
                return NotFound();
            }

            return View(d);
        }

        // GET: Aluno_DisciplinaController/Create
        public ActionResult Create()
        {
            //valor temporario para preencher os valores do dropdown
            ViewBag.listamatriculas = consultas.RetornaListaMatriculas();
            ViewBag.listaAlunos = consultas.RetornaListaAlunos();
            ViewBag.listaCursos = consultas.RetornaListaCursos();
            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();

            return View();
        }

        // POST: Aluno_DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,matricula_id,aluno_id,curso_id,disciplina_id,nota,status")] Aluno_Disciplina a)
        {
            if (ModelState.IsValid)
            {
                await _aluno_DisciplinaRepository.SaveAsync(a);

                return RedirectToAction(nameof(Index));
            }
            return View(a);
        }

        // GET: Aluno_DisciplinaController/Edit/5
        public async Task<IActionResult> Edit(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id)
        {
           Aluno_Disciplina a = await _aluno_DisciplinaRepository.GetAluno_DisciplinaByIdAsync(matricula_id, aluno_id, curso_id, disciplina_id);

            if (a == null)
            {
                return NotFound();
            }

            ViewBag.listamatriculas = consultas.RetornaListaMatriculas();
            ViewBag.listaAlunos = consultas.RetornaListaAlunos();
            ViewBag.listaCursos = consultas.RetornaListaCursos();
            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();

            return View(a);
        }

        // POST: Aluno_DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int matricula_id, int aluno_id, int curso_id, int disciplina_id, [Bind("id,matricula_id,aluno_id,curso_id,disciplina_id,nota,status")] Aluno_Disciplina a)
        {
            if ( matricula_id != a.matricula_id && aluno_id != a.aluno_id && curso_id != a.curso_id && disciplina_id != a.disciplina_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _aluno_DisciplinaRepository.UpdateAluno_DisciplinaAsync(a);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(a);
        }

        // GET: Aluno_DisciplinaController/Delete/5
        public async Task<IActionResult> Delete(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id)
        {
            if ( matricula_id == null && aluno_id == null && curso_id == null && disciplina_id == null)
            {
                return NotFound();
            }

            var c = await _aluno_DisciplinaRepository.GetAluno_DisciplinaByIdAsync(matricula_id,aluno_id,curso_id,disciplina_id);
                

            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        // POST: Aluno_DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id)
        {
            await _aluno_DisciplinaRepository.DeleteAsync(matricula_id, aluno_id, curso_id, disciplina_id);
                
            return RedirectToAction(nameof(Index));
        }
    }
}
