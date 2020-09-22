using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customerList = new List<Customer>
        {
            new Customer{id=1,Name="S B",DOB="05/09/1997",Address="ABC",PanNo="CGLBP1000",Email="sb@gmail.com",Password="123456"}
        };
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer getCustomerDetails(int id)
        {
            Customer customer = customerList.Find(u => u.id == id);
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public string createCustomer([FromBody] Customer customer)
        {
            customerList.Add(customer);
            return "Success";
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
