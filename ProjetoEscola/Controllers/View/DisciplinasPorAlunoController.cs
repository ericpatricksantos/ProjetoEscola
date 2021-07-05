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
    public class DisciplinasPorAlunoController : Controller
    {
        private Consultas consultas = new Consultas();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.listaAlunos = consultas.RetornaListaAlunos();
            return View();
        }

        [HttpPost]
        public IActionResult Buscar([Bind("aluno_id","nome", "nomeDisciplina","disciplina_id", "ano", "semestre","nota")] DisciplinasPorAlunoView d)
        {
            var aluno_id = d.aluno_id;
            var ano = d.ano;
            var semestre = d.semestre;

            ViewBag.listaAlunos = consultas.RetornaListaAlunos();
            ViewBag.lista = consultas.RetornaDisciplinasPorAluno(aluno_id, ano, semestre);
            return View("~/Views/DisciplinasPorAluno/Listagem.cshtml");
        }
    }
}
