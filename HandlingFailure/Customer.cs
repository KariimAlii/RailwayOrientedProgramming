using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingFailure
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string RefillBalance(int customerId, decimal moneyAmount)
        {
            if (moneyAmount <= 0) // 2- use a value object to wrap the business logic in it
                return "Money Amount is invalid";

            var _database = new Database();

            Customer? customer = _database.GetById(customerId); // 1- Signature should be honest that there is possibility to return null

            if (customer == null)
                return "Customer is not found";

            try
            {
                customer.Balance = moneyAmount;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

            try
            {
                _database.Save(customer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

            return "Ok";
        }
    }
}
