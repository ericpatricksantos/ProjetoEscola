using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.Repositories.Consultas
{
    public class Consultas
    {
        private IConfiguration _configuration;

        public Consultas()
        {
        }

        //Injentando dependencias
        public Consultas(IConfiguration config)
        {
            _configuration = config;
        }

        public List<Aluno> RetornaListaAlunos()
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {


                string query = "select * from aluno";



                conn.Open();

                List<Aluno> alunos = (conn.Query<Aluno>(sql: query)).ToList();

                return alunos;



                conn.Close();



            }
        }


            public List<Curso> RetornaListaCursos()
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = "select * from curso";
                conn.Open();

                List<Curso> cursos = (conn.Query<Curso>(sql: query)).ToList();

                return cursos;

                conn.Close();

            }
        }
    }
}
