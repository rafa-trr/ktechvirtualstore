using KTech.VirtualStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTech.VirtualStore.Web.Infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Obter o carrinho da sessão

            Carrinho carrinho = null;

            if(controllerContext.HttpContext.Session  != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }

            // Crio o carrinho se não tenho a sessão
            if(carrinho == null)
            {
                carrinho = new Carrinho();

                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            // Retorno o carrinho

            return carrinho;
        }
    }
}