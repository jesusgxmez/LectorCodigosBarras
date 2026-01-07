using System;
using System.Collections.Generic;
using System.Text;

namespace LectorCodigosBarras.MVVM.Models
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
