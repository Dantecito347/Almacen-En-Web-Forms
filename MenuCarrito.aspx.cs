using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, NombreProducto, Precio, Cantidad, (Precio * Cantidad) AS Subtotal FROM Carrito";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                gvCarrito.DataSource = dt;
                gvCarrito.DataBind();

                decimal total = 0;
                if (dt.Rows.Count > 0)
                {
                    // Usamos el método Compute de DataTable para sumar el total de forma más eficiente
                    total = Convert.ToDecimal(dt.Compute("SUM(Subtotal)", string.Empty));
                }

                lblTotal.Text = total.ToString("C");
            }
        }

        protected void btnDescargarRecibo_Click(object sender, EventArgs e)
        {
            // 1. Vuelve a cargar los datos del carrito
            string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            decimal total = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT NombreProducto, Precio, Cantidad, (Precio * Cantidad) AS Subtotal FROM Carrito";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["Subtotal"]);
                }
            }

            // 2. Genera el recibo en memoria y lo envía como descarga al usuario
            List<string> lineas = new List<string>();
            lineas.Add("RECIBO DE COMPRA");
            lineas.Add("----------------------");
            foreach (DataRow row in dt.Rows)
            {
                lineas.Add($"{row["NombreProducto"]} x{row["Cantidad"]} - {row["Precio"]:C} = {row["Subtotal"]:C}");
            }
            lineas.Add("----------------------");
            lineas.Add($"TOTAL: {total:C}");

            string recibo = string.Join(Environment.NewLine, lineas);

            // 3. Envía el archivo como descarga
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment; filename=Recibo.txt");
            Response.Write(recibo);
            Response.End();
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarItem")
            {
                // Obtener el ID del item del carrito desde el CommandArgument
                int carritoId = Convert.ToInt32(e.CommandArgument);

                // Llamar al Stored Procedure para eliminar y reponer
                string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("EliminarItemCarritoYReponerStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarritoID", carritoId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Recargar el carrito para mostrar los cambios
                CargarCarrito();
                
            }
        }



    }
}