﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Modelo
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}