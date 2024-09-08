using System.Xml.Linq;

namespace PrimitiveObsession.UI.Models
{
    public class Customer_Refactor
    {
        public UsernameVO Name { get; private set; }
        public EmailVO Email { get; private set; }

        public Customer_Refactor(UsernameVO name, EmailVO email)
        {

            // 🚩🚩 You don't need in case you use NonNullables.Fody
            //if (name == null)
            //    throw new ArgumentNullException(nameof(name));
            //if (email == null)
            //    throw new ArgumentNullException(nameof(email));

            Name = name;
            Email = email;
        }
        public void ChangeName(UsernameVO name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }
        public void ChangeEmail(EmailVO email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}
