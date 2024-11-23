using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string? Email { get;  set; }
        public Address? Address { get; set; }

        public string PasswordHash { get; private set; }
        public string Role { get; private set; }

        public User(string name, string email, string passwordHash, string role)
        {
            Name=name;
            Email=email;
            PasswordHash=passwordHash;
            Role=role;
        }

        public void UpdatePassword(string passwordHash)
        {
            PasswordHash=passwordHash;
        }



        public ICollection<Order> Orders { get; set; }

    }
}
