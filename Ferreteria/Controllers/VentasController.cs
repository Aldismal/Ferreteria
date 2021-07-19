using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;


namespace Ferreteria.Controllers
{
    public class VentasController : Controller
    {


        //public ActionResult maestroDetalle()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Add(Venta venta)
        //{
        //    Venta  Venta = new Venta();

        //    try
        //    {
                
        //        Venta.IdCliente = 1;
        //        Venta.Fecha = DateTime.Now;
        //        Venta.Descripcion = Request.Form["Descripcion"];
        //        Venta.Grabar();
        //        foreach (var v in Venta.Listar())
        //        {
        //            Venta oventa = new Venta();
        //            oventa.IdCliente = 1;
        //            oventa.Fecha = DateTime.Now;
        //            oventa.Descripcion = Venta.Descripcion;
        //            oventa.IdVenta = Venta.IdVenta;
                    
        //        }
        //        Venta.Grabar();

        //        ViewBag.Message = "Registro insertado";
        //        return RedirectToAction("maestroDetalle");
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(venta);
        //    }

        //}



        public ActionResult Index()
        {

            return View(Venta.Listar());
        }

        public ActionResult Detalle(int id)
        {
             Venta Venta = Venta.ListarTot(id).Where(x => x.IdVenta == id).FirstOrDefault();
                return View(Venta);
        }

       


        public ActionResult IndexFinal(int id)
        {

            List<Venta> listatot = Venta.ListarTot(id);
          
            return View(listatot);
        }
        public ActionResult Informe()
        {
            return View();
        }

        public ActionResult CrearVenta(int? id)
        {
            if (id == null)
            {
                Venta Venta = new Venta();
                Venta.Fecha = DateTime.Now;
                Venta.IdCliente = 1;
                return View(Venta);
            }
            else
            {
                // o uso el obtener pasando el id
                Venta Venta = Venta.Listar().Where(x => x.IdVenta == id).FirstOrDefault();
                return View(Venta);
            }
        }

        [HttpPost]
        public JsonResult Guardar(Venta venta)
        {


            Resultado resultado = new Resultado();
            venta.Grabar();
           

            resultado.EsCorrecto = true;
            resultado.Mensaje = "";
            return Json(venta);
            //try
            //{
            //    Venta venta = new Venta();
            //    //verificara si la sessiones nula
            //    //venta.ListaDetalleV = (List<DetalleV>)Session["ListaDetalleV"];
            //    venta.Total = venta.ListaDetalleV.Sum(x => x.Importe);
            //    venta.Fecha = DateTime.Now;
            //    venta.IdCliente = 1;
            //    venta.Descripcion = "";
            //    venta.Grabar();

            //    //Session["ListaDetalleV"] = null;
            //    resultado.EsCorrecto = true;
            //    resultado.Mensaje = "";
            //}
            //catch (Exception ex)
            //{

            //    resultado.EsCorrecto = false;
            //    resultado.Mensaje = ex.Message;
            //}

            //return Json(resultado);
        }
            

        [HttpPost]
        public JsonResult CrearV()
        {
            
            Venta venta = new Venta();

            venta.IdCliente = 1;
            venta.Fecha = DateTime.Now;
            venta.Descripcion = Request.Form["Descripcion"];

            if (venta.Total != 0)
            {
                venta.Total = venta.ListaDetalleV.Sum(x => x.Importe);
            }
            else
            {
                venta.Total = Convert.ToDecimal(Request.Form["Total"]);
            }

            venta.Grabar();
            

            Resultado resultado = new Resultado();

            resultado.EsCorrecto = true;
            resultado.Mensaje = "";
            return Json(venta);
        }

        
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
               Venta.Eliminar(id);
                return Json(new Resultado());
            }
            catch (Exception ex)
            {
                return Json(new Resultado(ex.Message, ex.HResult));
            }

        }


    }

    

}
