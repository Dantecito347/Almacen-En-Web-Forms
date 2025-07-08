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

        private DataRow ObtenerDatosRepartidor(int personaID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Nombre, Apellido FROM Repartidores WHERE PersonaID = @PersonaID", conn))
                {
                    cmd.Parameters.AddWithValue("@PersonaID", personaID);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    conn.Open();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0];
                    }
                }
            }
            return null; 
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
            else if (e.CommandName == "Seleccionar")
            {
<<<<<<< HEAD
                int personaID = Convert.ToInt32(e.CommandArgument);


                DataRow repartidorData = ObtenerDatosRepartidor(personaID);

                if (repartidorData != null)
                {
                    string nombre = repartidorData["Nombre"].ToString();
                    string apellido = repartidorData["Apellido"].ToString();
                    Session["PersonaID_RepartidorSeleccionado"] = personaID;
                    Session["RepartidorSeleccionado"] = $"{nombre} {apellido}";
                    Response.Redirect("MenuCarrito.aspx");
                }
            
        }
=======
                Response.Write("<script>alert('Evento ejecutado');</script>");
                GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
                string nombre = row.Cells[1].Text.Trim();
                string apellido = row.Cells[2].Text.Trim();

                Session["RepartidorSeleccionado"] = $"{nombre} {apellido}";
                
            }
>>>>>>> 16605bdb3ad2fe0e7cb21c0474ab0b45d6675d77


        }
    }
}