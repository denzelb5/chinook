using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chinook.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chinook.Controllers
{
    [Route("api/Invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetInvoicesByEmployee()
        {
            var repo = new InvoiceRepository();
            var invoices = repo.GetInvoicesByEmployee();

            if (!invoices.Any())
            {
                return NotFound();
            }

            return Ok(invoices);

        }







    }
}
