using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    class Producto
    {

        public int? Id_Producto { get; set; }

        public string Nombre_producto { get; set; }

      
        public double Precio_producto { get; set; }

       
        public string Descripcion { get; set; }

        public string Estado { get; set; }



        #region Metodo Publico
        public static List<Producto> Listar()
        {
            List<Producto> ListaProductos = new List<Producto>();
            
            DataTable dt = Datos.Productos.Listar();

            foreach (DataRow item in dt.Rows)
            {

                ListaProductos.Add(ArmadoDeDatos(item));

            }

            return ListaProductos;
        }





        public void Grabar()
        {
            if (Validar(out string error))
            {
                if (Id_Producto != null)
                {
                    Modificar();
                }
                else
                {
                    Agregar();
                }


            }
            else
                throw new Exception(error);



        }

        #endregion


        #region Metodo Privados

        public static void Eliminar(int id)
        {
            Datos.Productos.Eliminar(id);
        }



        private static Producto ArmadoDeDatos(DataRow dr)
        {
            Producto Producto = new Producto();

            Producto.Id_Producto = Convert.ToInt32(dr["Id_Producto"]);
            Producto.Nombre_producto = dr["Nombre_producto"].ToString();
            Producto.Precio_producto = Convert.ToDouble(dr["Precio_producto"]);
            Producto.Descripcion = dr["Descripcion"].ToString();
            Producto.Estado = dr["Estado"].ToString();

            return Producto;
        }

        private void Modificar()
        {          
           
            Datos.Productos.Modificar(Id_Producto, Nombre_producto, Precio_producto, Descripcion, Estado);
        }

        private int Agregar()
        {

            return Datos.Productos.Agregar(Nombre_producto, Precio_producto, Descripcion, Estado);
        }


        private bool Validar(out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(Nombre_producto))

                error = "El campo nombre de producto se encuentra vacio ;";

            if (Precio_producto.ToString().Length == 0)

                error += "El campo Precio del producto se encuentra vacio ;";

            if (string.IsNullOrEmpty(Descripcion))

                error += "El campo Descripcion se encuentra vacio ;";

            if (string.IsNullOrEmpty(Estado))

                error += "El campo Estado se encuentra vacio ;";



            if (string.IsNullOrEmpty(error))

                return true;
            else
                return false;

        }






        #endregion
    }
}
