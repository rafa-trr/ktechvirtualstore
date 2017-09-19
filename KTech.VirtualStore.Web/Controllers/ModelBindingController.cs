using KTech.VirtualStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTech.VirtualStore.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar([Bind(Include ="Nome")] Produto prod)
        {
            var produto = new Produto();

            ValidateModel(produto);

            //produto.Nome = prod.Nome;
            //produto.Preco = prod.Preco;

            return RedirectToAction("Index");
        }
    }
}