using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models;
using ProjetoEscola.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Implementations
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private IConfiguration _configuration;

        //Injentando dependencias
        public MatriculaRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from escola.matricula where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: new { id });
                return result;
            }
        }

        public async Task<List<Matricula>> GetMatriculaAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.matricula";

                List<Matricula> a = (await conn.QueryAsync<Matricula>(sql: query)).ToList();
                return a;
            }
        }

        public async Task<Matricula> GetMatriculaByIdAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.matricula where id = @id";

                Matricula a = await conn.QueryFirstOrDefaultAsync<Matricula>(sql: query, param: new { id });
                return a;
            }
        }

        public async Task<int> SaveAsync(Matricula novaMatricula)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into escola.matricula(id,ano,semestre,aluno_id,curso_id) values(@id,@ano,@semestre,@aluno_id,@curso_id)";

                var result = await conn.ExecuteAsync(sql: query, param: novaMatricula);
                return result;
            }
        }

        public async Task<int> UpdateMatriculaAsync(Matricula atualizaMatricula)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"update escola.matricula set id = @id , ano = @ano, semestre = @semestre, aluno_id = @aluno_id, curso_id = @curso_id where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: atualizaMatricula);
                return result;
            }
        }
    }
}
