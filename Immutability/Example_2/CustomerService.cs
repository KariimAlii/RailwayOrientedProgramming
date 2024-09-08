using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability.Example_2
{
    public class CustomerService_Mutable
    {
        private Address _address;
        private Customer _customer;

        public void Process (string customerName, string addressString)
        {
            // They should be called in this order
            CreateAddress(addressString);
            CreateCustomer(customerName);
            SaveCustomer();
        }

        public void CreateCustomer(string customerName)
        {
            // The Result of the CreateCustomer() operation is hidden under a side effect
            _customer = new Customer(customerName, _address);
        }
        public void CreateAddress(string addressString)
        {
            _address = new Address(addressString);
        }
        public void SaveCustomer()
        {
            var repository = new CustomerRepository();
            repository.AddCustomer(_customer);
        }
    }
    public class CustomerService_ImMutable
    {
        // When we make the signature of the methods honest ➡️➡️ There is no need for state anymore

        // Command ==> Returns void ==> has Side Effect
        public void Process(string customerName, string addressString)
        {
            var address = CreateAddress(addressString);
            var customer = CreateCustomer(customerName, address);
            SaveCustomer(customer); // ➡️➡️ Side Effect 🚀🚀
        }
        // Query ==> Returns non-void ==> No Side Effect
        public Customer CreateCustomer(string customerName, Address address)
        {
            return new Customer(customerName, address);
        }
        // Query ==> Returns non-void ==> No Side Effect
        public Address CreateAddress(string addressString)
        {
            return new Address(addressString);
        }

        // Command ==> Returns void ==> has Side Effect
        public void SaveCustomer(Customer customer)
        {
            var repository = new CustomerRepository();
            repository.AddCustomer(customer); // ➡️➡️ Saving a Customer to the Database is a Side Effect 🚀🚀
        }
    }

    // 🚩🚩 Command - Query Separation Principle
    //  Command                                    Query
    //  1) Produces Side Effects                   1) Side Effect Free
    //  2) Returns Void                            2) Returns non-void

}
