using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using chinook.DataAccess;
using chinook.Model;

namespace chinook.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       //GET: api/Customer/country/brazilCustomers
       [HttpGet(template:"{country}/brazilCustomers")]
        public ActionResult<List<Customer>> GetByCountry(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetByCountry(country);

            if (!customers.Any())
            {
                return NotFound();

            }

            return customers;
        }

        //GET:  api/Customer/country/nonUsaCustomers
        [HttpGet(template:"{country}/nonUsaCustomers")]
        public ActionResult<List<Customer>> GetNonUsaByCountry(string country)
        {
            var repo = new CustomerRepository();
            var nonUsaCustomers = repo.GetNonUsaByCountry(country);

            if (!nonUsaCustomers.Any())
            {
                return NotFound();

            }
            return nonUsaCustomers;
        }

        //GET: api/Customer/country/brazilCustomerInvoices
        [HttpGet(template: "{country}/brazilCustomerInvoices")]
        public ActionResult<List<CustomerWithInvoices>> GetBrazilCustomerInvoices(string country)
        {
            var repo = new CustomerRepository();
            var brazilCustomerInvoices = repo.GetBrazilCustomerInvoices(country);

            if (!brazilCustomerInvoices.Any())
            {
                return NotFound();
            }

            return brazilCustomerInvoices;
        }














        //// POST: api/Chinook
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Chinook/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
