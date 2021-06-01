using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models
{
    public class Matricula
    {
        public long id { get; set; }

        public int ano { get; set; }

        public int semestre { get; set; }

        public long aluno_id { get; set; }

        public long curso_id { get; set; }
    }
}
