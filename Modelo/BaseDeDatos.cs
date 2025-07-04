using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parcial_Nº2___Almacen.Modelo
{
    public class BaseDeDatos
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=Almacen;Trusted_Connection=True;";

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

        public int ExecuteNonQuery(string query, SqlParameter[] sqlParams)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}