using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class UserRoleChangeEvent:EventArgs
    {
        public Guid UserId { get; init; }
        public Role UserRole { get; init; }
        public UserRoleChangeEvent(Guid userId, Role role)
        {
            UserId = userId;
            UserRole=role;
        }
    }
}
