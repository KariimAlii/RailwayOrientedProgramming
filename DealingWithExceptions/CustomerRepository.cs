using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingWithExceptions
{
    public class CustomerRepository
    {
        public static bool ConnectionSuccess = false;

        public static List<Customer> Customers = new()
        {
            new Customer {Id = 1, Name = "Karim"},
            new Customer {Id = 2, Name = "Rana"},
        };
        public void AddCustomer(Customer customer)
        {
            if (Customers.Any(c => c.Id == customer.Id))
                throw new InvalidDataException(CustomerExceptions.DuplicateCustomerIdException);
        }
        public void SaveChanges()
        {
            if (Customers.Count > 3)
                throw new InvalidDataException(CustomerExceptions.CustomerExceededLimit);

            if (!ConnectionSuccess)
                throw new ApplicationException("Bad Connection");
        }

        // Dishonest Signature ❌❌
        //public void SaveCustomer(Customer customer)
        //{
        //    AddCustomer(customer);
        //    SaveChanges();
        //}

        // Honest Signature ✅✅
        // 🚩🚩 Return a Value to define an Expected Failure ✅✅
        public bool SaveCustomer(Customer customer)
        {
            try
            {
                AddCustomer(customer);
                SaveChanges();
                return true;
            }
            catch (InvalidDataException ex)
            {
                if (ex.Message == CustomerExceptions.DuplicateCustomerIdException)
                    return false;
                if (ex.Message == CustomerExceptions.CustomerExceededLimit)
                    return false;  // 🚩🚩 Return a Value to define an Expected Failure ✅✅
                throw; // 🚩🚩 UnExpected Exception Message ➡️➡️ Fail Fast 🚀🚀
            }

            // 🚩🚩 Don't Use General Exception
            // 🚩🚩 If any UnExpected Exception Occurs ➡️➡️ Fail Fast 🚀🚀

            //catch (Exception ex)         ❌❌❌
            //{
            //   
            //    
            //}
        }

        public string SaveCustomer_ReturnMessage(Customer customer)
        {
            try
            {
                AddCustomer(customer);
                SaveChanges();
                return string.Empty;
            }
            catch (InvalidDataException ex)
            {
                if (ex.Message == CustomerExceptions.DuplicateCustomerIdException)
                    return "Duplicate Customer ID";
                if (ex.Message == CustomerExceptions.CustomerExceededLimit)
                    return "Customer Exceeded Limit";  // 🚩🚩 Return a Value to define an Expected Failure ✅✅
                
                throw; // 🚩🚩 UnExpected Exception Message ➡️➡️ Fail Fast 🚀🚀
            }
        }

        //public Customer GetCustomer(int id)
        //{

        //}
    }
}
