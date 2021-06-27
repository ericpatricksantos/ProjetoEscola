using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models.CRUD;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Implementations
{
    public class Aluno_DisciplinaRepository : IAluno_DisciplinaRepository
    {
        private IConfiguration _configuration;

        //Injentando dependencias
        public Aluno_DisciplinaRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from aluno_disciplina 
                    where matricula_id = @matricula_id and 
                    aluno_id = @aluno_id and 
                    curso_id = @curso_id and 
                    disciplina_id = @disciplina_id";

                var result = await conn.ExecuteAsync(sql: query, param: new { matricula_id, aluno_id, curso_id, disciplina_id });
                return result;
            }
        }

        public async Task<List<Aluno_Disciplina>> GetAluno_DisciplinaAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from aluno_disciplina";

                List<Aluno_Disciplina> a = (await conn.QueryAsync<Aluno_Disciplina>(sql: query)).ToList();
                return a;
            }
        }

        public async Task<Aluno_Disciplina> GetAluno_DisciplinaByIdAsync(int? matricula_id, int? aluno_id, int? curso_id, int? disciplina_id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from aluno_disciplina
                                where matricula_id = @matricula_id and 
                                aluno_id = @aluno_id and
                                curso_id = @curso_id and
                                disciplina_id = @disciplina_id";

                Aluno_Disciplina a = await conn.QueryFirstOrDefaultAsync<Aluno_Disciplina>(sql: query, param: new { matricula_id, aluno_id, curso_id, disciplina_id });
                return a;
            }
        }

        public async Task<int> SaveAsync(Aluno_Disciplina novo)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into aluno_disciplina(matricula_id,aluno_id,curso_id, disciplina_id,nota,status)
                    values(@matricula_id,@aluno_id,@curso_id,@disciplina_id,@nota, @status)";


                var result = await conn.ExecuteAsync(sql: query, param: novo);
                return result;
            }
        }

        public async Task<int> UpdateAluno_DisciplinaAsync(Aluno_Disciplina atualiza)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"update aluno_disciplina 
                set matricula_id = @matricula_id,
                aluno_id = @aluno_id, 
                curso_id = @curso_id,
                disciplina_id = @disciplina_id, 
                nota = @nota,
                status = @status 
                where id = @id ";

                var result = await conn.ExecuteAsync(sql: query, param: atualiza);
                return result;
            }
        }
    }
}
