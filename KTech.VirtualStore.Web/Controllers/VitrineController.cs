using KTech.VirtualStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTech.VirtualStore.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepository _repositorio;
        public int ProdutosPorPagina = 3;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepository();
            var produtos = _repositorio.Produtos
                .OrderBy(p => p.Nome)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);

            return View(produtos);
        }
    }
}