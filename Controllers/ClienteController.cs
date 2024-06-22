using ModelBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Primeiro_MVC.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        public ActionResult Index()
        {
            StefaniniEntities entities = new StefaniniEntities();

            ViewBag.ClienteList = entities.Cliente.ToList();

            return View();
        }
        
        public ActionResult Cadastrar()
        {
            ViewBag.CarroList = ListarCarros();

            return View();
        }
        public ActionResult NovoCliente(Cliente cliente)
        {
            if (cliente.Nome == null)
            {
                ViewBag.MensagemErro = "Preencha o Nome";
            }
            else if (cliente.Email == null)
            { 
                ViewBag.MensagemErro = "Preencha o Email";
            }
            else if (cliente.IdCarro == 0)
            {
                ViewBag.MensagemErro = "Selecione um Carro";
            }

            if (ViewBag.MensagemErro == null)
            {
                StefaniniEntities entities = new StefaniniEntities();

                entities.Cliente.Add(cliente);
                entities.SaveChanges();
                
                ViewData.ModelState.Clear();

                ViewBag.MensagemSucesso = "Cliente cadastrado co sucesso!";
            }
            ViewBag.CarroList = ListarCarros();

            return View("Cadastrar");
        }
        public IList<SelectListItem> ListarCarros(int IdCarro = 0)
        {
            StefaniniEntities entities = new StefaniniEntities();

            IList<SelectListItem> carroList = new List<SelectListItem>();


            IList<Carro> carroBancoList = new List<Carro>();

            if (IdCarro != 0)
            {
                carroBancoList = entities.Carro.Where(c => c.ClienteList.Count == 0 || c.Id == IdCarro).ToList();
            }
            else
            {
                carroBancoList = entities.Carro.Where(c => c.ClienteList.Count == 0).ToList();
            }

            foreach (Carro carro in carroBancoList)
            {
                SelectListItem option = new SelectListItem();
                option.Value = carro.Id.ToString();
                option.Text = carro.Nome;

               
                carroList.Add(option);
            }
            return carroList;
        }

        public ActionResult Deletar(int[] chkCliente)
        //recebe o valor do check marcado
        {
            StefaniniEntities entities = new StefaniniEntities();

            if (chkCliente == null)
            {
                ViewBag.MensagemErro = "Selecione um Cliente.";
            }
            else
            {
                try
                {

                    foreach (int item in chkCliente)
                    {
                        Cliente cliente = entities.Cliente.Find(item);
                        entities.Cliente.Remove(cliente);
                        entities.SaveChanges();
                    }

                    ViewBag.MensagemSucesso = "Cliente deletado com sucesso!";
                }
                catch (Exception)
                {
                    ViewBag.MensagemErro = "Erro ao deletar!";

                }
            }

            ViewBag.ClienteList = entities.Cliente.ToList();

            return View("Index");

        }

       public ActionResult Editar(int Id)
        {
            StefaniniEntities entities = new StefaniniEntities();

            Cliente cliente = entities.Cliente.Find(Id);

            ViewBag.CarroList = ListarCarros(cliente.IdCarro);

            return View(cliente);

        }

        public ActionResult Gravar(Cliente cliente)
        {
         
              if (cliente.Nome == null)
            {
                ViewBag.MensagemErro = "Preencha o Nome";
            }
            else if (cliente.Email == null)
            { 
                ViewBag.MensagemErro = "Preencha o Email";
            }
            else if (cliente.IdCarro == 0)
            {
                ViewBag.MensagemErro = "Selecione um Carro";
            }

            if (ViewBag.MensagemErro == null)
            {
                StefaniniEntities entities = new StefaniniEntities();

                entities.Entry(cliente).State = EntityState.Modified;
                entities.SaveChanges();
                ViewBag.MensagemSucesso = "Cliente alterado co sucesso!";
            }

            ViewBag.CarroList = ListarCarros(cliente.IdCarro);

            return View("Editar");
        }
        
	}
}