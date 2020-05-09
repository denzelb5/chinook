using chinook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace chinook.Controllers
{
    public class EmployeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<Employee> GetByEmployee(string employeeTitle)
        {
            var sql = @"SELECT EmployeeId, FirstName, LastName, Title
                        FROM Employee
                        WHERE Title like '@employeeTitle%';";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("employeeTitle", employeeTitle); //(sql variable, function parameter)

                var reader = cmd.ExecuteReader();
                var employees = new List<Employee>();

                while (reader.Read())
                {
                    var staffEmployee = new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Title = (string)reader["Title"]
                    };
                    employees.Add(staffEmployee);
                }
                connection.Close();
                return employees;
            }
        }
    }
}