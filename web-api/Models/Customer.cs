
using System;
namespace web_api.Models
{
	public class Customer
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

        public long Phone { get; set; }

    }
}

