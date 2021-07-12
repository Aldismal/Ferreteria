using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;


namespace Ferreteria.Controllers
{
    public class Productos : Controller
    {

        public ActionResult ProductosFerreteria()
        {
            return View(Productos.listar);
        }

        public ActionResult DetalleVenta(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Venta Venta = Venta.ObtenerDetalle(id);

            if (Venta == null)
            {
                return HttpNotFound();
            }

            return View(Venta);

        }
        public ActionResult CrearVenta()
        {
            return View();
        }

        public ActionResult Delete(int Id)
        {
            Venta.Eliminar(Id);
            return View("Index");
        }

        [HttpGet]
        public ActionResult EditarVenta(int id)
        {        
            // o uso el obtener pasando el id
          Venta Venta = Venta.Listar().Where(x => x.IdVenta == id).FirstOrDefault();
          return View(Venta);
        }
        

        #region HttpPOST

        [HttpPost]
        public ActionResult Guardar()
        {
            Venta Venta = new Venta();

            Venta.Descripcion = Request.Form["Descripcion"].ToString();
            Venta.Fecha = Convert.ToDateTime(Request.Form["Fecha"]);
            Venta.Total = Convert.ToDecimal(Request.Form["Total"]);
            
            Venta.Grabar();

            return View("Index");
        }


        [HttpPost]

        public ActionResult EditarVenta(Venta Venta)
        {
            Venta.Grabar();
            return View("Index");
        }

    }

    

}
#endregion