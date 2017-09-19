using KTech.VirtualStore.Domain.Entities;
using KTech.VirtualStore.Domain.Repository;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTech.VirtualStore.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepository _repositorio;

        public ActionResult Index()
        {
            _repositorio = new ProdutosRepository();
            var produtos = _repositorio.Produtos;

            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutosRepository();
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid)
            {
                if(image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem, 0, image.ContentLength);
                }

                _repositorio = new ProdutosRepository();
                _repositorio.Salvar(produto);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", produto.Nome);

                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }

        //[HttpPost]
        //public ActionResult Excluir(int produtoId)
        //{
        //    _repositorio = new ProdutosRepository();

        //    Produto prod = _repositorio.Excluir(produtoId);

        //    if(prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} excluído com sucesso", prod.Nome);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            string mensagem = string.Empty;
            _repositorio = new ProdutosRepository();

            Produto prod = _repositorio.Excluir(produtoId);

            if (prod != null)
            {
                mensagem = string.Format("{0} excluído com sucesso", prod.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }

        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepository();
            Produto prod = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }
            return null;
        }
    }
}