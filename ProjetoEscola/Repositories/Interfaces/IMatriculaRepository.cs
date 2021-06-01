using ProjetoEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Interfaces
{
    /// <summary>
    /// Interface para expor os end-points da app
    /// </summary>
    public interface IMatriculaRepository
    {
        public Task<List<Matricula>> GetMatriculaAsync();

        public Task<Matricula> GetMatriculaByIdAsync(int? id);


        public Task<int> SaveAsync(Matricula novaMatricula);

        public Task<int> UpdateMatriculaAsync(Matricula atualizaMatricula);


        public Task<int> DeleteAsync(int? id);
    }
}
