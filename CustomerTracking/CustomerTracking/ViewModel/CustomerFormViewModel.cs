using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerTracking.Models;

namespace CustomerTracking.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}