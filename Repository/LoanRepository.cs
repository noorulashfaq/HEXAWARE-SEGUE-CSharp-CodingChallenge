using LoanManagementSystem.Model;
using LoanManagementSystem.Utility;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Exceptions;

namespace LoanManagementSystem.Repository
{
	internal class LoanRepository : ILoanRepository
	{
		SqlCommand _cmd = null;
		string connectionString;

		public LoanRepository()
		{
			connectionString = DBConnUtil.GetConnectionString();
			_cmd = new SqlCommand();
		}

		public int ApplyLoan(Loan loan)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					_cmd.Parameters.Clear();
					_cmd.CommandText = "insert into Loans (CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType) values(@customerId, @principalAmount, @interestRate, @loanTerm, @loanType)";
					_cmd.Parameters.AddWithValue("@customerId", loan.CustomerId);
					_cmd.Parameters.AddWithValue("@principalAmount", loan.PrincipalAmount);
					_cmd.Parameters.AddWithValue("@interestRate", loan.InterestRate);
					_cmd.Parameters.AddWithValue("@loanTerm", loan.LoanTerm);
					_cmd.Parameters.AddWithValue("@loanType", loan.LoanType);
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

		public double CalcEMI(int loanId)
		{
			throw new NotImplementedException();
		}

		public double CalcInterest(int loanId)
		{
			double emi = 0.0;
			try
			{
				double principalAmt = 0.0;
				double rate = 0.0, tenure = 0.0;

				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				using (SqlCommand cmd = new SqlCommand(connectionString))
				{
					_cmd.CommandText = $"select * from Loans where LoanID = {loanId}";
					_cmd.Connection = sqlConnection;
					sqlConnection.Open();

					using (SqlDataReader reader = _cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							rate = Convert.ToDouble(reader["InterestRate"]);
							tenure = Convert.ToDouble(reader["LoanTerm"]);
							principalAmt = Convert.ToDouble(reader["PrincipalAmount"]);
						}
						else
						{
							Console.WriteLine($"Loan with ID {loanId} not found.");
							return 0.0;
						}
					}
				}

				double monthlyRate = rate / 12 / 100;
				int months = (int)(tenure * 12);

				if (monthlyRate > 0)
				{
					emi = (principalAmt * monthlyRate * Math.Pow(1 + monthlyRate, months)) /
						  (Math.Pow(1 + monthlyRate, months) - 1);
				}
				else
				{
					emi = principalAmt / months;
				}
			}
			catch(InvalidLoanException ile)
			{
				Console.WriteLine(ile.Message);
			}

			return emi;
		}


		public List<Loan> GetAllLoans()
		{
			List<Loan> loans = new List<Loan>();
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				_cmd.CommandText = "select * from Loans";
				_cmd.Connection = sqlConnection;
				sqlConnection.Open();
				SqlDataReader reader = _cmd.ExecuteReader();
				while (reader.Read())
				{
					Loan loan = new Loan();
					loan.LoanId = (int)reader["LoanID"];
					loan.CustomerId = (int)reader["CustomerID"];
					loan.InterestRate = (int)reader["InterestRate"];
					loan.LoanTerm = (int)reader["LoanTerm"];
					loan.PrincipalAmount = Convert.ToDouble(reader["PrincipalAmount"]);
					loan.LoanType = (string)reader["LoanType"];
					loan.LoanStatus = (string)reader["LoanStatus"];

					loans.Add(loan);
				}
			}
			return loans;
		}

		public Loan GetLoanById(int loanId)
		{
			Loan loan = new Loan();
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				_cmd.CommandText = $"select * from Loans where LoanID = {loanId}";
				_cmd.Connection = sqlConnection;
				sqlConnection.Open();
				SqlDataReader reader = _cmd.ExecuteReader();
				if (reader.Read())
				{
					loan.LoanId = (int)reader["LoanID"];
					loan.CustomerId = (int)reader["CustomerID"];
					loan.InterestRate = (int)reader["InterestRate"];
					loan.LoanTerm = (int)reader["LoanTerm"];
					loan.PrincipalAmount = Convert.ToDouble(reader["PrincipalAmount"]);
					loan.LoanType = (string)reader["LoanType"];
					loan.LoanStatus = (string)reader["LoanStatus"];
				}
			}
			return loan;
		}

	}
}
