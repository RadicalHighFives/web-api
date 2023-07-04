using System;
using web_api.Data;
using web_api.Models;

namespace web_api.Repository
{
	public class EmployeeRepository : IEmployeeRepository { 

        private WebAppDbContext _dbContext;

		public EmployeeRepository(WebAppDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public async Task<List<Employee>> GetAllEmployees()
        {
            var result = _dbContext.Employees.ToList();
            return await Task.FromResult(result);
        }

        public async Task<Guid> CreateEmployee(Employee employee) {

            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee.Id;
        }
    }
}

