using KTech.VirtualStore.Domain.Entities;
using KTech.VirtualStore.Domain.Repository;
using KTech.VirtualStore.Web.Models;
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
        public int ProdutosPorPagina = 5;

        // GET: Vitrine
        //public ViewResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    _repositorio = new ProdutosRepository();
        //    ProdutosViewModel model = new ProdutosViewModel
        //    {

        //        Produtos = _repositorio.Produtos
        //        .Where(p => categoria == null || p.Categoria == categoria)
        //        .OrderBy(p => p.Nome)
        //        .Skip((pagina - 1) * ProdutosPorPagina)
        //        .Take(ProdutosPorPagina),

        //        Paginacao = new Paginacao
        //        {
        //            PaginaAtual = pagina,
        //            ItensPorPagina = ProdutosPorPagina,
        //            ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Where(p => categoria == null || p.Categoria == categoria).Count()
        //        },

        //        CategoriaAtual = categoria
        //    };

        //    return View(model);
        //}

        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            _repositorio = new ProdutosRepository();
            Produto produto = _repositorio.ObterProduto(id);
            return View(produto);
        }

        public ViewResult ListaProdutos(string categoria)
        {
            _repositorio = new ProdutosRepository();

            var model = new ProdutosViewModel();

            var rnd = new Random();

            if (categoria != null)
            {
                model.Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => rnd.Next())
                    .Take(ProdutosPorPagina).ToList();
            }

            return View(model);
        }

        [Route("Vitrine/Produto/ObterImagem/{produtoId}")]
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