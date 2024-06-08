using PraiApp.Models;

namespace PraiApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PraiAppContext _context;

        public UserRepository(PraiAppContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserByIdAsync(long id)
        {
            return await _context.UserModel.FindAsync(id);
        }

    }
}
