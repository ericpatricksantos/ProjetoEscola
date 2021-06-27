using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models.Entities;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Implementations
{
    public class Curso_DisciplinaRepository : ICurso_DisciplinaRepository
    {
        private IConfiguration _configuration;

        //Injentando dependencias
        public Curso_DisciplinaRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? curso_id, int? disciplina_id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from curso_disciplina where curso_id = @curso_id and disciplina_id = @disciplina_id";

                var result = await conn.ExecuteAsync(sql: query, param: new { curso_id, disciplina_id });
                return result;
            }
        }

        public async Task<List<Curso_Disciplina>> GetCurso_DisciplinaAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from curso_disciplina";

                List<Curso_Disciplina> a = (await conn.QueryAsync<Curso_Disciplina>(sql: query)).ToList();
                return a;
            }
        }

        public async Task<Curso_Disciplina> GetCurso_DisciplinaByIdAsync(int? curso_id, int? disciplina_id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from curso_disciplina where curso_id = @curso_id and disciplina_id = @disciplina_id";

                Curso_Disciplina a = await conn.QueryFirstOrDefaultAsync<Curso_Disciplina>(sql: query, param: new { curso_id,disciplina_id });
                return a;
            }
        }

        public async Task<int> SaveAsync(Curso_Disciplina novo)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into curso_disciplina(curso_id, disciplina_id, data_desativacao) values(@curso_id,@disciplina_id,@data_desativacao)";

                var result = await conn.ExecuteAsync(sql: query, param: novo);
                return result;
            }
        }

        public async Task<int> UpdateCurso_DisciplinaAsync(Curso_Disciplina atualiza)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"
                       update curso_disciplina 
                       set curso_id=@curso_id,disciplina_id=@disciplina_id,data_desativacao=@data_desativacao
                       where id=@id";

                var result = await conn.ExecuteAsync(sql: query, param: atualiza);
                return result;

            }


        }
    }
}
