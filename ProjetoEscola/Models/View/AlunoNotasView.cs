using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.View
{
    public class AlunoNotasView
    {
        [Display(Name = "Nome do Aluno")]
        public string nome { get; set; }

        [Display(Name = "Nome da Disciplina")]
        public string nomeDisciplina { get; set; }

        [Display(Name = "Código da Disciplina")]
        public long disciplina_id { get; set; }

        [Display(Name = "Ano")]
        public int ano { get; set; }

        [Display(Name = "Semestre")]
        public int semestre { get; set; }

        [Display(Name = "Nota")]
        public double nota { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool status { get; set; }
    }
}
