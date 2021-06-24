using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Models.CRUD
{
    public class Aluno_Disciplina
    {
        public long matricula_id { get; set; }

        public long aluno_id { get; set; }


        public long curso_id { get; set; }

        public long disciplina_id { get; set; }


        public double nota { get; set; }

        public bool status { get; set; }
    }
}
