using PraiApp.Models;

namespace PraiApp.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByIdAsync(long id);
    }
}
