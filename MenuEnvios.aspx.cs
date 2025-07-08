using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


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
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("GestionarRepartidor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "ELIMINAR");
                cmd.Parameters.AddWithValue("@PersonaID", personaID);
                cmd.Parameters.AddWithValue("@Nombre", DBNull.Value);
                cmd.Parameters.AddWithValue("@Apellido", DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                cmd.Parameters.AddWithValue("@Celular", DBNull.Value);
                cmd.Parameters.AddWithValue("@Localidad", DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoDeVehiculo", DBNull.Value);


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
                CargarRepartidores();
            }
            else 
                 if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument); // Esto es PersonaID
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;

                string nombre = row.Cells[1].Text;    // Suponiendo que la celda 1 es Nombre
                string apellido = row.Cells[2].Text;  // Celda 2 es Apellido

                Session["PersonaID_RepartidorSeleccionado"] = index;
                Session["RepartidorSeleccionado"] = $"{nombre} {apellido}";

                Response.Redirect("MenuCarrito.aspx");
            }


        }
    }
}