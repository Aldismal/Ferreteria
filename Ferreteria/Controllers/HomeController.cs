using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Negocio.Usuario u = new Negocio.Usuario();

            if (Session["Usuario"] != null)
            {
                u = (Negocio.Usuario)Session["Usuario"];

                //si usuario correcto, buscar el menu que le corresponde
                List<Menu> listamenu = new List<Menu>();
                listamenu = Negocio.Menu.ListarPorUsuario(Convert.ToInt32(u.IdUsuario));
                u.ListaMenu = listamenu;
            }
            else
            {
                throw new Exception("No se encontró el usuario");
            }         
            
            return View(u);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}