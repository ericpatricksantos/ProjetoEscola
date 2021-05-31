using ProjetoEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        public Task<List<Curso>> GetCursosAsync();

        public Task<Curso> GetCursoByIdAsync(int? id);


        public Task<int> SaveAsync(Curso novoCurso);

        public Task<int> UpdateCursoAsync(Curso atualizaCurso);


        public Task<int> DeleteAsync(int? id);
    }
}
