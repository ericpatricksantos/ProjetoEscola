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
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private IConfiguration _configuration;

        //Injentando dependencias
        public DisciplinaRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from escola.disciplina where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: new { id });
                return result;
            }
        }

        public async Task<Disciplina> GetDisciplinaByIdAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.disciplina where id = @id";

                Disciplina d = await conn.QueryFirstOrDefaultAsync<Disciplina>(sql: query, param: new { id });
                return d;
            }
        }

        public async Task<List<Disciplina>> GetDisciplinasAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.disciplina";

                List<Disciplina> d = (await conn.QueryAsync<Disciplina>(sql: query)).ToList();
                return d;
            }
        }

        public async Task<int> SaveAsync(Disciplina novaDisciplina)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into escola.disciplina(id,nome) values(@id, @nome)";

                var result = await conn.ExecuteAsync(sql: query, param: novaDisciplina);
                return result;
            }
        }

        public async Task<int> UpdateDisciplinaAsync(Disciplina atualizaDisciplina)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"update escola.disciplina set id = @id , nome=@nome where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: atualizaDisciplina);
                return result;
            }
        }
    }
}
