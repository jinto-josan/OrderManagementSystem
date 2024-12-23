﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IUserRepository:IBaseRepository<User>
    {
        public Task<User> GetUserByEmail(string email);
    }
}
