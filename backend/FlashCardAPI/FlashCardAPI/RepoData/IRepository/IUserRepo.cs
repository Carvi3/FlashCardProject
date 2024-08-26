using FlashCardAPI.Model;

namespace FlashCardAPI.RepoData.IRepository
{
    public interface IUserRepo
    {
        //Create
        Task<User> InsertUser(User user);
        Task PutUser(User user);
        //Read

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);

        Task<User> GetUserByAuthentication(string username, string password);
        //Update
        Task<User> UpdateUser(Guid id, User user);
        //Delete
        Task DeleteUser(Guid id);
    }
}
