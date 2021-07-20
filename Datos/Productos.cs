using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class Productos
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDesarrollo"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Productos_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    // cmd.Parameters.Add(new SqlParameter("@IdSitio", id));

                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }


                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de productos: " + ex.Message);
            }
        }


        public static void Modificar(int? Id_Producto, string nombre_producto, double precio_producto, string descripcion, string estado)
        {
            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDesarrollo"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Productos_Modificar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Id_Producto", Id_Producto));
                    cmd.Parameters.Add(new SqlParameter("@Nombre_producto", nombre_producto));
                    cmd.Parameters.Add(new SqlParameter("@Precio_producto ", precio_producto));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion ", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Estado ", estado));


                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de productos: " + ex.Message);
            }

        }

        public static int Agregar(string nombre_producto, double precio_producto, string descripcion, string estado)
        {
            try
            {
                int id = 0;

                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDesarrollo"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Productos_Insertar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado

                    cmd.Parameters.Add(new SqlParameter("@Nombre_producto", nombre_producto));
                    cmd.Parameters.Add(new SqlParameter("@Precio_producto ", precio_producto));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion ", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Estado ", estado));

                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    id = Convert.ToInt32(dt.Rows[0][0]);
                }


                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de productos: " + ex.Message);
            }

        }

        public static void Eliminar(int id_Producto)
        {
            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDesarrollo"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Productos_Eliminar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado

                    cmd.Parameters.Add(new SqlParameter("@Id_Producto", id_Producto));

                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();


                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de productos: " + ex.Message);
            }

        }



    }

}

