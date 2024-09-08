using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingWithExceptions
{
    public static class CustomerExceptions
    {
        public const string DuplicateCustomerIdException = "Already existing Customer Id";
        public const string CustomerExceededLimit = "Cannot Save : Customers exceeded limit";
        public const string InvalidCustomerId = "Invalid Customer Id";
    }
}
