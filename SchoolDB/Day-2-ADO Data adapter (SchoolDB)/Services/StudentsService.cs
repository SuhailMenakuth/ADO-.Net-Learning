using Day_2_ADO_Data_adapter__SchoolDB_.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace Day_2_ADO_Data_adapter__SchoolDB_.Services
{
    public class StudentsService
    {
        private readonly string _connectionString;

        public StudentsService(IConfiguration configuration)
        {

           _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT StudentID , FirstName , LastName , Age FROM Students";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query,connection);
                DataTable table = new DataTable();

                try
                {
                    dataAdapter.Fill(table);
                    
                    foreach (DataRow row in table.Rows)
                    {
                        students.Add(
                       //Student  student = new Student
                       new Student
                       {
                           StudentID = Convert.ToInt32(row["StudentID"]),
                           FirstName = row["FirstName"].ToString(),
                           LastName = row["LastName"].ToString(),
                           Age = Convert.ToInt32(row["Age"])
                       });
                        //students.Add(student);
                     
                    }
                  return students;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching student data", ex);
                }

            }
        }


        //public List<Student> GetAllStudents()
        //{
        //    List<Student> students = new List<Student>();

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        string query = "SELECT StudentID , FirstName , LastName ,Age FROM Students";
        //        SqlDataAdapter datadapter = new SqlDataAdapter(query,connection);

        //        DataSet dataSet = new DataSet();
                
        //        try
        //        {
        //            datadapter.Fill(dataSet,"StudentTable");
        //            DataTable dataTable = dataSet.Tables["StudentTable"];
        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                Student student = new Student
        //                {
        //                    StudentID = Convert.ToInt32(row["StudentID"]),
        //                    FirstName = row["FirstName"].ToString(),
        //                    LastName = row["LastName"].ToString(),
        //                    Age = Convert.ToInt32(row["Age"])

        //                };
        //                students.Add(student);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error fetching student data", ex);
        //        }

        //    }
        //    return students;
        //}


        public string AddStudent(Student student)
        {
            List<Student> students = new List<Student>();   
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM STUDENTS";
                SqlDataAdapter DataAdapter = new SqlDataAdapter(query,connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(DataAdapter);
                DataTable table = new DataTable();

                try
                {

                    DataAdapter.Fill(table);

                    DataRow dataRow = table.NewRow();
                    dataRow[0] = student.StudentID;
                    dataRow[1] = student.FirstName;
                    dataRow[2] = student.LastName;
                    dataRow[3] = student.Age;

                    table.Rows.Add(dataRow);
                    DataAdapter.Update(table);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching student data", ex);
                }
                return table.ToString();

            }


        }

        public Student GetStudentByID(int Studentid)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try { 
                string query = "SELECT * FROM Students WHERE StudentID = @Studentid ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", Studentid);


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                dataAdapter.Fill(table);

                    if (table.Rows.Count > 0) 
                    {
                        DataRow row = table.Rows[0]; 
                       student =  new Student
                        {
                            StudentID = Convert.ToInt32(row["StudentID"]),
                            FirstName = row["FirstName"].ToString(),
                            LastName = row["LastName"].ToString(),
                            Age = Convert.ToInt32(row["Age"])
                        };
                    }


                    return student;
                   }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching student data", ex);
                }



            }
            
        }


        
            
    }
}
