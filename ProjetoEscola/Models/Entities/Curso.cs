using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models
{
    public class Curso
    {
        [Display(Name = "Código")]
        public long id { get; set; }

        [Display(Name = "Código")]
        public string nome { get; set; }
    }
}
