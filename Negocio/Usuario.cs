using Negocio;
using Negocio.Enumerables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Negocio.Enumerables.Usuario;

namespace Negocio
{
    public class Usuario
    {
        public int? IdUsuario { get; set; }
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public int TipoUsuario { get; set; }
        public TipoPermisos TipoPermisos { get; set; }

        public List<Menu> ListaMenu { get; set; }

        //public TipoUsuario TipoUsuarios { get; set; }


        #region Metodos publicos


        public static Usuario Obtener(string Email, string Clave)
        {
            DataTable dt = Datos.Usuarios.Obtener(Email, Clave);
            Usuario usuario = new Usuario();
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existe Usuarios con los datos ingresados");
            }
        }




        #endregion

        #region Metodos Privados
        private static Usuario ArmarDatos(DataRow dr)
        {
            Usuario usuario = new Usuario();

            usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            usuario.IdPermiso = Convert.ToInt32(dr["IdPermiso"]);
            usuario.Nombre = dr["Nombre"].ToString();
            usuario.Apellido = dr["Apellido"].ToString();
            usuario.Email = dr["Email"].ToString();
            usuario.Direccion = dr["Direccion"].ToString();
            usuario.Clave = dr["Clave"].ToString();
            usuario.TipoPermisos = (TipoPermisos)(Convert.ToInt32(dr["IdPermiso"]));
            usuario.ListaMenu = Menu.ListarPorUsuario(usuario.IdUsuario.Value);

            return usuario;
        }



        #endregion


    }
}
