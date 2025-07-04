using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_Nº2___Almacen
{
    public partial class MenuEnvios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarRepartidores();
            }
        }

        private void CargarRepartidores()
        {
            Controlador.MenuEnviosControlador controlador = new Controlador.MenuEnviosControlador();
            var tablaRepartidores = controlador.ObtenerRepartidores();
            gvRepartidores.DataSource = tablaRepartidores;
            gvRepartidores.DataBind();
        }
    }
}