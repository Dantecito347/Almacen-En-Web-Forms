// Controlador/CarritoControlador.cs (Versión Corregida)
using Parcial_Nº2___Almacen.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Parcial_Nº2___Almacen.Controlador
{
    public class CarritoControlador
    {
        private BaseDeDatos database = new BaseDeDatos();

        // Controlador/CarritoController.cs (Versión modificada para stock inmediato)

        public void AgregarAlCarrito(int productoId, string nombre, decimal precio, int cantidad)
        {
            // 1. Agregar al carrito
            string spAgregar = "dbo.AgregarProductoAlCarrito";
            SqlParameter[] paramsAgregar = {
        new SqlParameter("@ProductoID", productoId),
        new SqlParameter("@NombreProducto", nombre),
        new SqlParameter("@Precio", precio),
        new SqlParameter("@Cantidad", cantidad)
    };
            database.ExecuteNonQuery(spAgregar, paramsAgregar, CommandType.StoredProcedure);

            // 2. Descontar el stock inmediatamente
            string spDescontar = "dbo.DescontarStock";
            SqlParameter[] paramsDescontar = {
        new SqlParameter("@ProductoID", productoId),
        new SqlParameter("@Cantidad", cantidad)
    };
            database.ExecuteNonQuery(spDescontar, paramsDescontar, CommandType.StoredProcedure);
        }

        public void EliminarProductoDelCarrito(int carritoId)
        {
            // Para reponer el stock, primero necesitamos saber qué producto y qué cantidad era.
            // Esto requiere una consulta extra antes de eliminar.

            // 1. Obtener ProductoID y Cantidad ANTES de borrar
            var parameters = new Dictionary<string, object> { { "@CarritoID", carritoId } };
            DataTable itemInfo = database.Select("SELECT ProductoID, Cantidad FROM Carrito WHERE ID = @CarritoID", parameters);

            if (itemInfo.Rows.Count > 0)
            {
                int productoId = Convert.ToInt32(itemInfo.Rows[0]["ProductoID"]);
                int cantidad = Convert.ToInt32(itemInfo.Rows[0]["Cantidad"]);

                // 2. Reponer el stock
                string spReponer = "dbo.ReponerStock";
                SqlParameter[] paramsReponer = {
            new SqlParameter("@ProductoID", productoId),
            new SqlParameter("@Cantidad", cantidad)
        };
                database.ExecuteNonQuery(spReponer, paramsReponer, CommandType.StoredProcedure);

                // 3. Ahora sí, eliminar el item del carrito
                string spEliminar = "dbo.EliminarProductoDelCarrito";
                SqlParameter[] paramsEliminar = { new SqlParameter("@CarritoID", carritoId) };
                database.ExecuteNonQuery(spEliminar, paramsEliminar, CommandType.StoredProcedure);
            }
        }
        public void VaciarCarrito()
        {
            string spName = "VaciarCarrito";
            database.ExecuteNonQuery(spName, null, CommandType.StoredProcedure);
        }

        // CORRECCIÓN: Este es el único método que necesitas para obtener datos del carrito.
        // Devuelve un DataSet con las 2 tablas del Stored Procedure.
        public DataSet ObtenerCarritoConTotal()
        {
            return database.SelectMultiple("dbo.ObtenerCarritoConTotal");
        }

        public void FinalizarCompra()
        {
            // 1. Obtenemos los items del carrito.
            DataSet ds = ObtenerCarritoConTotal();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return; // Salir si el carrito está vacío

            DataTable itemsCarrito = ds.Tables[0];

            // 2. Iteramos y descontamos el stock.
            foreach (DataRow row in itemsCarrito.Rows)
            {
                // Asegúrate que tu SP ObtenerCarritoConTotal devuelve ProductoID
                int productoId = Convert.ToInt32(row["ProductoID"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);

                string spName = "DescontarStock";
                SqlParameter[] parameters = {
                    new SqlParameter("@ProductoID", productoId),
                    new SqlParameter("@Cantidad", cantidad)
                };
                database.ExecuteNonQuery(spName, parameters, CommandType.StoredProcedure);
            }

            // 3. Vaciamos el carrito.
            VaciarCarrito();
        }
    }
}