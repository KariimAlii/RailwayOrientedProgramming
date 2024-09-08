using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability.Example_2
{
    public class Address
    {
        private string _value;
        public Address(string value)
        {
            _value = value;
        }
        public Address CreateAddress(string value) => new Address(value); 
    }
}
