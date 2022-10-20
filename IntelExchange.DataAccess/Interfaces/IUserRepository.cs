using IntelExchange.DataModels;
namespace IntelExchange.DataAccess.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public Task<User> GetUserByNameAsync(string userName);
    }
}
