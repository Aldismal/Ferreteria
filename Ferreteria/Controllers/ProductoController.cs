using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Ferreteria.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {

            List<Producto> ListaProductos = Producto.Listar();

            return View(ListaProductos);
        }

        [HttpGet]
        public ActionResult Edicion(int? id)
        {
           
            try
            {

                if (id == null)
                {
                    return View(new Producto());
                }
                else
                {
                    Producto usuario = Producto.Listar().Where(x => x.Id_Producto == id).FirstOrDefault();
                    return View(usuario);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Producto());
        }

        [HttpPost]
        public JsonResult Guardar(Producto producto)
        {
            try

            {
                producto.Grabar();
                return Json(new Resultado());
            }
            catch (Exception ex)
            {
                return Json(new Resultado(ex.Message, ex.HResult));
            }
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                Producto.Eliminar(id);
                return Json(new Resultado());
            }
            catch (Exception ex)
            {
                return Json(new Resultado(ex.Message, ex.HResult));
            }
        }

    }
}
