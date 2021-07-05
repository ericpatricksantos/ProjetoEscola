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
    public class AlunoPorCursoController : Controller
    {
        private Consultas consultas = new Consultas();
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.listaCursos = consultas.RetornaListaCursos();
            return View();
        }
      
        [HttpPost]
        public IActionResult Buscar([Bind("id","nome","curso_id","ano","semestre")] AlunoPorCursoView a)
        {
            var curso_id = a.curso_id;
            var ano = a.ano;
            var semestre = a.semestre;

            ViewBag.listaCursos = consultas.RetornaListaCursos();
            ViewBag.lista = consultas.RetornaAlunoPorCurso(curso_id, ano, semestre);
            return View("~/Views/AlunoPorCurso/Listagem.cshtml");
        }
    }
}
