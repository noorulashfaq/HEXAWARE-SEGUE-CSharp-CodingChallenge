using LoanManagementSystem.Model;
using LoanManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
	internal class CustomerRepository : ICustomerRepository
	{

		SqlCommand _cmd = null;
		string connectionString;

		public CustomerRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}
		public int AddNewCustomer(Customer customer)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Customers (Name, Email, PhoneNumber, Address, CreditScore) values(@name, @email, @phone, @address, @credit)";
					_cmd.Parameters.AddWithValue("@name", customer.Name);
					_cmd.Parameters.AddWithValue("@email", customer.Email);
					_cmd.Parameters.AddWithValue("@phone", customer.PhoneNumber);
					_cmd.Parameters.AddWithValue("@address", customer.Address);
					_cmd.Parameters.AddWithValue("@credit", customer.CreditScore);
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();
					return _cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
		}

		public Customer GetCustomersById(int custId)
		{
			Customer customer = new Customer();
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				_cmd.CommandText = $"select * from Customers where CustomerID = {custId}";
				_cmd.Connection = sqlConnection;
				sqlConnection.Open();
				SqlDataReader reader = _cmd.ExecuteReader();
				while (reader.Read())
				{
					customer.CustomerId = (int)reader["CustomerID"];
					customer.Name = (string)reader["Name"];
					customer.Email = (string)reader["Email"];
					customer.PhoneNumber = (long)reader["PhoneNumber"];
					customer.Address = (string)reader["Address"];
					customer.CreditScore = (int)reader["CreditScore"];
				}
			}
			return customer;
		}
	}
}
