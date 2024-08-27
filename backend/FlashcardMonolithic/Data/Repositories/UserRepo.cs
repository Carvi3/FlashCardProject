using Data.Contexts;
using Domain.Entities;
using Domain.IRepositories;
using FlashCardAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepo : IUserRepository
{
    private readonly UserContext _context;
    public UserRepo(UserContext context)
    {
        _context = context;
    }
    public async Task DeleteUser(Guid id)
    {
        var user = await _context.User.FindAsync(id);
        if(user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> GetUserByAuthentication(string username, string password)
    {
        IEnumerable<User> userlist = await GetAllUsers();

        User userFound = (from user in userlist
                         where user.Username == username && user.Password == password
                         select user).First<User>();
        
        if (userFound != null)
        {
            return userFound;
        }
        throw new AuthenticationFailedException("Invalid Credentials");
    }

    public async Task<User> GetUserById(Guid id)
    {
        User found = await _context.User.FindAsync(id);
        if (found != null)
        {
            return found;
        }
        throw new Exception();
    }

    public async Task<User> InsertUser(User user)
    {
        //User duplicateUser = (User)_context.User.FromSqlRaw($"SELECT id FROM User where Username = {username};");
        //if(duplicateUser == null)
        //{
            User newUser = _context.User.Add(user).Entity;
            await _context.SaveChangesAsync();
            return newUser;
        //}
        //throw new AuthenticationFailedException("Account Already Exists");
    }

    public async Task PutUser(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> UpdateUser(Guid id, User user)
    {
        User changeUser = await _context.User.FindAsync(id);
        if (changeUser != null)
        {
            changeUser.Id = user.Id;
            changeUser.Username = user.Username;
            changeUser.Password = user.Password;
            await _context.SaveChangesAsync();
            return changeUser;
        }
        throw new Exception("User was not able to be Updated");

    }
}
