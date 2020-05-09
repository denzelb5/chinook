using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chinook.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chinook.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //GET: api/Employee/sales
        [HttpGet(template: "{employee}")]
        public ActionResult<List<Employee>>GetByEmployee(string employee)
        {
            var repo = new EmployeeRepository();
            var totalSales = repo.GetByEmployee(employee);

            if (!totalSales.Any())
            {
                return NotFound();
            }

            return totalSales;
        }

        //GET: api/Employee/Customer/CustomerId
    }

   
}
