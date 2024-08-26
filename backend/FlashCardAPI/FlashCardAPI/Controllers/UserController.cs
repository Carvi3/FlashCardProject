using FlashCardAPI.Exceptions;
using FlashCardAPI.Model;
using FlashCardAPI.ServiceData.IService;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            //Admin Needed
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var foundUser = await _userService.GetUserById(id);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            return NotFound();
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> login(string username, string password)
        {
            var userFound = await _userService.GetUserByAuthentication(username, password);
            return (userFound != null) ? Ok(userFound) : throw new AuthenticationFailedException();
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<User>> CreateUser(User user) {
            var newUser = await _userService.InsertUser(user);
            if(newUser != null)
            {
                return Created(string.Empty, newUser);
            }

            throw new Exception("Failed to Create User");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            //Admin needed
            await _userService.DeleteUser(id);
            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> PutUser(User user)
        {
            //Admin needed
            await _userService.PutUser(user);
            return Ok();
        }
        //Update User
        [HttpPatch("{id}")]
        public async Task<ActionResult<User>> UpdateUser(Guid id,User user)
        {
            var updatedUser = _userService.UpdateUser(id, user);
            if (updatedUser != null) {
                return Ok(updatedUser);
            }
            throw new Exception();
        }
        //Put User
        //get all Users
        //


    }
}
