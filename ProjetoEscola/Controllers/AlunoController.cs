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
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunorepo)
        {
            _alunoRepository = alunorepo;
        }

        // GET: AlunoController
        public async Task<IActionResult> Index()
        {
            return View(await  _alunoRepository.GetAlunosAsync());
        }

        // GET: AlunoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository
                .GetAlunoByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _alunoRepository.SaveAsync(aluno);
               
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: AlunoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository.GetAlunoByIdAsync(id);
              
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("id,nome")] Aluno aluno)
        {
            if (id != aluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _alunoRepository.SaveAsync(aluno);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: AlunoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository.GetAlunoByIdAsync(id);
                
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _alunoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
