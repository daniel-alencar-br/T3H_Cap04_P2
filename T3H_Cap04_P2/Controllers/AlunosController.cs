using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using T3H_Cap04_P2.Dados;
using T3H_Cap04_P2.Models;

namespace T3H_Cap04_P2.Controllers
{
    public class AlunosController : Controller
    {
        // GET: Alunos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            try
            {
                return View(AlunosCRUD.ListarAlunos());
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        public ActionResult ListarIdade()
        {
            try
            {
                return View(AlunosCRUD.ListarAlunosIdadeDesc());
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Alunos Novo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                AlunosCRUD.NovoAluno(Novo);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        // função interna que buscará um aluno (p/ todas operações)
        private ActionResult BuscarAluno(int Codigo, string Operacao)
        {
            try
            {
                var InfoAluno = AlunosCRUD.BuscarAlunos(Codigo);
                return View(Operacao, InfoAluno);
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Alterar(int Codigo)
        {
            return BuscarAluno(Codigo, "Alterar");
        }

        [HttpGet]
        public ActionResult Pesquisar(int Codigo)
        {
            return BuscarAluno(Codigo, "Pesquisar");
        }

        [HttpGet]
        public ActionResult Apagar(int Codigo)
        {
            return BuscarAluno(Codigo, "Apagar");
        }

        [HttpPost]
        public ActionResult Alterar(Alunos Novo)
        {
            try
            {
                AlunosCRUD.AlterarAluno(Novo);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

        [HttpPost]
        public ActionResult Apagar(Alunos Novo)
        {
            try
            {
                AlunosCRUD.ApagarAluno(Novo);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.MensagemErro = erro.Message;
                return View("_Erro");
            }
        }

    }
}




