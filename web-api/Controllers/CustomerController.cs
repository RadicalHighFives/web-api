using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.Repository;
using web_api.Models;


namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerRepository.GetCustomers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customerRequest) {
            customerRequest.Id = Guid.NewGuid();
            var res = await _customerRepository.CreateCustomer(customerRequest);
            return Ok(customerRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] Guid id) {

            var customer = await _customerRepository.GetById(id);

            if (customer == null) {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, Customer updateCustomerRequest) {

            var custResponse = await _customerRepository.UpdateCustomer(id, updateCustomerRequest);
            if (custResponse == null) { return NotFound(); }

            return Ok(custResponse);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id) {

            var cust = await _customerRepository.DeleteCustomer(id);
            return Ok(cust);

        }
    }
}

