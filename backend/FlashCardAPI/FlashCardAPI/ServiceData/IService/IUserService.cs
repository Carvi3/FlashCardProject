using FlashCardAPI.Model;

namespace FlashCardAPI.ServiceData.IService
{
    public interface IUserService
    {
        //Create
        Task<User> InsertUser(string username, string password);
        Task PutUser(User user);
        //Read

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByAuthentication(string Username, string password);
        //Update
        Task<User> UpdateUser(Guid id, User user);
        //Delete
        Task DeleteUser(Guid id);
    }
}
