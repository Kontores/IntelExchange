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
        public User GetUserById(Guid id) => _userRepository.GetById(id);

        public Task<User> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

        public Task<User> GetUserByNameAsync(string userName) => _userRepository.GetUserByNameAsync(userName);
    }
}
