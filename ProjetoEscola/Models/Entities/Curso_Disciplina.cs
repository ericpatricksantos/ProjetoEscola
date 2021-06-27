using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.Entities
{
    public class Curso_Disciplina
    {
        public long id { get; set; }

        [Display(Name = "Código do Curso")]
        public long curso_id { get; set; }

        [Display(Name = "Código da Disciplina")]
        public long disciplina_id { get; set; }

        [Display(Name = "Data de Desativação")]
        public DateTime data_desativacao{ get; set; }
    }
}
