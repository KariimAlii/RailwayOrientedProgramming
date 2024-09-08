namespace PrimitiveObsession.UI.Models
{
    public class CustomerRepo_Refactor
    {
        private static List<Customer_Refactor> Customers = new List<Customer_Refactor>()
        {
            new Customer_Refactor((UsernameVO)"Karim",(EmailVO)"k@gmail.com"),
            new Customer_Refactor((UsernameVO)"Rana", (EmailVO)"r@gmail.com"),
            //new Customer_Refactor(null, null), ➡️➡️ Exception at Runtime
        };

        public void AddCustomer(Customer_Refactor customer)
        {
            Customers.Add(customer); 
        }
    }
}
