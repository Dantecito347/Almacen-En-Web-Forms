// MenuProductos.aspx.cs (Versión Corregida)
using Parcial_Nº2___Almacen.Controlador;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class MenuProductos : System.Web.UI.Page
    {
        // Instancia los controladores una sola vez
        private MenuAlimentosControlador menuController = new MenuAlimentosControlador();
        private CarritoControlador carritoController = new CarritoControlador();

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
            // Este método ahora usará el controlador
            gvProductos.DataSource = menuController.ObtenerAlimentos();
            gvProductos.DataBind();
        }

        private void CargarBebidas()
        {
            gvBebidas.DataSource = menuController.ObtenerBebidas();
            gvBebidas.DataBind();
        }

        private void CargarLacteos()
        {
            gvLacteos.DataSource = menuController.ObtenerLacteos();
            gvLacteos.DataBind();
        }

        // El método ObtenerDatos() ya no es necesario aquí. Lo borramos.

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comprar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProductos.Rows[rowIndex];

                int productoId = Convert.ToInt32(gvProductos.DataKeys[rowIndex].Values["ID"]);
                string nombre = row.Cells[1].Text; // Asumiendo que el nombre está en la segunda celda
                decimal precio = Convert.ToDecimal(gvProductos.DataKeys[rowIndex].Values["Precio"]);
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                {
                    // Lógica simplificada y correcta
                    carritoController.AgregarAlCarrito(productoId, nombre, precio, cantidad);
                    lblMensaje.Text = $"Producto '{nombre}' agregado al carrito.";
                }
                else
                {
                    lblMensaje.Text = "Error: Ingrese una cantidad válida.";
                }
                // YA NO HAY MÁS CÓDIGO AQUÍ. Se borró el acceso directo a la BD.
            }
        }

        protected void gvBebidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarBebida")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvBebidas.Rows[rowIndex];

                int productoId = Convert.ToInt32(gvBebidas.DataKeys[rowIndex].Values["ID"]);
                string nombre = row.Cells[1].Text;
                decimal precio = Convert.ToDecimal(gvBebidas.DataKeys[rowIndex].Values["Precio"]);
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadBebida");

                if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                {
                    carritoController.AgregarAlCarrito(productoId, nombre, precio, cantidad);
                    lblMensaje.Text = $"Bebida '{nombre}' agregada al carrito.";
                }
                else
                {
                    lblMensaje.Text = "Error: Ingrese una cantidad válida.";
                }
            }
        }

        protected void gvLacteos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ComprarLacteo")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvLacteos.Rows[rowIndex];

                int productoId = Convert.ToInt32(gvLacteos.DataKeys[rowIndex].Values["ID"]);
                string nombre = row.Cells[1].Text;
                decimal precio = Convert.ToDecimal(gvLacteos.DataKeys[rowIndex].Values["Precio"]);
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidadLacteo");

                if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                {
                    carritoController.AgregarAlCarrito(productoId, nombre, precio, cantidad);
                    lblMensaje.Text = $"Lácteo '{nombre}' agregado al carrito.";
                }
                else
                {
                    lblMensaje.Text = "Error: Ingrese una cantidad válida.";
                }
            }
        }

        // El método DescontarStock() ya no debe estar aquí. Bórralo.
    }
}