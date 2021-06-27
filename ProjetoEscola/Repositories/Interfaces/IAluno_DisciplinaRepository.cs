using ProjetoEscola.Models.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Interfaces
{
    /// <summary>
    /// Interface para expor os end-points da app
    /// </summary>
    public interface IAluno_DisciplinaRepository
    {
        public Task<List<Aluno_Disciplina>> GetAluno_DisciplinaAsync();

        public Task<Aluno_Disciplina> GetAluno_DisciplinaByIdAsync(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id);


        public Task<int> SaveAsync(Aluno_Disciplina novo);

        public Task<int> UpdateAluno_DisciplinaAsync(Aluno_Disciplina atualiza);


        public Task<int> DeleteAsync(int? matricula_id,int? aluno_id, int? curso_id, int? disciplina_id);
    }
}
