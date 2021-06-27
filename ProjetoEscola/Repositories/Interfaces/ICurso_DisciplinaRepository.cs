using ProjetoEscola.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Interfaces
{
    /// <summary>
    /// Interface para expor os end-points da app
    /// </summary>
    public interface ICurso_DisciplinaRepository
    {

        public Task<List<Curso_Disciplina>> GetCurso_DisciplinaAsync();

        public Task<Curso_Disciplina> GetCurso_DisciplinaByIdAsync(int? curso_id, int? disciplina_id);


        public Task<int> SaveAsync(Curso_Disciplina novo);

        public Task<int> UpdateCurso_DisciplinaAsync(Curso_Disciplina atualiza);


        public Task<int> DeleteAsync(int? curso_id, int? disciplina_id);
    }
}
