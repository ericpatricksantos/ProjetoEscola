using ProjetoEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Interfaces
{
    public interface IDisciplinaRepository
    {

        public Task<List<Disciplina>> GetDisciplinasAsync();

        public Task<Disciplina> GetDisciplinaByIdAsync(int? id);


        public Task<int> SaveAsync(Disciplina novaDisciplina);

        public Task<int> UpdateDisciplinaAsync(Disciplina atualizaDisciplina);


        public Task<int> DeleteAsync(int? id);
    }
}
