using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveObsession
{
    public class EmailVO : ValueObject<EmailVO>
    {
        private readonly string _value; // Readonly ➡️➡️ Immutable
        private EmailVO(string value)
        {
            _value = value;
        }
        public static Result<EmailVO> CreateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<EmailVO>("Email cannot be empty");

            email = email.Trim();

            if (email.Length > 255)
                return Result.Fail<EmailVO>("Email is too long");

            if (!email.Contains("@"))
                return Result.Fail<EmailVO>("Invalid Email");

            return Result.Ok<EmailVO>(new EmailVO(email));
        }
        
        

        // 🚩🚩string ----Explicit----> Email
        // Explicit Conversion because it is not safe 
        // Not Safe because not all strings are valid emails
        // var email = (Email)"k@gmail.com" ➡️➡️ ✅
        // var email = (Email)"karim"       ➡️➡️ ❌ throws exception
        public static explicit operator EmailVO(string value)
        {
            return CreateEmail(value).Value;
        }

        // 🚩🚩Email ----Implicit----> string
        // Implicit Conversion because it is safe 
        // Safe because every email is a string
        // var email = Email.Create("k@gmail.com")
        // string value = email;
        public static implicit operator string(EmailVO email)
        {
            return email._value;
        }

        // 🚩🚩string ----Implicit----> Email
        // Not Safe because not every string is an email
        // Email email = "k@gmail.com"
        //public static implicit operator Email(string value)
        //{
        //    return CreateEmail(value).Value;
        //}

        public override bool EqualsCore(EmailVO other)
        {
            return _value == other._value;
        }

        public override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

    }
}
