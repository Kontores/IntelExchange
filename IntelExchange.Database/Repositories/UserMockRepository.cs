using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;
using IntelExchange.Database.Mocks;
namespace IntelExchange.Database.Repositories
{
    public class UserMockRepository : IUserRepository
    {
        public UserDataMock UserDataMock {get; init;}
        public void Create(User user)
        {
            UserDataMock.Users.Add(user);
            UserDataMock.UserProfiles.Add(user.Profile);
            UserDataMock.UserAccounts.Add(user.Account);
        }

        public void Delete(Guid id)
        {
            var user = UserDataMock.Users.Find(u => u.Id == id);
            if(user != null)
            {
                UserDataMock.Users.Remove(user);
                UserDataMock.UserProfiles.Remove(user.Profile);
                UserDataMock.UserAccounts.Remove(user.Account);
            }
        }

        public IEnumerable<User> GetAll() => UserDataMock.Users;

        public User GetById(Guid id) => UserDataMock.Users.FirstOrDefault(u => u.Id == id);

        public void Update(User entity)
        {
            var user = UserDataMock.Users.Find(u => u.Id == entity.Id);
            if (user != null)
            {
                Delete(entity.Id);
                Create(entity);
            }
        }

        public UserMockRepository()
        {
            UserDataMock = new UserDataMock();
        }
    }
}
