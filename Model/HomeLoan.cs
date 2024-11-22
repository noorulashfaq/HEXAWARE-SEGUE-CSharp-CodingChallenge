using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
	internal class HomeLoan : Loan
	{
		string _propertyAddress;
		int _propertyValue;

		public HomeLoan()
		{

		}

		public HomeLoan(string propertyAddress, int propertyValue, int customerId, int interestRate, int loanTerm, double principalAmount, string loanType, string loanStatus) : base(customerId, interestRate, loanTerm, principalAmount, loanType, loanStatus)
		{
			PropertyAddress = propertyAddress;
			PropertyValue = propertyValue;
		}

		public string PropertyAddress
		{
			get { return _propertyAddress; }
			set { _propertyAddress = value; }
		}

		public int PropertyValue
		{
			get { return _propertyValue; }
			set { _propertyValue = value; }
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
				$"Property address: {PropertyAddress}\n" +
				$"Property value: {PropertyValue}\n";
		}
	}
}
