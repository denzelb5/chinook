using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chinook.Model
{
    public class CustomerWithInvoices
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceId { get; set; }
    }
}
