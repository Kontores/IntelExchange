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
        public async Task<User> GetUserByIdAsync(Guid id) => await _userRepository.GetByIdAsync(id);
        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetAllAsync();
        public async Task<User> GetUserByNameAsync(string userName) => await _userRepository.GetUserByNameAsync(userName);
        public async Task CreateUserAsync(User user) => await _userRepository.CreateAsync(user);
    }
}
