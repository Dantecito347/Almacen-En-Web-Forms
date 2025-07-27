using Parcial_Nº2___Almacen.Controlador;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class WebForm1 : System.Web.UI.Page 
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

            if (Session["RepartidorSeleccionado"] != null)
            {
                lblRepartidor.Text = "Repartidor: " + Session["RepartidorSeleccionado"].ToString();
            }
            else
            {
                lblRepartidor.Text = "Repartidor: no seleccionado";
            }

        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProductoDelCarrito")
            {
                int carritoId = Convert.ToInt32(e.CommandArgument);
                carritoController.EliminarProductoDelCarrito(carritoId);
                CargarCarrito();
            }
            else if (e.CommandName == "ModificarCantidad")
            {
                int carritoId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                if (int.TryParse(txtCantidad.Text, out int nuevaCantidad) && nuevaCantidad > 0)
                {
                    ActualizarCantidad(carritoId, nuevaCantidad);
                    CargarCarrito(); 
                }
  
            }

        }



        protected void btnDescargarRecibo_Click(object sender, EventArgs e)
        {
            // 1. Obtener los datos del carrito ANTES de vaciarlo.
            DataSet ds = carritoController.ObtenerCarritoConTotal();
            DataTable dtItems = ds.Tables[0];
            decimal total = 0;
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0 && ds.Tables[1].Rows[0]["Total"] != DBNull.Value)
            {
                total = Convert.ToDecimal(ds.Tables[1].Rows[0]["Total"]);
            }

            if (dtItems.Rows.Count == 0)
            {
                lblMensaje.Text = "El carrito está vacío.";
                btnDescargarReciboArchivo.Visible = false;
                return;
            }

            // 2. Generar el contenido del recibo.
            List<string> lineas = new List<string>();
            lineas.Add("      RECIBO DE COMPRA");
            lineas.Add("--------------------------------");
            lineas.Add("      Almacen 'Lo de Juan'");
            lineas.Add($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            if (Session["RepartidorSeleccionado"] != null)
            {
                lineas.Add($"Repartidor: {Session["RepartidorSeleccionado"]}");
            }
            lineas.Add("--------------------------------");
            lineas.Add("");
            foreach (DataRow row in dtItems.Rows)
            {
                string nombre = row["NombreProducto"].ToString();
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                decimal precio = Convert.ToDecimal(row["Precio"]);
                decimal subtotal = Convert.ToDecimal(row["Subtotal"]);
                lineas.Add($"{nombre} x{cantidad} - {precio:C} = {subtotal:C}");
            }
            lineas.Add("");
            lineas.Add("--------------------------------");
            lineas.Add($"TOTAL: {total:C}");

            string recibo = string.Join(Environment.NewLine, lineas);

            // 3. Vaciar el carrito en la base de datos.
            carritoController.VaciarCarrito();

            // 4. "Eliminar" el repartidor seleccionado de la sesión actual.
            Session["RepartidorSeleccionado"] = null;

            // 5. Guardar el recibo en sesión para descargarlo después.
            Session["ReciboCompra"] = recibo;

            // 6. Refrescar la vista del carrito en la página.
            CargarCarrito();

            // 7. Mostrar mensaje y habilitar botón de descarga.
            lblMensaje.Text = "Compra finalizada. Puede descargar su recibo.";
            btnDescargarReciboArchivo.Visible = true;
        }

        void ActualizarCantidad(int carritoId, int nuevaCantidad)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString))
            {
                string query = "UPDATE Carrito SET Cantidad = @Cantidad WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                cmd.Parameters.AddWithValue("@ID", carritoId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnDescargarReciboArchivo_Click(object sender, EventArgs e)
        {
            if (Session["ReciboCompra"] != null)
            {
                string recibo = Session["ReciboCompra"].ToString();
                Session["ReciboCompra"] = null;
                btnDescargarReciboArchivo.Visible = false;

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AddHeader("Content-Disposition", "attachment; filename=Recibo.txt");
                Response.Write(recibo);
                Response.End();
            }
        }
    }
}