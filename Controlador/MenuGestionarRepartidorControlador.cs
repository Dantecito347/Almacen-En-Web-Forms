using System;
using System.Data;
using System.Data.SqlClient;
using Parcial_Nº2___Almacen.Modelo;

namespace Parcial_Nº2___Almacen.Controlador
{
    public class MenuGestionarRepartidorControlador
    {
        private BaseDeDatos database = new BaseDeDatos();

        public string InsertarRepartidor(string nombre, string apellido, string email, string celular, string localidad, string vehiculo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Accion", "INSERTAR"),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@Email", email),
                new SqlParameter("@Celular", celular),
                new SqlParameter("@Localidad", localidad),
                new SqlParameter("@TipoDeVehiculo", vehiculo)
            };

            try
            {
                int resultado = database.ExecuteNonQuery("GestionarRepartidor", parametros, CommandType.StoredProcedure);

                if (resultado > 0)
                    return "Repartidor insertado correctamente.";
                else
                    return "No se insertó el repartidor. Puede que ya exista el email o celular.";
            }
            catch (SqlException ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
