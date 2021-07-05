using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.View
{
    public class DisciplinasPorAlunoView
    {  
        [Display(Name = "Código do Aluno")]
        public long aluno_id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Código do Disciplina")]
        public string nomeDisciplina { get; set; }

        [Display(Name = "Código do Disciplina")]
        public long disciplina_id { get; set; }

        [Display(Name = "Ano")]
        public int ano { get; set; }

        [Display(Name = "Semestre")]
        public int semestre { get; set; }

        [Display(Name = "Nota")]
        public double nota { get; set; }
    }
}
