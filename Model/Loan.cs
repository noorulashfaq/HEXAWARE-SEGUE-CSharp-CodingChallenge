using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
	internal class Loan
	{
		int _loanId, _customerId, _interestRate, _loanTerm;
		double _principalAmount;
		string _loanType, _loanStatus;

		public Loan()
		{

		}

		public Loan(int customerId, int interestRate, int loanTerm,  double principalAmount, string loanType, string loanStatus)
		{
			CustomerId = customerId;
			InterestRate = interestRate;
			LoanTerm = loanTerm;
			PrincipalAmount = principalAmount;
			LoanType = loanType;
			LoanStatus = loanStatus;
		}

		public int LoanId
		{
			get { return _loanId; }
			set { _loanId = value; }
		}

		public int CustomerId
		{
			get { return _customerId; }
			set { _customerId = value; }
		}

		public int InterestRate
		{
			get { return _interestRate; }
			set { _interestRate = value; }
		}

		public int LoanTerm
		{
			get { return _loanTerm; }
			set { _loanTerm = value; }
		}

		public double PrincipalAmount
		{
			get { return _principalAmount; }
			set { _principalAmount = value; }
		}

		public string LoanType
		{
			get { return _loanType; }
			set { _loanType = value; }
		}

		public string LoanStatus
		{
			get { return _loanStatus; }
			set { _loanStatus = value; }
		}

		public override string ToString()
		{
			return $"Loan ID: {LoanId}\n" +
				$"Customer ID: {CustomerId}\n" +
				$"Interest rate: {InterestRate}\n" +
				$"Principal Amount: {PrincipalAmount}\n" +
				$"Loan term: {LoanTerm}\n" +
				$"Loan type: {LoanType}\n" +
				$"Loan status: {LoanStatus}\n";
		}
	}
}
