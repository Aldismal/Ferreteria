using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Producto
    {

        public int? Id_Producto { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre del producto"), MaxLength(30)]
        [StringLength(100)]
        [Display(Name = "Producto")]
        public string Nombre_producto { get; set; }

        [Required(ErrorMessage = "Ingrese el precio del producto")]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public double Precio_producto { get; set; }

        [Required(ErrorMessage = "Ingrese la descripcion del producto")]
        [StringLength(100)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        public string Estado { get; set; }


    }
}
