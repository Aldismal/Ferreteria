using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;


namespace Ferreteria.Controllers
{
    public class UsuariosController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Validar()
        {
            Session["Usuario"] = Usuario.Obtener(Request.Form["Email"].ToString(), Request.Form["Clave"].ToString());

            if (Session["Usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}