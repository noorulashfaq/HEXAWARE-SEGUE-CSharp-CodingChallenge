using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
	internal interface ICustomerRepository
	{
		int AddNewCustomer(Customer customer);
		Customer GetCustomersById(int custId);
	}
}
