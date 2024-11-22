using LoanManagementSystem.Exceptions;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Service
{
	internal class LoanService : ILoanService
	{
		readonly ILoanRepository _loanRepository;
		readonly ICustomerRepository _customerRepository;
		public LoanService()
		{
			_loanRepository = new LoanRepository();
			_customerRepository = new CustomerRepository();
		}

		public void GetAllLoans()
		{
			try
			{
				List<Loan> allLoans = _loanRepository.GetAllLoans();
				if (allLoans.Count == 0)
				{
					Console.WriteLine("No loans found");
					return;
				}
				Console.WriteLine("----------------------------------------------------\nListing all loans");
				Console.WriteLine("---------------------\n");
				foreach (Loan loan in allLoans)
				{
					Thread.Sleep(250);
					Console.WriteLine(loan);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetLoanById()
		{
			try
			{
				Console.Write("\nEnter Loan ID: ");
				int loanId = int.Parse(Console.ReadLine());
				Loan loan = _loanRepository.GetLoanById(loanId);
				if (loan == null)
				{
					throw new InvalidLoanException("Loan is not found");
				}
				else
				{
					Console.WriteLine("Loan details:");
					Console.WriteLine(loan);

				}
			}
			catch(InvalidLoanException ile)
			{
				Console.WriteLine(ile.Message);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void ApplyNewLoan()
		{
			try
			{
				Loan loan = new Loan();

				Console.WriteLine("\nEnter particulars of the Loan");

				Console.Write("=> Enter Customer ID: ");
				loan.CustomerId = int.Parse(Console.ReadLine());

				Console.Write("=> Enter principal amount: ");
				loan.PrincipalAmount = double.Parse(Console.ReadLine());

				Console.Write("=> InterestRate: ");
				loan.InterestRate = int.Parse(Console.ReadLine());

				Console.Write("=> Loan term (Tenure in months): ");
				loan.LoanTerm = int.Parse(Console.ReadLine());

				Console.WriteLine("=> Loan type (Car loan/Home loan):");
				loan.LoanType = Console.ReadLine();

				int addLoanStatus = _loanRepository.ApplyLoan(loan);

				if (addLoanStatus > 0)
				{
					Console.WriteLine("New loan applied successfully\n");
				}
				else
				{
					Console.WriteLine("Oops! The loan details could not be registered. Please try again!\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

		public void AddNewCustomer()
		{
			try
			{
				Customer customer = new Customer();

				Console.WriteLine("\nEnter particulars of the Customer");

				Console.Write("=> Name: ");
				customer.Name = Console.ReadLine();

				Console.Write("=> Email: ");
				customer.Email = Console.ReadLine();

				while (true)
				{
					Console.Write("=> Phone number: ");
					customer.PhoneNumber = long.Parse(Console.ReadLine());
					if(customer.PhoneNumber.ToString().Length == 10)
					{
						break;
					}
				}

				Console.Write("=> Address: ");
				customer.Address = Console.ReadLine();

				Console.Write("=> Credit Score: ");
				customer.CreditScore = int.Parse(Console.ReadLine());

				int addCustomerStatus = _customerRepository.AddNewCustomer(customer);

				if (addCustomerStatus > 0)
				{
					Console.WriteLine("New customer added successfully\n");
				}
				else
				{
					Console.WriteLine("Oops! Customer could not be registered. Please try again!\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

		public void CalcEMI()
		{
			try
			{
				Console.Write("\nEnter Loan ID: ");
				int loanId = int.Parse(Console.ReadLine());
				Console.WriteLine("The EMI is: " + _loanRepository.CalcEMI(loanId));
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void CalcInterest()
		{
			try
			{
				Console.Write("\nEnter Loan ID: ");
				int loanId = int.Parse(Console.ReadLine());
				Console.WriteLine("The interest is: " + _loanRepository.CalcInterest(loanId));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetLoanStatus()
		{
			try
			{
				Console.Write("\nEnter Loan ID: ");
				int loanId = int.Parse(Console.ReadLine());
				Loan loan = _loanRepository.GetLoanById(loanId);
				if (loan == null)
				{
					throw new InvalidLoanException("Loan is not found");
				}
				else
				{
					Console.WriteLine("Loan status: " +loan.LoanStatus);
				}
			}
			catch (InvalidLoanException ile)
			{
				Console.WriteLine(ile.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
