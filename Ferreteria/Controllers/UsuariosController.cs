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
            Session["Error"] = "";  


            try  //intento obtener el usuario
            {
                Session["Usuario"] = Usuario.Obtener(Request.Form["Email"].ToString(), Request.Form["Clave"].ToString());
            }
            catch (Exception ex)  //si no lo encontro
            {
                //devolver mensaje
                if (ex.Message == "No existe Usuarios con los datos ingresados")
                {      
                    Session["Error"] = "No se encontró el usuario";
                    return View("Login");
                }
                else  //si hubo otro error, redireccionar a la vista del error
                {
                    return RedirectToAction("Error", "Home");
                }
            }
           
            
            return RedirectToAction("Index", "Home");

        }



        [HttpPost]
        public JsonResult ValidarConAjax()
        {
            MensajeRetorno respuesta = new MensajeRetorno();
            respuesta.Mensaje = "";

            try  //intento obtener el usuario
            {
                Session["Usuario"] = Usuario.Obtener(Request.Form["Email"].ToString(), Request.Form["Clave"].ToString());
            }
            catch (Exception ex)  //si no lo encontro
            {
                //devolver mensaje
                if (ex.Message == "No existe Usuarios con los datos ingresados")
                {
                    respuesta.Mensaje = "No se encontró el usuario";
                }
                else  //si hubo otro error
                {
                    respuesta.Mensaje = ex.Message;
                }
            }


            return Json(respuesta, JsonRequestBehavior.AllowGet);

        }



        class MensajeRetorno
        {
            public string Mensaje { get; set; }
        }
    }
}