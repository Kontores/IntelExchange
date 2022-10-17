using IntelExchange.DataModels;
namespace IntelExchange.DataAccess.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(Guid id);
        public Task<User> GetUserByIdAsync(Guid id);
        public IEnumerable<User> GetAllUsers();
    }
}
