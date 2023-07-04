using System;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
        private readonly WebAppDbContext _dbContext;

        public CustomerRepository(WebAppDbContext webAppDbContext)
		{
			_dbContext = webAppDbContext;
		}

		public async Task<List<Customer>> GetCustomers()
		{
			var result = _dbContext.Customer.ToList();
			return await Task.FromResult(result);
        }

		public async Task<Guid> CreateCustomer(Customer customer) {
			await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
			return customer.Id;
		}

		public async Task<Customer> GetById(Guid id) {
			var customer = await _dbContext.Customer.Where(custId => custId.Id == id).FirstOrDefaultAsync();
			return customer;
		}

		public async Task<Customer> UpdateCustomer(Guid id, Customer customer) {

			var customerUpdate = await _dbContext.Customer.Where(custId => custId.Id == id).FirstOrDefaultAsync();

			customerUpdate.Email = customer.Email;
			customerUpdate.Name = customer.Name;
			customerUpdate.Phone = customer.Phone;
			await _dbContext.SaveChangesAsync();
			return customerUpdate;
		}

		public async Task<string> DeleteCustomer(Guid id) {

            var customerToDelete = _dbContext.Customer.Where(custId => custId.Id == id).FirstOrDefault();
			if (customerToDelete == null) { return "Customer does not exist."; }

			_dbContext.Customer.Remove(customerToDelete);
			await _dbContext.SaveChangesAsync();
			return "Customer details deleted.";
        }
    }
}

