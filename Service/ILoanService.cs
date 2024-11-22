using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Service
{
	internal interface ILoanService
	{
		void GetAllLoans();
		void GetLoanById();
		void ApplyNewLoan();
		void AddNewCustomer();
		void CalcInterest();
		void GetLoanStatus();


	}
}
