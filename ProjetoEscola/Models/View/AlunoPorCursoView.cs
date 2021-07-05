using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.View
{
    public class AlunoPorCursoView
    {
        [Display(Name = "Código")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Código do Curso")]
        public long curso_id { get; set; }

        [Display(Name = "Ano")]
        public int ano { get; set; }

        [Display(Name = "Semestre")]
        public int semestre { get; set; }
    }
}
