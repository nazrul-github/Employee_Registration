using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EmployeeRegistrationForm_2.Models.DAL
{
    public class EmloyeeDbContext
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["EmloyeeDbContext"].ConnectionString;

        public IEnumerable<Employee> GetAllEmployees
        {
            get
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    List<Employee> allEmployees = new List<Employee>();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM customer_list;";
                    cmd.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee aEmployee = new Employee();
                        aEmployee.Id = (int)reader["id"];
                        aEmployee.Name = reader["name"].ToString();
                        aEmployee.Address = reader["address"].ToString();
                        aEmployee.Zip_Code = reader["zip_code"].ToString();
                        aEmployee.City = reader["city"].ToString();
                        aEmployee.Country = reader["country"].ToString();
                        aEmployee.Phone = reader["phone"].ToString();
                        allEmployees.Add(aEmployee);
                    }

                    reader.Close();
                    connection.Close();
                    return allEmployees;
                }
            }
        }

        public void CreateEmployee(Employee aEmployee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_CreateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", aEmployee.Id);
                cmd.Parameters.AddWithValue("@Name", aEmployee.Name);
                cmd.Parameters.AddWithValue("@Address", aEmployee.Address);
                cmd.Parameters.AddWithValue("@ZipCode", aEmployee.Zip_Code);
                cmd.Parameters.AddWithValue("@Phone", aEmployee.Phone);
                cmd.Parameters.AddWithValue("@City", aEmployee.City);
                cmd.Parameters.AddWithValue("@Country", aEmployee.Country);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateEmployee(Employee aEmployee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_UpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", aEmployee.Id);
                cmd.Parameters.AddWithValue("@Name", aEmployee.Name);
                cmd.Parameters.AddWithValue("@Address", aEmployee.Address);
                cmd.Parameters.AddWithValue("@ZipCode", aEmployee.Zip_Code);
                cmd.Parameters.AddWithValue("@Phone", aEmployee.Phone);
                cmd.Parameters.AddWithValue("@City", aEmployee.City);
                cmd.Parameters.AddWithValue("@Country", aEmployee.Country);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteEmploye(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM customer_list WHERE id = @Id;";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}