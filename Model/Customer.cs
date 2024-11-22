using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Model
{
	internal class Customer
	{
		int _customerId, _creditScore;
		string _name, _email, _address;
		long _phoneNumber;

		public int CustomerId
		{
			get { return _customerId; }
			set { _customerId = value; }
		}

		public int CreditScore
		{
			get { return _creditScore; }
			set { _creditScore = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public long PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		public override string ToString()
		{
			return $"Customer ID: {CustomerId}\n" +
				$"Name: {Name}\n" +
				$"Email : {Email}\n" +
				$"Phone number: {PhoneNumber}\n" +
				$"Address: {Address}\n" +
				$"Credit Score: {CreditScore}\n";
		}
	}
}
