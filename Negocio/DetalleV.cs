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
   public class DetalleV
    {
        public int? IdDetalleV { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int CantidadProd { get; set; }
        public decimal Importe { get; set; }
        public List<Venta> Venta { get; set; }
        public decimal Total { get; set; }
        public Venta venta { get; set; }

        //public Producto Producto { get; set; }

        public static List<DetalleV> Listar()
        {
            List<DetalleV> listaDetalleV = new List<DetalleV>();
            
            DataTable dt = Datos.DetallesV.Listar();


            foreach (DataRow item in dt.Rows)
            {

                listaDetalleV.Add(ArmarDatos(item));
            }


            return listaDetalleV;
        }

        //public static List<DetalleV> Buscar(int idVenta)
        //{
        //    List<DetalleV> listaDetalleV = new List<DetalleV>();

        //    DataTable dt = Datos.DetallesV.Listar();


        //    foreach (DataRow item in dt.Rows)
        //    {

        //        listaDetalleV.Add(ArmarDatos(item));
        //    }


        //    return listaDetalleV;
        //}

       

        public static List<DetalleV> ListarID(int IdVenta)
        {
            List<DetalleV> listaDetalleV = new List<DetalleV>();

            DataTable dt = Datos.DetallesV.ListarID(IdVenta);


            foreach (DataRow item in dt.Rows)
            {

                listaDetalleV.Add(ArmarDatos(item));
            }


            return listaDetalleV;
        }

        public void Grabar()
        {
            if (Validar(out string error))
            {
                if (IdDetalleV != null)
                    Modificar();
                else
                    Agregar();
            }
            else

                throw new Exception(error);

        }

        public static void Eliminar(int IdDetalleV)
        {
            Datos.Ventas.Eliminar(IdDetalleV);
        }     

        private static DetalleV ArmarDatos(DataRow dr)
        {
            DetalleV DetalleV = new DetalleV();
            DetalleV.IdDetalleV = Convert.ToInt32(dr["IdDetalleV"]);
            DetalleV.IdVenta = Convert.ToInt32(dr["IdVenta"]);
            DetalleV.IdProducto = Convert.ToInt32(dr["IdProducto"]);
            DetalleV.PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
            DetalleV.CantidadProd = Convert.ToInt32(dr["CantidadProd"]);
            DetalleV.Importe = DetalleV.CantidadProd*DetalleV.PrecioUnitario;
          
           
            //DetalleV.Producto = Producto.Obtener(Convert.ToInt32(dr["IdProducto"]));

            return DetalleV;
        }

     



        private void Modificar()
        {

            Datos.DetallesV.Modificar(IdDetalleV, IdVenta, IdProducto, CantidadProd,PrecioUnitario,Importe);

        }

        private void Agregar()
        {
            Datos.DetallesV.Agregar(IdVenta, IdProducto, CantidadProd,PrecioUnitario, Importe);
            //Producto.ReducirStock(IdProducto, CantidadProd);
        }

        private bool Validar(out string error)
        {
            error = "";

            #region VERIFICO QUE LOS CAMPOS NO ESTEEN VACIOS


           
                if (IdVenta == null)
                {
                    error += " El campo Id Venta está vacío; ";
                }
                else
                {
                    if (IdProducto == null)
                    {
                        error += " El campo Id Producto está vacío; ";
                    }
                else
                {
                    if (CantidadProd == null)
                    {
                        error += " El campo cantidad está vacío; ";
                    }

                    else
                    {
                        if (Importe == null)
                        {
                            error += " El campo importe está vacío; ";
                        }
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
    #endregion
}