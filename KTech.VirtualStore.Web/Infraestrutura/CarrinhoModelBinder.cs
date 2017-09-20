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
            Carrinho carrinho = null;

            if(controllerContext.HttpContext.Session  != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }
                        
            if(carrinho == null)
            {
                carrinho = new Carrinho();

                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            return carrinho;
        }
    }
}