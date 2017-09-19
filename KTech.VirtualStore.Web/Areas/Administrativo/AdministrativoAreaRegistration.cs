using System.Web.Mvc;

namespace KTech.VirtualStore.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}",
                new { controller="Produto", action = "Index", id = UrlParameter.Optional },
                new[] { "KTech.VirtualStore.Web.Areas.Administrativo.Controllers" }
            );


            context.MapRoute(
                name: "ObterImagem",
                url: "Administrativo/Produto/ObterImagem/{produtoId}",
                defaults: new { controller = "Produto", action = "ObterImagem", produtoId = UrlParameter.Optional },
                namespaces: new[] { "KTech.VirtualStore.Web.Areas.Administrativo.Controllers" });
        }
    }
}