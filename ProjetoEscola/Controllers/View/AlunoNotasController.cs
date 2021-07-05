using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola.Models.View;
using ProjetoEscola.Repositories.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Controllers.View
{
    public class AlunoNotasController : Controller
    {
        private Consultas consultas = new Consultas();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();
            return View();
        }

        [HttpPost]
        public IActionResult Buscar([Bind("aluno_id", "nome", "nomeDisciplina", "disciplina_id", "ano", "semestre", "nota")] AlunoNotasView a)
        {
            var displina_id = a.disciplina_id;
            var ano = a.ano;
            var semestre = a.semestre;

            ViewBag.listaDisciplinas = consultas.RetornaListaDisciplinas();
            ViewBag.lista = consultas.RetornaAlunoNotas(displina_id, ano, semestre);
            return View("~/Views/AlunoNotas/Listagem.cshtml");
        }
    }
}
