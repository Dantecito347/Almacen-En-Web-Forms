using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Parcial_Nº2___Almacen.Modelo
{
    public class BaseDeDatos
    {
        public string connectionString;

        public BaseDeDatos()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlmacenConnectionString"].ConnectionString;
        }

        // MÉTODO 1: Para consultas SELECT simples que devuelven UNA tabla.
        // Lo necesitan MenuAlimentosControlador y MenuEnviosControlador.
        public DataTable Select(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // MÉTODO 2: Para Stored Procedures que devuelven MÚLTIPLES tablas (como el carrito).
        // Lo necesita CarritoControlador.
        public DataSet SelectMultiple(string procedureName, Dictionary<string, object> parameters = null)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
            }
            return dataSet;
        }


        // MÉTODO 3: Para ejecutar INSERT, UPDATE, DELETE, o Stored Procedures que no devuelven datos.
        // Lo necesita CarritoControlador.
        public int ExecuteNonQuery(string query, SqlParameter[] sqlParams, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}