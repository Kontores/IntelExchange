using IntelExchange.DataModels;
namespace IntelExchange.DataAccess.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(Guid id);
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> GetUserByNameAsync(string userName);
        public IEnumerable<User> GetAllUsers();
    }
}
