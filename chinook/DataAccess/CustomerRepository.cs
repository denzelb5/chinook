using chinook.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace chinook.DataAccess
{
    public class CustomerRepository

    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";
        public List<Customer> GetByCountry(string country)
        {
            var sql = @"
                select 
                    FirstName,
                    LastName,
                    CustomerId,
                    Country
                from Customer
                where Customer.Country = @country";

            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                var cmd = db.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("country", country);

                var reader = cmd.ExecuteReader();
                var customers = new List<Customer>();

                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]

                    };

                    customers.Add(customer);
                }

                db.Close();
                return customers;
            }
        }
        public List<Customer> GetNonUsaByCountry(string country)
        {
            var sql = @"SELECT FirstName, LastName, CustomerId, Country 
                FROM Customer
                WHERE Country != @country";


            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("country", country);

                var reader = cmd.ExecuteReader();
                var nonUsaCustomers = new List<Customer>();

                while (reader.Read())
                {
                    var nonUsaCustomer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]
                    };
                    nonUsaCustomers.Add(nonUsaCustomer);
                }

                connection.Close();

                return nonUsaCustomers;
            }
        }


        public List<CustomerWithInvoices> GetBrazilCustomerInvoices(string country)
        {
            var sql = @"SELECT FirstName, LastName, InvoiceId, InvoiceDate
                        FROM Customer
	                    JOIN Invoice
		                ON Customer.CustomerId = Invoice.CustomerId
		                WHERE Customer.Country = @country;";
       

            using (var connection = new SqlConnection(ConnectionString)) 
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("country", country);

                var reader = cmd.ExecuteReader();

                var customerInvoices = new List<CustomerWithInvoices>();

                while (reader.Read())
                {
                    var customerInvoice = new CustomerWithInvoices
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        InvoiceDate = (System.DateTime)reader["InvoiceDate"],
                        InvoiceId = (int)reader["InvoiceId"]

                    };
                    customerInvoices.Add(customerInvoice);
                }
               
                connection.Close();

                return customerInvoices;
            }
        }


        Customer MapReaderToCustomer(SqlDataReader reader)
        {
             var customer = new Customer
            {
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                CustomerId = (int)reader["CustomerId"],
                Country = (string)reader["Country"]
            };

            return customer;
        }



    }
}
