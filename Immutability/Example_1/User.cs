using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability.Example_1
{
    public class UserProfile
    {
        // Stateful ( Mutable )
        private User _User;
        private string _Address;

        // Because User is ImMutable ➡️➡️ The Only way to update the user is to create a new instance
        // UpdateUser() ➡️➡️ leaves a Side Effect by changing the State

        // Side Effect makes your method signature DisHonest
        public void UpdateUser(int userId, string name)
        {
            _User = new User(userId, name);
        }
    }

    // Refactoring to Immutable Architecture
    public class UserProfile_Immutable
    {
        // Stateless ( ImMutable )
        private readonly User _User;
        private readonly string _Address;

        public UserProfile_Immutable(User user, string address)
        {
            _User = user;
            _Address = address;
        }
        public UserProfile_Immutable UpdateUser(int userId, string name)
        {
            var user = new User(userId, name);
            return new UserProfile_Immutable(user, _Address);
        }
    }
    public class User
    {
        // Mutable ( Setter ) ➡️➡️ StateFul
        // public int Id { get; set; }
        // public string Name { get; set; }

        // ImMutable ( All properties are Read-Only ) ➡️➡️ Stateless
        public int Id { get; }
        public string Name { get; }
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
