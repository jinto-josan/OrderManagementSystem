using Domain.Entities.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public Address? Address { get; set; }

        public string PasswordHash { get; private set; }
        public Role Role { get; private set; } =Role.Guest;

        public User(string name, string email, string passwordHash)
        {
            Name=name;
            Email=email;
            PasswordHash=passwordHash;
        }
        public void UpdateRole(Role role)
        {
            Role=role;
        }

        public void UpdateEmail(string email)
        {
            Email=email;
        }
        public void UpdateName(string name) {
            Name=name; 
        }

        public void UpdatePassword(string passwordHash)
        {
            PasswordHash=passwordHash;
        }

        public ICollection<Order> Orders { get; set; }

    }
}
