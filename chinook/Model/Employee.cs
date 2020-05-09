using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chinook.Model
{
    public class Employee
    {
        public int EmployeeId { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Title { get; internal set; }
    }
}
