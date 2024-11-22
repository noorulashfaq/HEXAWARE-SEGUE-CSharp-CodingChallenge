using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Exceptions
{
	internal class InvalidLoanException: ApplicationException
	{
		public InvalidLoanException() { }
		public InvalidLoanException(string msg) : base(msg)
		{

		}
	}
}
