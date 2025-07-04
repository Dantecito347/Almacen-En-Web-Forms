
using Parcial_Nº2___Almacen.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Controlador
{
    public class MenuAlimentosControlador
    {
        private BaseDeDatos database = new BaseDeDatos();

        public DataTable ObtenerAlimentos()
        {
            string query = "SELECT ProductosID, Nombre, Precio, Stock FROM Productos_Alimentos";
            return database.Select(query);

        }

        public DataTable ObtenerBebidas()
        {
            string query = "SELECT ID, Nombre, Precio, Stock FROM Productos_Bebidas";
            return database.Select(query);
        }

        public DataTable ObtenerLacteos()
        {
            string query = "SELECT ID, Nombre, Precio, Stock FROM Productos_Lacteos";
            return database.Select(query);
        }
    }
}