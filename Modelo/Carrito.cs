using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Modelo
{
    public class Carrito
    {
        public int ID { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}