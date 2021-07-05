using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models
{
    public class Matricula
    {
        [Display(Name = "Código da Matricula")]
        public long id { get; set; }

        [RegularExpression(@"\d{4}", ErrorMessage = "Digite somente 4 dígitos numéricos")]
        [Display(Name = "Ano")]
        public int ano { get; set; }

        [RegularExpression(@"[12]", ErrorMessage = "Digite 1-Primeiro Semestre e 2-Segundo Semestre")]
        [Display(Name = "Semestre")]
        public int semestre { get; set; }

        [Required]
        [Display(Name = "Código do Aluno")]
        public long aluno_id { get; set; }

        [Required]
        [Display(Name = "Código do Curso")]
        public long curso_id { get; set; }
    }
}
