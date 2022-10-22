using IntelExchange.DataAccess.Interfaces;
using IntelExchange.DataModels;

namespace IntelExchange.DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserByIdAsync(Guid id) => _userRepository.GetByIdAsync(id);

        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllAsync();

        public Task<User> GetUserByNameAsync(string userName) => _userRepository.GetUserByNameAsync(userName);
    }
}
