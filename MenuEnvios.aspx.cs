using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            if (!IsPostBack)
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

        protected void btnGestionarRepartidor_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuGestionarRepartidor.aspx");
        }

        private void EliminarRepartidor(int personaID)
        {
            using (SqlConnection conn = new SqlConnection("AlmacenConnectionString"))
            using (SqlCommand cmd = new SqlCommand("GestionarRepartidor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                cmd.Parameters.AddWithValue("@PersonaID", personaID);


                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        protected void gvRepartidores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int personaID = Convert.ToInt32(e.CommandArgument);
                EliminarRepartidor(personaID);
            }


        }
    }
}