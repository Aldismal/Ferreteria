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
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleV> ListaDetalleV { get; set; }

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

        public static List<Venta> ListarTot(int IdVenta)
        {
            List<Venta> listaTot = new List<Venta>();

            DataTable dt = Datos.Ventas.ListarTot(IdVenta);


            foreach (DataRow item in dt.Rows)
            {

                listaTot.Add(ArmarDatosTot(item));
              

            }

            
            return listaTot;
        }


        public void Grabar()
        {
            try
            {
                if (Validar(out string error))
                {
                    if (IdVenta.HasValue)
                        Modificar();
                    else
                        Agregar();
                }
                else

                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void Eliminar(int IdVenta)
        {
            Datos.Ventas.Eliminar(IdVenta);
        }

        private static Venta ArmarDatos(DataRow dr)
        {
            Venta Venta = new Venta();
            Venta.IdVenta = Convert.ToInt32(dr["IdVenta"]);
            Venta.IdCliente = Convert.ToInt32(dr["IdCliente"]);
            Venta.Descripcion = dr["Descripcion"].ToString();
            Venta.Fecha = Convert.ToDateTime(dr["Fecha"]);
            //Venta.Total = Venta.ListaDetalleV.Sum(x => x.Importe);
            Venta.Total = Convert.ToDecimal(dr["Total"]);

            //Venta.ListaDetalleV = DetalleV.Buscar(Convert.ToInt32(dr["IdVenta"]));

            return Venta;
        }

        private static Venta ArmarDatosTot(DataRow dr)
        {
            Venta Venta = new Venta();
            Venta.IdVenta = Convert.ToInt32(dr["IdVenta"]);
            Venta.IdCliente = Convert.ToInt32(dr["IdCliente"]);
            Venta.Descripcion = dr["Descripcion"].ToString();
            Venta.Fecha = Convert.ToDateTime(dr["Fecha"]);
            Venta.Total = Convert.ToDecimal(dr["Total"]);
            

            //Venta.ListaDetalleV = DetalleV.Buscar(Convert.ToInt32(dr["IdVenta"]));

            return Venta;
        }


        private void Modificar()
        {

            try
            {
                Datos.Ventas.Modificar(IdVenta, IdCliente, Descripcion, Fecha, Total);

                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        private void Agregar()
        {
            try
            {
                /*int idVenta =*/ Datos.Ventas.Agregar(Descripcion, IdCliente, Fecha, Total);
               

                //foreach (var item in this.ListaDetalleV)
                //{
                //    item.IdVenta = idVenta;
                //    item.Grabar();
                //}
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

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