using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;


namespace Ferreteria.Controllers
{
    public class DetalleVentaController : Controller
    {
       
        [HttpGet]
        public ActionResult Index(int id)
        {
            
            List<DetalleV> listaDetalleV = DetalleV.ListarID(id);
            return View(listaDetalleV);

        }
      
        public ActionResult AgregarDetalle(int id)
        {
           
            DetalleV detalle = new DetalleV();
            detalle.IdVenta = id;
            return View(detalle);

        }


        public ActionResult ListadoProductos()
        {
            //return View(new List<Producto>());
            return View(new List<DetalleV>());
        }

        //public ActionResult AgregarProducto(int id,int cantidad)
        //{
        //    //Obtener el producto            

        //    if (Session["ListaDetalleV"] == null)
        //    {
        //        List<DetalleV> ListaDetalleV = new List<DetalleV>();
        //        DetalleV detalleV = new DetalleV();
        //        //AgregarProducto producto = Producto.Obtener(id);
        //        detalleV.CantidadProd = cantidad;
        //        //detalleV.IdProducto = producto.IdProducto;
        //        //detalleV.Importe = producto.Importe;

        //        ListaDetalleV.Add(detalleV);
        //        Session["ListaDetalleV"] = ListaDetalleV;
        //    }
        //    else
        //    {
        //        List<DetalleV> ListaDetalleV =  (List<DetalleV>) Session["ListaDetalleV"];

        //        if(ListaDetalleV.Any(x =>x.IdProducto== id))
        //        {
        //            DetalleV DetalleVDuplicado = ListaDetalleV.Where(x => x.IdProducto == id).FirstOrDefault();
        //            DetalleVDuplicado.CantidadProd = DetalleVDuplicado.CantidadProd + cantidad;
        //            ListaDetalleV.Remove(ListaDetalleV.Where(x => x.IdProducto == id).FirstOrDefault());
        //            ListaDetalleV.Add(DetalleVDuplicado);
        //            Session["ListaDetalleV"] = ListaDetalleV;
        //        }
        //        else
        //        {
        //            DetalleV detalleV = new DetalleV();
        //            //AgregarProducto producto = Producto.Obtener(id);
        //            detalleV.CantidadProd = cantidad;
        //            //detalleV.IdProducto = producto.IdProducto;
        //            //detalleV.Importe = producto.Importe;
        //            ListaDetalleV.Add(detalleV);
        //            Session["ListaDetalleV"] = ListaDetalleV;
        //        }
        //    }
        //    return View("Index");
        //}


        //public ActionResult Editar(int? id)
        //{

        //    if (id == null)
        //    {
        //        DetalleV detallev = new DetalleV();

        //        return View(detallev);
        //    }
        //    else
        //    {
        //        // o uso el obtener pasando el id
        //        DetalleV DetalleV = DetalleV.Listar().Where(x => x.IdDetalleV == id).FirstOrDefault();
        //        return View(DetalleV);
        //    }
        //}

        [HttpPost]
        public JsonResult Editar(DetalleV detallev)
        {

            detallev.Grabar();
            Resultado resultado = new Resultado();
            resultado.EsCorrecto = true;
            resultado.Mensaje = "";
            return Json(detallev);

        }

        [HttpPost]
        public JsonResult CrearDetalle(int id)
        {
            Resultado resultado = new Resultado();
            DetalleV DetalleV = new DetalleV();

            try
            {
                DetalleV.IdVenta = id;
                DetalleV.IdProducto = Convert.ToInt32(Request.Form["IdProducto"]);
                DetalleV.CantidadProd = Convert.ToInt32(Request.Form["CantidadProd"]);         
                DetalleV.PrecioUnitario = Convert.ToDecimal(Request.Form["PrecioUnitario"]);
                DetalleV.Importe = DetalleV.CantidadProd * DetalleV.PrecioUnitario;
                DetalleV.Grabar();
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;
            }
            return Json(DetalleV);
        }

        [HttpPost]
        public JsonResult Guardar(DetalleV DetalleV)
        { 
            Resultado resultado = new Resultado();

            try
            {
                DetalleV.Grabar();

                
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
               
            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;
            } 
            return Json(DetalleV);
        }

       
        //public JsonResult Eliminar(int idProducto)
        //{
        //    try
        //    {
        //        List<DetalleV> ListaDetalleV = (List<DetalleV>)Session["ListaDetalleV"];
        //        ListaDetalleV.Remove(ListaDetalleV.Where(x => x.IdProducto == idProducto).FirstOrDefault());
        //        Session["ListaDetalleV"] = ListaDetalleV;

        //        return Json(new Resultado());
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new Resultado(ex.Message, ex.HResult));
        //    }

        //}
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                DetalleV.Eliminar(id);
                return Json(new Resultado());
            }
            catch (Exception ex)
            {
                return Json(new Resultado(ex.Message, ex.HResult));
            }

        }
    }
}

