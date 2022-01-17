using Lib.Models;
using Lib.Services;
using Lib.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme , Roles ="User")]

    public class UserController : ControllerBase
    {
        IUserService _userService;
        LibContext _context ;
        

        public UserController(IUserService service, LibContext context)
        {
            _userService = service;
            _context = context;
        }
        public static List<User> users = new List<User>()
        {
            new User(){UserId = 1,UserName = "user1"},
            new User(){UserId = 2,UserName = "user2"},
            new User(){UserId = 3,UserName = " user3"},
            new User(){UserId = 4,UserName = " user4"},
            new User(){UserId = 5,UserName = " user5"},
        };

        /// <summary>
        /// get all user by id
        /// </summary>
        /// <param name=" UserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetUser(int UserId)
        {
            try
            {
                var users = _userService.GetUser(UserId);
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// edit users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult PutUser(User user)
        {
            try
            {
                var model = _userService.PutUser(user);
                _context.Update(model);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var model = _userService.DeleteUser(id);
                _context.Remove(model);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
