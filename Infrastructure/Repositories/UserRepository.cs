using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return (await GetByConditionAsync(x => x.Email == email)).FirstOrDefault();
        }
    }
}
