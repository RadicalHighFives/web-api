using System;
using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Data
{
	public class WebAppDbContext : DbContext
	{
		public WebAppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Customer> Customer { get; set; }
	}
}

