using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parcial_Nº2___Almacen.Controlador;

namespace Parcial_Nº2___Almacen
{
    public partial class MenuGestionarRepartidor : System.Web.UI.Page
    {
        private MenuGestionarRepartidorControlador controlador = new MenuGestionarRepartidorControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = controlador.InsertarRepartidor(
                txtNombre.Text,
                txtApellido.Text,
                txtEmail.Text,
                txtCelular.Text,
                txtLocalidad.Text,
                txtVehiculo.Text
            );

            lblMensaje.Text = mensaje;

            if (mensaje.Contains("correctamente"))
            {
                txtNombre.Text = txtApellido.Text = txtEmail.Text = txtCelular.Text = txtLocalidad.Text = txtVehiculo.Text = "";
            }
        }
    }
}