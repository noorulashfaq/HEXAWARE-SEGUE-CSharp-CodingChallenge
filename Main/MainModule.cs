using LoanManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Main
{
	internal class MainModule
	{
		public void Run()
		{
			Console.WriteLine("----------Loan Management System----------");
			int userChoice = 0;
			do
			{
				ILoanService loanService = new LoanService();
				Console.Write("Main menu:\n" +
					"\t1.Get all loans\n" +
					"\t2.Get loan by ID\n" +
					"\t3.Apply new loan\n" +
					"\t4.Register new customer\n" +
					"\t5.Calculate Interest\n" +
					"\t6.Get loan status\n" +
					"\t7.Exit\n" +
					"Enter your choice: ");
				userChoice = int.Parse(Console.ReadLine());
				switch (userChoice)
				{
					case 1:
						loanService.GetAllLoans();
						break;

					case 2:
						loanService.GetLoanById();
						break;

					case 3:
						loanService.ApplyNewLoan();
						break;

					case 4:
						loanService.AddNewCustomer();
						break;

					case 5:
						loanService.CalcInterest();
						break;

					case 6:
						loanService.GetLoanStatus();
						break;

					case 7:
						Console.WriteLine("Exiting the application...");
						break;

					default:
						Console.WriteLine("Invalid choice!!");
						break;
				}
			} while (userChoice != 7);
		}
	}
}
