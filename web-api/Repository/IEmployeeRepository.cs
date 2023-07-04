using System;
using web_api.Models;

namespace web_api.Repository
{
	public interface IEmployeeRepository
	{
		public Task<List<Employee>> GetAllEmployees();
		public Task<Guid> CreateEmployee(Employee employee);
    }
}

