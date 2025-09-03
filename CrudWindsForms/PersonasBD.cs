using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrudWindsForms
{
    public class PersonasBD
    {

        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=CrudWindowsForm;Integrated Security=True;TrustServerCertificate=True";
        public bool Ok(out string error)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();     // Si abre, está todo OK
                }
                error = "";
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;       // Te muestra por qué falla si falla
                return false;
            }
        }


        public List<Persona> Lista()
        {
            List<Persona> listaPersonas = new List<Persona>();

            string query = "select id, nombre, edad from personas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Persona persona1 = new Persona();
                        persona1.Id = reader.GetInt32(0);
                        persona1.Nombre = reader.GetString(1);
                        persona1.Edad = reader.GetInt32(2);
                        listaPersonas.Add(persona1);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en Base De Datos: " + ex.Message);
                }
            }

            return listaPersonas;
        }


        public void Add(string nombre, int edad)
        {
            const string sql =
                @"INSERT INTO dbo.Personas (nombre, edad)
                 VALUES (@nombre, @edad);";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {

                command.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar, 100).Value = nombre;
                command.Parameters.Add("@edad", System.Data.SqlDbType.Int).Value = edad;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Modificar(string nombre, int edad, int id)
        {
            const string sql = @"
             UPDATE dbo.Personas
            SET nombre = @nombre,
            edad   = @edad
             WHERE id = @id;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                // Mejor tipar parámetros que usar AddWithValue
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre;
                command.Parameters.Add("@edad", SqlDbType.Int).Value = edad;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            const string sql = @"DELETE FROM dbo.Personas WHERE id=@id;";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Persona Md(int id)
        {
            const string sql = @"SELECT id, nombre, edad
                         FROM dbo.Personas
                         WHERE id = @id";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new Persona
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Edad = reader.GetInt32(2)
                    };
                }
            }
        }
    }
}
