using FlashCardAPI.Model;
using FlashCardAPI.RepoData.IRepository;
using FlashCardAPI.ServiceData.IService;

namespace FlashCardAPI.ServiceData.Service
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepo;
        public UserService(IUserRepo repo)
        {
            _userRepo = repo;
        }

        public Task DeleteUser(Guid id)
        {
            return _userRepo.DeleteUser(id);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public Task<User> GetUserByAuthentication(string username, string password)
        {
            return _userRepo.GetUserByAuthentication(username, password);
        }

        public Task<User> GetUserById(Guid id)
        {
            return _userRepo.GetUserById(id);
        }

        public Task<User> InsertUser(string username, string password)
        {
            return _userRepo.InsertUser(username, password);
        }

        public Task PutUser(User user)
        {
            return _userRepo.PutUser(user);
        }

        public Task<User> UpdateUser(Guid id, User user)
        {
            return _userRepo.UpdateUser(id, user);
        }
    }
}
