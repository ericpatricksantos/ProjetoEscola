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
    public class CursoRepository : ICursoRepository
    {
        private IConfiguration _configuration;

        public CursoRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from escola.curso where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: new { id });
                return result;
            }
        }

        public async Task<Curso> GetCursoByIdAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.curso where id = @id";

                Curso c = await conn.QueryFirstOrDefaultAsync<Curso>(sql: query, param: new { id });
                return c;
            }
        }

        public async Task<List<Curso>> GetCursosAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.curso";

                List<Curso> c = (await conn.QueryAsync<Curso>(sql: query)).ToList();
                return c;
            }
        }

        public async Task<int> SaveAsync(Curso novoCurso)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into escola.curso(id,nome) values(@id, @nome)";

                var result = await conn.ExecuteAsync(sql: query, param: novoCurso);
                return result;
            }
        }

        public async Task<int> UpdateCursoAsync(Curso atualizaCurso)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"update escola.curso set id = @id , nome=@nome where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: atualizaCurso);
                return result;
            }
        }
    }
}
