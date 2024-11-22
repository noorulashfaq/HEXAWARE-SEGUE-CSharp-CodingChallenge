using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
	internal class CarLoan: Loan
	{
		string _carModel;
		int _carValue;

		public CarLoan()
		{

		}

		public CarLoan(string carModel, int carValue, int customerId, int interestRate, int loanTerm, double principalAmount, string loanType, string loanStatus) : base(customerId, interestRate, loanTerm, principalAmount, loanType, loanStatus)
		{
			CarModel = carModel;
			CarValue = carValue;
		}

		public string CarModel
		{
			get { return _carModel; }
			set { _carModel = value; }
		}

		public int CarValue
		{
			get { return _carValue; }
			set { _carValue = value; }
		}

		public override string ToString()
		{
			return $"Loan ID: {LoanId}\n" +
				$"Customer ID: {CustomerId}\n" +
				$"Interest rate: {InterestRate}\n" +
				$"Principal Amount: {PrincipalAmount}\n" +
				$"Loan term: {LoanTerm}\n" +
				$"Loan type: {LoanType}\n" +
				$"Loan status: {LoanStatus}\n" +
				$"Car model: {CarModel}\n" +
				$"Car Value: {CarValue}\n";
		}
	}
}
