using Parcial_Nº2___Almacen.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Parcial_Nº2___Almacen.Controlador
{
    
    public class MenuEnviosControlador
    {
        private BaseDeDatos database = new BaseDeDatos();

        public DataTable ObtenerRepartidores()
        {
            string query = "SELECT PersonaID, Nombre, Apellido, Email, Celular, Localidad, TipoDeVehiculo FROM Repartidores";
            return database.Select(query);
        }

    }
}