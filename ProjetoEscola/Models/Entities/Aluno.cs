using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models
{
    public class Aluno
    {

        [Display(Name = "Código")]
        public long id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z'-'\s]{1,40}$", ErrorMessage = "Digite somente letras maiusculas e minusculas")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
