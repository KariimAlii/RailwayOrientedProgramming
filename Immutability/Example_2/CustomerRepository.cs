using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability.Example_2
{
    public class CustomerRepository
    {
        public static List<Customer> Customers = new List<Customer>();
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
