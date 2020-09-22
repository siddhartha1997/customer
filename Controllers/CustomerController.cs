using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        Uri baseAddress = new Uri("https://localhost:44379/api");   //Port No.
        HttpClient client;

        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
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
        [Route("getCustomerDetails")]
        public Customer getCustomerDetails(int id)
        {
            Customer customer = customerList.Find(u => u.id == id);
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("createCustomer")]
        public string createCustomer([FromBody] Customer customer)
        {
            Customer cust = new Customer();
            customerList.Add(customer);
            string data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Account/createAccount/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                /*string data1 =*/ return response.Content.ReadAsStringAsync().Result;
                /*cust = JsonConvert.DeserializeObject<Customer>(data1);
                return cust.ToString();*/
            }
            return "Account Creation Failed";
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
