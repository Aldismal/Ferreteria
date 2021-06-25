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
        public ActionResult Index(string Email, string Clave)
        {
            Negocio.Usuario u = new Negocio.Usuario();
            u.Email = Email;
            u.Clave = Clave;
            u.Nombre = "Gustavo";
            u.TipoPermisos = Negocio.Enumerables.Usuario.TipoPermisos.Administrador;

            //validar usuario


            //si usuario correcto, buscar el menu que le corresponde
            List<Menu> listamenu = new List<Menu>();

            Menu m1 = new Menu();
            m1.Accion = "Productos";
            Menu m2 = new Menu();
            m2.Accion = "Ventas";
            Menu m3 = new Menu();
            m3.Accion = "Gastos";

            listamenu.Add(m1);
            listamenu.Add(m2);
            listamenu.Add(m3);

            u.ListaMenu = listamenu;

            
            
            //listar el menu del usuario
            
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