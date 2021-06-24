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
    public class Menu
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Menu_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    

                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }


                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de personas: " + ex.Message);
            }
        }

        public static DataTable ListarPorUsuario(int IdUsuario)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("Menu_ListarPorUsuario", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));

                    // Ejecuto el comando y asigno el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }


                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de Menu por Usuarios: " + ex.Message);
            }
        }

    }
}
