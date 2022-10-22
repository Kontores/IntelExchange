using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;
using IntelExchange.Database.Mocks;

namespace IntelExchange.Database.Repositories
{
    public class UserMockRepository : IUserRepository
    {
        public UserDataMock UserDataMock { get; init; }
        public async Task CreateAsync(User user)
        {
            UserDataMock.Users.Add(user);
            UserDataMock.UserProfiles.Add(user.Profile);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = UserDataMock.Users.Find(u => u.Id == id);
            if (user != null)
            {
                UserDataMock.Users.Remove(user);
                UserDataMock.UserProfiles.Remove(user.Profile);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var allUsersTask = new Task<IEnumerable<User>>(() => UserDataMock.Users);
            allUsersTask.Start();
            return await allUsersTask;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userTask = new Task<User>(() => UserDataMock.Users.FirstOrDefault(u => u.Id == id));
            userTask.Start();
            return await userTask;
        }

        public async Task UpdateAsync(User entity)
        {
            var user = UserDataMock.Users.Find(u => u.Id == entity.Id);
            if (user != null)
            {
                DeleteAsync(entity.Id);
                CreateAsync(entity);
            }
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            var userTask = new Task<User>(() => UserDataMock.Users.FirstOrDefault(u => u.Login == userName));
            userTask.Start();
            return await userTask;
        }

        public UserMockRepository()
        {
            UserDataMock = new UserDataMock();
        }
    }
}
