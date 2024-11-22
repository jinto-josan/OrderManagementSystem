using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
