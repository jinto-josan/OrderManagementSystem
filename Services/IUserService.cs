using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {


        public Task<User> RegisterUserAsync(string name, string email, string password, string role);



        public  Task<User> GetUserByIdAsync(Guid userId);
        
    }
}
