using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveObsession
{
    public class UsernameVO : ValueObject<UsernameVO>
    {
        private readonly string _value;
        private UsernameVO(string value)
        {
            _value = value;
        }
        public static Result<UsernameVO> CreateUsername(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Fail<UsernameVO>("Username cannot be empty");

            if (value.Length > 255)
                return Result.Fail<UsernameVO>("Username too long");

            return Result.Ok<UsernameVO>(new UsernameVO(value));
        }
        public override bool EqualsCore(UsernameVO valueObject)
        {
            return _value == valueObject._value;
        }

        public override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }
        public static explicit operator UsernameVO(string value)
        {
            return CreateUsername(value).Value;
        }
        public static implicit operator string(UsernameVO usernameVO)
        {
            return usernameVO._value;
        }
    }
}
