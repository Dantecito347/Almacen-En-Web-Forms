
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


        public void AgregarAlCarrito(int productoId, string nombre, decimal precio, int cantidad, string tipo)
        {
            try
            {
                // 1. Agregar al carrito
                string spAgregar = "dbo.AgregarProductoAlCarrito";
                SqlParameter[] paramsAgregar = {
            new SqlParameter("@ProductoID", productoId),
            new SqlParameter("@NombreProducto", nombre),
            new SqlParameter("@Precio", precio),
            new SqlParameter("@Tipo", tipo),
            new SqlParameter("@Cantidad", cantidad)
        };
                database.ExecuteNonQuery(spAgregar, paramsAgregar, CommandType.StoredProcedure);

                // 2. Descontar el stock usando el nuevo método
                DescontarStock(productoId, cantidad, tipo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("❌ Error al agregar al carrito: " + ex.Message);
                throw;
            }
        }



        public void DescontarStock(int productoId, int cantidad, string tipo)
        {
            try
            {
                string spDescontar = "dbo.DescontarStock";
                SqlParameter[] paramsDescontar = {
            new SqlParameter("@ProductoID", productoId),
            new SqlParameter("@Cantidad", cantidad),
            new SqlParameter("@Tipo", tipo)
        };
                database.ExecuteNonQuery(spDescontar, paramsDescontar, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("❌ Error al descontar stock: " + ex.Message);
                throw;
            }
        }



        public void EliminarProductoDelCarrito(int carritoId)
        {

            var parameters = new Dictionary<string, object> { { "@CarritoID", carritoId } };
            DataTable itemInfo = database.Select("SELECT ProductoID, Cantidad FROM Carrito WHERE ID = @CarritoID", parameters);

            if (itemInfo.Rows.Count > 0)
            {
                int productoId = Convert.ToInt32(itemInfo.Rows[0]["ProductoID"]);
                int cantidad = Convert.ToInt32(itemInfo.Rows[0]["Cantidad"]);


                string spReponer = "dbo.ReponerStock";
                SqlParameter[] paramsReponer = {
            new SqlParameter("@ProductoID", productoId),
            new SqlParameter("@Cantidad", cantidad)
        };
                database.ExecuteNonQuery(spReponer, paramsReponer, CommandType.StoredProcedure);
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

        public DataSet ObtenerCarritoConTotal()
        {
            return database.SelectMultiple("dbo.ObtenerCarritoConTotal");
        }

        public void FinalizarCompra()
        {

            DataSet ds = ObtenerCarritoConTotal();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return; 

            DataTable itemsCarrito = ds.Tables[0];

            foreach (DataRow row in itemsCarrito.Rows)
            {
                int productoId = Convert.ToInt32(row["ProductoID"]);
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                string tipo = row["Tipo"].ToString(); // <-- Ahora sí funciona

                string spName = "DescontarStock";
                SqlParameter[] parameters = {
        new SqlParameter("@ProductoID", productoId),
        new SqlParameter("@Cantidad", cantidad),
        new SqlParameter("@Tipo", tipo)
    };
                database.ExecuteNonQuery(spName, parameters, CommandType.StoredProcedure);
            }


            VaciarCarrito();
        }
    }
}