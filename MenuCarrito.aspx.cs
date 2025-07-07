// MenuCarrito.aspx.cs (Versión Corregida)
using Parcial_Nº2___Almacen.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class WebForm1 : System.Web.UI.Page // Asegúrate que el nombre de la clase coincida
    {
        private CarritoControlador carritoController = new CarritoControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            DataSet ds = carritoController.ObtenerCarritoConTotal();
            DataTable dtItems = ds.Tables[0];
            gvCarrito.DataSource = dtItems;
            gvCarrito.DataBind();

            decimal total = 0;
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0 && ds.Tables[1].Rows[0]["Total"] != DBNull.Value)
            {
                total = Convert.ToDecimal(ds.Tables[1].Rows[0]["Total"]);
            }
            lblTotal.Text = total.ToString("C");
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProductoDelCarrito")
            {
                int carritoId = Convert.ToInt32(e.CommandArgument);
                carritoController.EliminarProductoDelCarrito(carritoId);
                CargarCarrito();
            }
        }

        // Agrega este botón a tu .aspx
        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                carritoController.FinalizarCompra();
                // Puedes redirigir a una página de éxito
                Response.Redirect("CompraExitosa.aspx");
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si algo falla (ej: no hay stock)
                // lblError.Text = "Error al procesar la compra: " + ex.Message;
            }
        }

        protected void btnDescargarRecibo_Click(object sender, EventArgs e)
        {
            // Lógica refactorizada para usar el controlador
            DataSet ds = carritoController.ObtenerCarritoConTotal();
            DataTable dtItems = ds.Tables[0];
            decimal total = Convert.ToDecimal(ds.Tables[1].Rows[0]["Total"] ?? 0);

            List<string> lineas = new List<string>();
            lineas.Add("RECIBO DE COMPRA");
            lineas.Add("----------------------");
            foreach (DataRow row in dtItems.Rows)
            {
                lineas.Add($"{row["NombreProducto"]} x{row["Cantidad"]} - {Convert.ToDecimal(row["Precio"]):C} = {Convert.ToDecimal(row["Subtotal"]):C}");
            }
            lineas.Add("----------------------");
            lineas.Add($"TOTAL: {total:C}");

            string recibo = string.Join(Environment.NewLine, lineas);

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment; filename=Recibo.txt");
            Response.Write(recibo);
            Response.End();
        }
    }
}