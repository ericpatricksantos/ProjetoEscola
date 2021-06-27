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

        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
