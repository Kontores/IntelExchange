using IntelExchange.DataModels;
namespace IntelExchange.DataAccess.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> GetUserByNameAsync(string userName);
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task CreateUserAsync(User user);
    }
}
