using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Resultado
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }

        public Object Codigo { get; set; }

        public Resultado(string mensaje = "", int codigo = 0)
        {
            Codigo = codigo;
            EsCorrecto = mensaje == "";
            Mensaje = mensaje;
        }

    }
}
