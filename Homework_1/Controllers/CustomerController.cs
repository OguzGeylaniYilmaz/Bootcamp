using Homework_1.Entities;
using Homework_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Homework_1.Extensions.CustomerExtensions;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Customer> customers;

        public CustomerController()
        {
            customers = new List<Customer>();
            customers.Add(new Customer { ID = 1, Name = "Julia", LastName = "Roberts", Mail = "example@gmail.com", Phone = "(444) 333 222", Status = true });
            customers.Add(new Customer { ID = 2, Name = "Max", LastName = "Thunder", Mail = "example2@gmail.com", Phone = "(444) 222 111", Status = true });
            customers.Add(new Customer { ID = 3, Name = "Robert", LastName = "Sky", Mail = "example3@gmail.com", Phone = "(444) 444 000", Status = true });
            customers.Add(new Customer { ID = 4, Name = "Anakin", LastName = "Skywalker", Mail = "example4@gmail.com", Phone = "(444) 666 555", Status = false });
            customers.Add(new Customer { ID = 5, Name = "Padme", LastName = "Amidala", Mail = "example5@gmail.com", Phone = "(444) 777 111", Status = true });
        }


        // GET: api/<CustomertController>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            if (customers.Count == 0)
                return NotFound("The list is empty");
            customers.RemoveDuplicates(); //Extension method çağırımı
            return Ok(customers.Where(x => x.Status == true).ToList());
        }


        [HttpGet]
        [Route("GetCustomerFilter")]
        public IActionResult Get([FromQuery] string name, string mail)
        {
            var value = customers.Where(x => x.Name.ToUpper().Contains(name.ToUpper()) || x.Mail.ToUpper().Contains(mail.ToUpper())).FirstOrDefault();
            return Ok(value);
        }

        // GET api/<CustomerController>/3
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            if (id > 0)
            {
                var customer = customers.FirstOrDefault(x => x.ID == id);
                return Ok(customer);
            }
            else
                return NotFound("Customer not found");
        }


        //POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] PostCustomerModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please check your informations");
            else
            {
                customers.Add(new Customer()
                {
                    ID = value.CustomerID,
                    Name = value.CustomerName,
                    LastName = value.CustomerLastName,
                    Phone = value.CustomerPhone,
                    Mail = value.CustomerPhone,
                    Status = value.CustomerStatus
                });
            }
            return Ok(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PutCustomerModel value)
        {
            var existingCustomer = customers.Where(x => x.ID == id).FirstOrDefault();
            if (existingCustomer == null)
            {
                existingCustomer = new Customer
                {
                    ID = id,
                    Name = value.CustomerName,
                    LastName = value.CustomerLastName,
                    Mail = value.CustomerMail,
                    Phone = value.CustomerPhone,
                    Status = value.CustomerStatus
                };
                return CreatedAtRoute("Get", new { id = id }, existingCustomer);
            }

            //Sadece isim, soyisim ve mail bilgisini aldım.


            existingCustomer.Name = value.CustomerName;
            existingCustomer.LastName = value.CustomerLastName;
            existingCustomer.Mail = value.CustomerMail;





            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid customer id");
            else
            {
                var deletedCustomer = customers.Where(x => x.ID == id).FirstOrDefault();
                customers.Remove(deletedCustomer);
                return Ok();
            }
        }

    }
}
