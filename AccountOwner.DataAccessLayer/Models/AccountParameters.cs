using System;
using System.Collections.Generic;
using System.Text;

namespace AccountOwner.DataAccessLayer
{
	public class AccountParameters : QueryStringParameters
	{
		public AccountParameters()
		{
			OrderBy = "DateCreated";
		}

		public uint MinYearCreated { get; set; }
		public uint MaxYearCreated { get; set; } = (uint)DateTime.Now.Year;
		public bool ValidYearRange => MaxYearCreated > MinYearCreated;

		public string AccountType { get; set; }
	}
}
