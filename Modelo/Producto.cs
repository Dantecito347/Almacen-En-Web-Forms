using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Modelo
{
    public class Producto
    {
        public int ProductosID { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
    }
}