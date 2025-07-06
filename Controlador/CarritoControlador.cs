using Parcial_Nº2___Almacen.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Controlador
{
    public class CarritoControlador
    {
        private BaseDeDatos database = new BaseDeDatos();

        public DataTable ObtenerCarrito()
        {
            string query = "SELECT NombreProducto, Precio, Cantidad, (Precio * Cantidad) AS Subtotal  FROM Carrito";
            return database.Select(query);
        }

        public decimal ObtenerCarritoConTotal()
        {
            using (SqlConnection conn = new SqlConnection(database.connectionString))
            using (SqlCommand cmd = new SqlCommand("ObtenerCarritoConTotal", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }
    }
}