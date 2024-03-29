﻿using Dapper;
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
    public class AlunoRepository : IAlunoRepository
    {
        private IConfiguration _configuration;

        //Injentando dependencias
        public AlunoRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<int> DeleteAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"delete from escola.aluno where id = @id";

               var result = await conn.ExecuteAsync(sql: query, param: new { id });
                return result;
            }
        }

        public async Task<Aluno> GetAlunoByIdAsync(int? id)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.aluno where id = @id";

                Aluno a = await conn.QueryFirstOrDefaultAsync<Aluno>(sql: query, param: new { id });
                return a;
            }
        }

        public async Task<List<Aluno>> GetAlunosAsync()
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"select * from escola.aluno";

                List<Aluno> a = (await conn.QueryAsync<Aluno>(sql: query)).ToList();
                return a;
            }
        }

        public async Task<int> SaveAsync(Aluno novoAluno)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"insert into escola.aluno(id,nome) values(@id, @nome)";

                var result = await conn.ExecuteAsync(sql: query, param: novoAluno);
                return result;
            }
        }

        public async Task<int> UpdateAlunoAsync(Aluno atualizaAluno)
        {
            using (MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = @"update escola.aluno set id = @id , nome=@nome where id = @id";

                var result = await conn.ExecuteAsync(sql: query, param: atualizaAluno);
                return result;
            }
        }
    }
}
