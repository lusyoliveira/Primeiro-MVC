using ModelBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Primeiro_MVC.Controllers
{
    public class UnidadeController : Controller
    {
        //
        // GET: /Unidade/
        public ActionResult Index()
        {
            StefaniniEntities entities = new StefaniniEntities();

            ViewBag.UnidadeList = entities.Unidade.ToList();

            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult NovaUnidade(Unidade unidade)
        {

            if (unidade.Nome == null)
            {
                ViewBag.MensagemErro = "Preencha o Nome";
            }
            else if (unidade.Cidade == null)
            {
                ViewBag.MensagemErro = "Preencha o Email";
            }
            else if (unidade.Estado == null)
            {
                ViewBag.MensagemErro = "Selecione um Carro";
            }

            if (ViewBag.MensagemErro == null)
            {
                StefaniniEntities entities = new StefaniniEntities();

                entities.Unidade.Add(unidade);
                entities.SaveChanges();

                ViewData.ModelState.Clear();

                ViewBag.MensagemSucesso = "Cliente cadastrado co sucesso!";
            }

            return View("Cadastrar");
        }

        public ActionResult Deletar(int[] chkUnidade)
        //recebe o valor do check marcado
        {
            StefaniniEntities entities = new StefaniniEntities();

            if (chkUnidade == null)
            {
                ViewBag.MensagemErro = "Selecione uma unidade.";
            }
            else
            {
                try
                {

                    foreach (int item in chkUnidade)
                    {
                        Unidade unidade = entities.Unidade.Find(item);
                        entities.Unidade.Remove(unidade);
                        entities.SaveChanges();
                    }

                    ViewBag.MensagemSucesso = "Cliente deletado com sucesso!";
                }
                catch (Exception)
                {
                    ViewBag.MensagemErro = "Erro ao deletar!";

                }
            }

            ViewBag.UnidadeList = entities.Unidade.ToList();

            return View("Index");

        }

        public ActionResult Editar(int Id)
        {
            StefaniniEntities entities = new StefaniniEntities();

            Unidade unidade = entities.Unidade.Find(Id);

            //ViewBag.CarroList = ListarCarros(cliente.IdCarro);

            return View(unidade);

        }

        public ActionResult Gravar(Unidade unidade)
        {

            if (unidade.Nome == null)
            {
                ViewBag.MensagemErro = "Preencha o Nome";
            }
            else if (unidade.Estado == null)
            {
                ViewBag.MensagemErro = "Preencha o Email";
            }
            else if (unidade.Cidade == null)
            {
                ViewBag.MensagemErro = "Selecione um Carro";
            }

            if (ViewBag.MensagemErro == null)
            {
                StefaniniEntities entities = new StefaniniEntities();

                entities.Entry(unidade).State = EntityState.Modified;
                entities.SaveChanges();
                ViewBag.MensagemSucesso = "Cliente alterado co sucesso!";
            }

            ViewBag.CarroList = ListarCarros(unidade.IdCarro);

            return View("Editar");
        }
	}
}

