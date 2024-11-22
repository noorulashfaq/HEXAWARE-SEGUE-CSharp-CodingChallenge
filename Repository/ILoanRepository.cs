using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
	internal interface ILoanRepository
	{
		int ApplyLoan(Loan loan);
		double CalcInterest(int loanId);
		double CalcEMI(int loanId);

		List<Loan> GetAllLoans();
		Loan GetLoanById(int loanId);
	}
}
