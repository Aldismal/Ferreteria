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
   public class DetallesV
    {

        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    //Se crea el objeto sqlcommand y asigno el nombre del procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("ListarDetalleV", cn);

                    // Espicifico el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuto el comando y asigno el valor al datareader
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }

            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Detalle de Ventas: " + ex.Message);
            }

        }

        

        public static DataTable ListarID(int IdVenta)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    //Se crea el objeto sqlcommand y asigno el nombre del procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("ObtenerId", cn);

                    // Espicifico el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdVenta", IdVenta));

                    //Ejecuto el comando y asigno el valor al datareader
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }

            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Detalle de Ventas: " + ex.Message);
            }
        }

        public static int Modificar(int? IdDetalleV, int IdVenta, int IdProducto, int CantidadProd,decimal PrecioUnitario, decimal Importe)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("EditarVenta", cn);


                cmd.CommandType = CommandType.StoredProcedure;

                //agrego el valor al procedimiento almacenado

                cmd.Parameters.Add(new SqlParameter("@IdDetalleV", IdDetalleV));
                cmd.Parameters.Add(new SqlParameter("@IdVenta", IdVenta));
                cmd.Parameters.Add(new SqlParameter("@IdProducto", IdProducto));
                cmd.Parameters.Add(new SqlParameter("@CantidadProd", CantidadProd));
                cmd.Parameters.Add(new SqlParameter("@PrecioUnitario", PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@Importe", Importe));

                var dataReader = cmd.ExecuteReader();
            }

            return id;

        }

        public static int Agregar(int IdVenta, int IdProducto, int CantidadProd,decimal PrecioUnitario, decimal Importe)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {

                DataTable dt = new DataTable();
                cn.Open();

                SqlCommand cmd = new SqlCommand("InsertarDetalleV", cn);


                cmd.CommandType = CommandType.StoredProcedure;

                //agrego el valor al procedimiento almacenado


                cmd.Parameters.Add(new SqlParameter("@IdVenta", IdVenta));
                cmd.Parameters.Add(new SqlParameter("@IdProducto", IdProducto));
                cmd.Parameters.Add(new SqlParameter("@CantidadProd", CantidadProd));
                cmd.Parameters.Add(new SqlParameter("@PrecioUnitario", PrecioUnitario));
                cmd.Parameters.Add(new SqlParameter("@Importe", Importe));

                var dataReader = cmd.ExecuteReader();

            }

            return id;
        }

        public static void Eliminar(int IdDetalleV)
        {
            try
            {

                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("EliminarDetalleV", cn);


                    cmd.CommandType = CommandType.StoredProcedure;

                    //agrego el valor al procedimiento almacenado

                    cmd.Parameters.Add(new SqlParameter("@IdDetalleV", IdDetalleV));

                    var dataReader = cmd.ExecuteReader();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Detalle Venta: " + ex.Message);
            }

        }


    }
}
