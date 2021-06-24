using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; }
      


        #region Metodos publicos
        public static List<Menu> Listar()
        {
            List<Menu> listaMenu = new List<Menu>();

            foreach (DataRow item in Datos.Menu.Listar().Rows)
            {
                listaMenu.Add(ArmarDatos(item));


            }

            return listaMenu;
        }

        public static List<Menu> ListarPorUsuario(int IdUsuario)
        {
            List<Menu> listaMenu = new List<Menu>();

            foreach (DataRow item in Datos.Menu.ListarPorUsuario(IdUsuario).Rows)
            {
                listaMenu.Add(ArmarDatos(item));


            }

            return listaMenu;
        }


        #endregion

        #region Metodos Privados
        private static Menu ArmarDatos(DataRow dr)
        {
            Menu menu = new Menu();

            menu.IdMenu = Convert.ToInt32(dr["IdMenu"]);
            menu.Descripcion = dr["Descripcion"].ToString();
            menu.Controlador = dr["Controlador"].ToString();
            menu.Accion = dr["Accion"].ToString();
            menu.Activo = Convert.ToBoolean(dr["Activo"]);
            

            return menu;
        }



        #endregion


    }
}