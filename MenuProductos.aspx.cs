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
                string consulta = "SELECT ID AS ID, Nombre, Precio, Stock FROM Productos_Alimentos";
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
                int index = Convert.ToInt32(e.CommandArgument);

                int productoId = Convert.ToInt32(gvProductos.DataKeys[index].Values["ID"]);
                decimal precio = Convert.ToDecimal(gvProductos.DataKeys[index].Values["Precio"]);

                GridViewRow row = gvProductos.Rows[index];
                string nombre = row.Cells[1].Text;

                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    lblMensaje.Text = "Error: Por favor, ingrese una cantidad numérica válida y mayor a cero.";
                    return; 
                }


                string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("AgregarProductoAlCarrito", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoID", productoId);
                    cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                DescontarStock(productoId, cantidad);
                CargarLacteos();

                lblMensaje.Text = $"Producto {nombre} agregado al carrito. Cantidad: {cantidad}";
            }
        }

        protected void gvBebidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarBebida")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                int productoId = Convert.ToInt32(gvBebidas.DataKeys[index].Values["ID"]);
                decimal precio = Convert.ToDecimal(gvBebidas.DataKeys[index].Values["Precio"]);

                GridViewRow row = gvBebidas.Rows[index];
                string nombre = row.Cells[1].Text;

                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadBebida");
                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    lblMensaje.Text = "Error: Por favor, ingrese una cantidad numérica válida y mayor a cero.";
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("AgregarProductoAlCarrito", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoID", productoId);
                    cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                DescontarStock(productoId, cantidad);
                CargarLacteos();

                lblMensaje.Text = $"Bebida {nombre} agregada al carrito. Cantidad: {cantidad}";
            }
        }

        protected void gvLacteos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarLacteo")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                int productoId = Convert.ToInt32(gvLacteos.DataKeys[index].Values["ID"]);
                decimal precio = Convert.ToDecimal(gvLacteos.DataKeys[index].Values["Precio"]);

                GridViewRow row = gvLacteos.Rows[index];
                string nombre = row.Cells[1].Text;

                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadLacteo");
                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    lblMensaje.Text = "Error: Por favor, ingrese una cantidad numérica válida y mayor a cero.";
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("AgregarProductoAlCarrito", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoID", productoId);
                    cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                DescontarStock(productoId, cantidad);
                CargarLacteos();

                lblMensaje.Text = $"Lácteo {nombre} agregado al carrito. Cantidad: {cantidad}";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MenuPrincipal.aspx");
        }

        private void DescontarStock(int productoId, int cantidad)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DescontarStock", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductoID", productoId);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}   

