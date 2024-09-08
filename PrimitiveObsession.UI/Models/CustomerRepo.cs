namespace PrimitiveObsession.UI.Models
{
    public class CustomerRepo
    {
        private static List<Customer> Customers = new List<Customer>()
        {
            new Customer("Karim","k@gmail.com"),
            new Customer("Rana", "r@gmail.com"),
        };

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer); 
        }
    }
}
