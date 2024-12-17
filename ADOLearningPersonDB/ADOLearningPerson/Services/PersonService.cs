using ADOLearningPerson.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace ADOLearningPerson.Services
{
    public class PersonService
    {
        private readonly string _connectionString;


        public PersonService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();
            string query = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                  

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persons.Add(new Person
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                NAME = reader["NAME"].ToString(),
                                AGE = Convert.ToInt32(reader["AGE"]),
                                ADRESS = reader["ADRESS"].ToString()
                            });


                        }

                    }
                    return persons; 
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error fetchibg persons : {ex.Message}");
                }
            }
            

        }

        
        public bool AddPerson (Person person)
        {

            string query = "INSERT INTO Persons(ID,NAME,AGE,ADRESS) VALUES (@ID,@NAME,@AGE,@ADRESS)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", person.ID);
                    command.Parameters.AddWithValue("@NAME", person.NAME);
                    command.Parameters.AddWithValue("@Age", person.AGE);
                    command.Parameters.AddWithValue("@ADRESS", person.ADRESS);

                   int rowsAffected =  command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding person :{ex.Message}");
                }
            }

        }

        public string GetOldestPerson()
        {
            string query = "SELECT TOP 1 NAME FROM Persons ORDER BY AGE DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                   object result =  command.ExecuteScalar();

                    return result != null ? result.ToString() : "no person found";
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error finding the oldest person : {ex.Message}");
                }
            }
        }

        public bool UpdatePerson(Person person)
        {
            string query = "UPDATE Persons SET NAME = @NAME , AGE = @AGE ,ADRESS = @ADRESS WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(_connectionString)) 

            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", person.ID);
                    command.Parameters.AddWithValue("@NAME", person.NAME);
                    command.Parameters.AddWithValue("@AGE", person.AGE);
                    command.Parameters.AddWithValue("@ADRESS", person.ADRESS); 

                    int rowsAffected  = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                                                                     
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error updating person: {ex.Message}");
                }
            }
        }


        public bool DeletePerson(int id)
        {
            string query = "DELETE FROM Persons WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsEffected = command.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting person: {ex.Message}");
                }
            }
        }



       

    }
}
