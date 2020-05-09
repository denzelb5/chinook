using chinook.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace chinook.Controllers
{
    public class InvoiceRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<InvoiceByEmployee> GetInvoicesByEmployee()
        {
            var sql = @"SELECT Employee.FirstName, Employee.LastName, Invoice.InvoiceId
	                    FROM Employee
		                JOIN Customer 
			            ON Employee.EmployeeId = Customer.SupportRepId
		                JOIN Invoice 
			            ON Invoice.CustomerId = Customer.CustomerId;";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();
                var invoices = new List<InvoiceByEmployee>();

                while (reader.Read())
                {
                    var invoiceByEmployee = new InvoiceByEmployee
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        InvoiceId = (int)reader["InvoiceId"]
                    };
                    invoices.Add(invoiceByEmployee);
                   
                }
                connection.Close();
                return invoices;
            }
        }
    }
}