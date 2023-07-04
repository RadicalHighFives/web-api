using System;
using web_api.Models;

namespace web_api.Repository
{
	public interface ICustomerRepository
	{
		public Task<List<Customer>> GetCustomers();
		public Task<Guid> CreateCustomer(Customer customer);
        public Task<Customer> GetById(Guid id);
		public Task<Customer> UpdateCustomer(Guid id, Customer customer);
		public Task<string> DeleteCustomer(Guid id);
    }
}

