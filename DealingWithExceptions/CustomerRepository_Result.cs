using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingWithExceptions
{
    public class CustomerRepository_Result
    {
        public static bool ConnectionSuccess = false;

        public static List<Customer> Customers = new()
        {
            new Customer {Id = 1, Name = "Karim"},
            new Customer {Id = 2, Name = "Rana"},
        };
        public void CreateCustomer(int id, string name)
        {
            var customer = new Customer { Id = id, Name = name };
            var result = SaveCustomer(customer);
            if (result.IsFailure)
            {
                Console.WriteLine(result.Error);
            }
        }

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

        // Honest Signature ✅✅
        // 🚩🚩 Return a Value to define an Expected Failure ✅✅


        public Result SaveCustomer(Customer customer)
        {
            try
            {
                AddCustomer(customer);
                SaveChanges();
                return Result.Ok();
            }
            catch (InvalidDataException ex)
            {
                if (ex.Message == CustomerExceptions.DuplicateCustomerIdException)
                    return Result.Fail("Duplicate Customer ID");
                if (ex.Message == CustomerExceptions.CustomerExceededLimit)
                    return Result.Fail( "Customer Exceeded Limit");  // 🚩🚩 Return a Value to define an Expected Failure ✅✅

                throw; // 🚩🚩 UnExpected Exception Message ➡️➡️ Fail Fast 🚀🚀
            }
        }
        public Result<Customer> GetCustomer(int id)
        {
            //var customer = Customers.FirstOrDefault(c => c.Id == id);

            //if (customer == null)
            //    return Result.Fail<Customer>("Invalid Customer Id");

            //return Result.Ok<Customer>(customer);

            try
            {
                var customer = Customers.Single(c => c.Id == id);
                return Result.Ok<Customer>(customer);
            }
            catch (Exception ex)
            {
                if (ex.Message == CustomerExceptions.InvalidCustomerId)
                    return Result.Fail<Customer>("Invalid Customer Id");

                throw;
            }
        }

    }
}
