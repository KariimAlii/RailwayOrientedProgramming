using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveObsession
{
    public class Email
    {
        private readonly string _value;
        private Email(string value)
        {
            _value = value;
        }
        public static Result<Email> CreateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<Email>("Email cannot be empty");

            email = email.Trim();

            if (email.Length > 255)
                return Result.Fail<Email>("Email is too long");

            if (!email.Contains("@"))
                return Result.Fail<Email>("Invalid Email");

            return Result.Ok<Email>(new Email(email));
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Email) || ReferenceEquals(obj,null)) 
                return false;

            Email email = (Email)obj;

            return _value == email._value;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        // 🚩🚩string ----Explicit----> Email
        // Explicit Conversion because it is not safe 
        // Not Safe because not all strings are valid emails
        // var email = (Email)"k@gmail.com" ➡️➡️ ✅
        // var email = (Email)"karim"       ➡️➡️ ❌ throws exception
        public static explicit operator Email(string value)
        {
            return CreateEmail(value).Value;
        }

        // 🚩🚩Email ----Implicit----> string
        // Implicit Conversion because it is safe 
        // Safe because every email is a string
        // var email = Email.Create("k@gmail.com")
        // string value = email;
        public static implicit operator string(Email email)
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



    }
}
