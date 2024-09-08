using System.Xml.Linq;

namespace PrimitiveObsession.UI.Models
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Customer(string name, string email)
        {
            ChangeName(name);
            ChangeEmail(email);
        }
        public void ChangeName(string name)
        {
            // 🚩🚩Validation
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 50)
                throw new ArgumentException("Name is invalid");

            Name = name;
        }
        public void ChangeEmail(string email)
        {
            // 🚩🚩Validation
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                throw new ArgumentException("Email is invalid");
            // 🚩🚩Validation
            if (!email.Contains('@'))
                throw new ArgumentException("Email Domain is invalid");

            Email = email;
        }
    }
}
