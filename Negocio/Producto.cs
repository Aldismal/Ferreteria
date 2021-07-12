using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public int? IdProducto { get; set; }

        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Tamaño { get; set; }

        public decimal PrecioUnitario { get; set; }      
       public string Ubicacion  { get; set; }


        public static List<Producto> Listar()
        {
            List<Producto> listaProductos = new List<Producto>();

            DataTable dt = Datos.Ventas.Listar();


            foreach (DataRow item in dt.Rows)
            {

                listaProductos.Add(ArmarDatos(item));
            }


            return listaProductos;
        }

        private static Producto ArmarDatos(DataRow dr)
        {
            Producto producto = new Producto();
            producto.IdProducto = Convert.ToInt32(dr["IdVenta"]);
            producto.IdCategoria = Convert.ToInt32(dr["IdVenta"]);
            producto.Nombre = dr["Descripcion"].ToString();
            producto.Descripcion = dr["Descripcion"].ToString();
            producto.Tamaño = Convert.ToDecimal(dr["Total"]);
            producto.PrecioUnitario = Convert.ToDecimal(dr["Total"]);
            producto.Ubicacion = dr["Descripcion"].ToString();

            return producto;
        }

    }
}
