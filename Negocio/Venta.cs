using Negocio;
using Negocio.Enumerables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class Venta
    {
        public int? IdVenta { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public decimal PrecioUnitario { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public int IdProducto { get; set; }

        public decimal Importe { get; set; }
        public static List<Venta> Listar()
        {
            List<Venta> listaVentas = new List<Venta>();

            DataTable dt = Datos.Ventas.Listar();


            foreach (DataRow item in dt.Rows)
            {

                listaVentas.Add(ArmarDatos(item));
            }


            return listaVentas;
        }

       

        public static Venta ObtenerDetalle(int id)
        {

            DataTable dt = Datos.Ventas.ObtenerDetalle(id);
            return ArmarDatosDetalle(dt.Rows[0]);
        }

        //public static Venta ObtenerDetalleID(int id)
        //{

        //    DataTable dt = Datos.Ventas.ObtenerDetalle(id);
        //    return ArmarDatosDetalle(dt.Rows[0]);
        //}

        public void Grabar()
        {
            string error;
            if (Validar(out error))
            {
                if (IdVenta != null)
                    Modificar();
                else
                    Agregar();
            }
            else

                throw new Exception(error);

        }

        public static void Eliminar(int IdVenta)
        {
            Datos.Ventas.Eliminar(IdVenta);
        }


        private static Venta ArmarDatos(DataRow dr)
        {
            Venta Venta = new Venta();
            Venta.IdVenta= Convert.ToInt32(dr["IdVenta"]);
            Venta.Descripcion = dr["Descripcion"].ToString();
            Venta.Fecha = Convert.ToDateTime(dr["Fecha"]);
            Venta.Total = Convert.ToDecimal(dr["Total"]);

            return Venta;
        }

        private static Venta ArmarDatosDetalle(DataRow dr)
        {
            Venta Venta = new Venta();
            Venta.IdVenta = Convert.ToInt32(dr["IdVenta"]);
            Venta.Nombre= dr["Nombre"].ToString();
            Venta.IdProducto = Convert.ToInt32(dr["IdProducto"]);
            Venta.Cantidad = Convert.ToInt32(dr["Cantidad"]);
            Venta.Descripcion = dr["Descripcion"].ToString();
            Venta.PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
            Venta.Importe = Convert.ToDecimal(dr["Importe"]);
            Venta.Total = Convert.ToDecimal(dr["Total"]);

            return Venta;
        }

        private void Modificar()
        {

            Datos.Ventas.Modificar(IdVenta, Descripcion, Fecha, Total);

        }

        private void Agregar()
        {
            Datos.Ventas.Agregar(Descripcion, Fecha, Total);
        }

        private bool Validar(out string error)
        {
            error = "";

            #region VERIFICO QUE LOS CAMPOS NO ESTEEN VACIOS


            if (string.IsNullOrEmpty(Descripcion))
            {
                error = "El campo Descripcion está vacío; ";
            }
            else
            {
                if (Fecha == null)
                {
                    error += " El campo Fecha está vacío; ";
                }
                else
                {
                    if (Total == null)
                    {
                        error += " El campo Total está vacío; ";
                    }



                }
            }


            if (string.IsNullOrEmpty(error))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
#endregion