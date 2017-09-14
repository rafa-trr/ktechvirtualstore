using KTech.VirtualStore.Domain.Entities;
using KTech.VirtualStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KTech.VirtualStore.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepository _repositorio;
        
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepository();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if(admin != null)
                {
                    if(!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("", "Senha não confere");                        
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);
                        else
                            return Redirect("/Administrativo/Produto/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Administrador não cadastrado");
                }
            }

            return View(administrador);            
        }
    }
}