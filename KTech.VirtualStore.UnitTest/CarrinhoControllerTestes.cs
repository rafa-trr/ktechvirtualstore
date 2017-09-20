using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KTech.VirtualStore.Domain.Entities;
using KTech.VirtualStore.Web.Controllers;
using System.Linq;
using System.Web.Mvc;
using KTech.VirtualStore.Web.Models;

namespace KTech.VirtualStore.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinhoViaController()
        {

            //Arrange
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController();

            //Act
            controller.Adicionar(carrinho, 2, "");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);

            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);
        }

        [TestMethod]
        public void TestarReturnUrl()
        {
            #region [ Arrange ]
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();
            #endregion

            #region [ Act ]
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");
            #endregion

            #region [ Assert ]
            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
            #endregion
        }

        [TestMethod]
        public void PossoVerOConteudoDoCarrinho()
        {
            #region [ Arrange ]
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();
            #endregion

            #region [ Act ]
            CarrinhoViewModel resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;
            #endregion

            #region [ Assert ]
            Assert.AreSame(resultado.Carrinho, carrinho);

            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
            #endregion
        }
    }
}
