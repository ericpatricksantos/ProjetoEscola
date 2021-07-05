using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.CRUD
{
    public class Aluno_Disciplina
    {
        public long id { get; set; }

        [Required]
        [Display(Name = "Matricula")]
        public long matricula_id { get; set; }

        [Required]
        [Display(Name = "Código de Aluno")]
        public long aluno_id { get; set; }

        [Required]
        [Display(Name = "Código do Curso")]
        public long curso_id { get; set; }

        [Required]
        [Display(Name = "Código da Disciplina")]
        public long disciplina_id { get; set; }

        [Required]
        [Display(Name = "Nota")]
        public double nota { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool status { get; set; }
    }
}
