using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using T3H_Cap04_P2.Models;

namespace T3H_Cap04_P2.Dados
{
    public class AlunosCRUD
    {

        // Retorna a listagem de alunos
        public static IEnumerable<Alunos> ListarAlunos()
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                return ctx.Alunos.ToList();
            }
        }

        // Retorna um relatório de alunos mais velhos
        public static IEnumerable<Alunos> ListarAlunosIdadeDesc()
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                return ctx.Alunos.OrderByDescending(a => a.Idade).ToList();
            }
        }

        // Inserir um aluno

        public static void NovoAluno(Alunos Aluno)
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                ctx.Alunos.Add(Aluno);
                ctx.SaveChanges();
            }
        }

        // buscar um aluno pelo CODIGO

        public static Alunos BuscarAlunos(int Codigo)
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                return ctx.Alunos.FirstOrDefault(
                                  a => a.Codigo.Equals(Codigo));
            }
        }

        // alterar um aluno

        public static void AlterarAluno(Alunos Alterado)
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                ctx.Entry<Alunos>(Alterado).State =
                                  EntityState.Modified;
                ctx.SaveChanges();
            }

        }

        // apagar um aluno

        public static void ApagarAluno(Alunos Apagado)
        {
            using (var ctx = new CursoAsp3HEntities())
            {
                ctx.Entry<Alunos>(Apagado).State =
                                  EntityState.Deleted;
                ctx.SaveChanges();
            }

        }
    }
}
