using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_Nº2___Almacen.Modelo;
using Parcial_Nº2___Almacen.Controlador;

namespace Parcial_Nº2___Almacen
{
    public partial class MenuProductos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
                CargarBebidas();
                CargarLacteos();
            }

        }

        private void CargarProductos()
        {
            DataTable tablaProductos = ObtenerDatos();

            gvProductos.DataSource = tablaProductos;
            gvProductos.DataBind();
        }

        private void CargarBebidas()
        {
            MenuAlimentosControlador controlador = new MenuAlimentosControlador();
            DataTable tablaBebidas = controlador.ObtenerBebidas();
            gvBebidas.DataSource = tablaBebidas;
            gvBebidas.DataBind();
        }

        private void CargarLacteos()
        {
            MenuAlimentosControlador controlador = new MenuAlimentosControlador();
            DataTable tablaLacteos = controlador.ObtenerLacteos();
            gvLacteos.DataSource = tablaLacteos;
            gvLacteos.DataBind();
        }
        
        private DataTable ObtenerDatos()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;

            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT ProductosID AS IdProducto, Nombre, Precio, Stock FROM Productos_Alimentos";
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comprar")
            {
                string idProducto = e.CommandArgument.ToString();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProductos.Rows[index];
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                string cantidad = txtCantidad.Text;

                lblMensaje.Text = $"Producto {idProducto} comprado. Cantidad: {cantidad}";
            }
        }

        protected void gvBebidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarBebida")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvBebidas.Rows[index];
                string idBebida = row.Cells[0].Text;
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadBebida");
                string cantidad = txtCantidad.Text;

                lblMensaje.Text = $"Bebida {idBebida} comprada. Cantidad: {cantidad}";
            }
        }

        protected void gvLacteos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarLacteo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvLacteos.Rows[index];
                string idLacteo = row.Cells[0].Text;
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadLacteo");
                string cantidad = txtCantidad.Text;

                lblMensaje.Text = $"Lácteo {idLacteo} comprado. Cantidad: {cantidad}";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MenuPrincipal.aspx");
        }
    }
}   

