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
    public class Ventas
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
                    SqlCommand cmd = new SqlCommand("listar", cn);

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
                throw new Exception("Error al obtener la lista de Ventas: " + ex.Message);
            }

        }

        

        public static int Modificar(int? IdVenta, string Descripcion, DateTime Fecha, decimal Total)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("EditarVenta", cn);


                cmd.CommandType = CommandType.StoredProcedure;

                //agrego el valor al procedimiento almacenado

                cmd.Parameters.Add(new SqlParameter("@IdVenta", IdVenta));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                cmd.Parameters.Add(new SqlParameter("@Total", Total));

                var dataReader = cmd.ExecuteReader();
            }

            return id;

        }

        public static int Agregar(string Descripcion, DateTime Fecha, decimal Total)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {

                DataTable dt = new DataTable();
                cn.Open();

                SqlCommand cmd = new SqlCommand("InsertarVenta", cn);


                cmd.CommandType = CommandType.StoredProcedure;

                //agrego el valor al procedimiento almacenado


                cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                cmd.Parameters.Add(new SqlParameter("@Total", Total));


                var dataReader = cmd.ExecuteReader();

            }

            return id;
        }

        public static void Eliminar(int IdVenta)
        {
            try
            {

                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("EliminarVenta", cn);


                    cmd.CommandType = CommandType.StoredProcedure;

                    //agrego el valor al procedimiento almacenado

                    cmd.Parameters.Add(new SqlParameter("@IdVenta", IdVenta));

                    var dataReader = cmd.ExecuteReader();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Venta: " + ex.Message);
            }

        }


        public static DataTable ObtenerDetalle(int id)
        {


            var dataTable = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                SqlCommand cmd = new SqlCommand("ObtenerDetalle", cn);

                // 2. Especifico el tipo de Comando
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. Agrego el Valor al Procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@IdVenta", id));


                // Ejecuto el comando y asigo el valor al DataReader
                var dataReader = cmd.ExecuteReader();

                dataTable.Load(dataReader);
            }

            return dataTable;

        }

        //public static DataTable ObtenerDetalleID(int id)
        //{


        //    var dataTable = new DataTable();

        //    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
        //    {
        //        cn.Open();

        //        // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
        //        SqlCommand cmd = new SqlCommand("ObtenerDetalleId", cn);

        //        // 2. Especifico el tipo de Comando
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // 3. Agrego el Valor al Procedimiento almacenado
        //        cmd.Parameters.Add(new SqlParameter("@IdVenta", id));


        //        // Ejecuto el comando y asigo el valor al DataReader
        //        var dataReader = cmd.ExecuteReader();

        //        dataTable.Load(dataReader);
        //    }

        //    return dataTable;

        //}




    }
}
    
