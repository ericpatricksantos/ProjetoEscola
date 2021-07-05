using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoEscola.Models;
using ProjetoEscola.Models.View;
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

        public List<Disciplina> RetornaListaDisciplinas()
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = "select * from disciplina";
                conn.Open();

                List<Disciplina> d = (conn.Query<Disciplina>(sql: query)).ToList();

                return d;

                conn.Close();

            }
        }

        public List<Matricula> RetornaListaMatriculas()
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = "select * from matricula";
                conn.Open();

                List<Matricula> m = (conn.Query<Matricula>(sql: query)).ToList();

                return m;

                conn.Close();

            }
        }


        public List<AlunoPorCursoView> RetornaAlunoPorCurso(long curso_id, int ano, int semestre)
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = @"
                select a.nome,m.curso_id,m.ano,m.semestre
                from matricula m, aluno a, curso c
                where m.curso_id = c.id and
                m.aluno_id = a.id and 
                m.ano = @ano and 
                m.semestre = @semestre and 
                m.curso_id = @curso_id";
                conn.Open();

                List<AlunoPorCursoView> a = (conn.Query<AlunoPorCursoView>(sql: query, param: new { curso_id,ano,semestre})).ToList();

                return a;

                conn.Close();
            }
        }

        public List<DisciplinasPorAlunoView> RetornaDisciplinasPorAluno(long aluno_id,int ano,int semestre)
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = @"
                select aluno_disciplina.aluno_id,aluno.nome as nome,disciplina.nome as nomeDisciplina,aluno_disciplina.disciplina_id,matricula.ano,matricula.semestre,aluno_disciplina.nota
                from aluno_disciplina, matricula, aluno, disciplina
                where aluno_disciplina.matricula_id = matricula.id and
                aluno_disciplina.aluno_id = aluno.id and
                aluno_disciplina.disciplina_id = disciplina.id and
                matricula.ano = @ano and
                matricula.semestre = @semestre and
                aluno_disciplina.aluno_id = @aluno_id ";
                conn.Open();

                List<DisciplinasPorAlunoView> d = (conn.Query<DisciplinasPorAlunoView>(sql: query,param: new { aluno_id,ano,semestre})).ToList();

                return d;

                conn.Close();
            }
        }

        public List<AlunoNotasView> RetornaAlunoNotas(long disciplina_id, int ano, int semestre)
        {
            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = escola; Uid = root; Pwd = mysql"))
            {
                string query = @"
                select aluno.nome as nome,disciplina.nome as nomeDisciplina,aluno_disciplina.disciplina_id,matricula.ano,matricula.semestre,aluno_disciplina.nota,aluno_disciplina.status
                from aluno_disciplina, matricula, aluno, disciplina
                where aluno_disciplina.matricula_id = matricula.id and
                aluno_disciplina.aluno_id = aluno.id and
                aluno_disciplina.disciplina_id = disciplina.id and
                matricula.ano = @ano and
                matricula.semestre = @semestre and
                aluno_disciplina.disciplina_id = @disciplina_id";
                conn.Open();

                List<AlunoNotasView> a = (conn.Query<AlunoNotasView>(sql: query, param: new {disciplina_id,ano,semestre })).ToList();

                return a;

                conn.Close();
            }
        }

    }
}
