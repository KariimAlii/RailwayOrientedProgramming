using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingFailure
{
    public class Database
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "Karim",   Balance = 15_000 },
            new Customer { Id = 2, Name = "Rana",    Balance = 25_000 },
            new Customer { Id = 3, Name = "Marawan", Balance = 30_000 },
        };
        public Customer? GetById(int id)
        {
            var customer = Customers.FirstOrDefault(customer => customer.Id == id);
            return customer;
        }
        public void Save(Customer customer)
        {
            if (customer.Id == 1) throw new Exception("Nooooo Saving");
        }
    }
}
