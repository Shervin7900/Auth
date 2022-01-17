#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lib.Models;

namespace Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibContext _context;

        public UsersController(LibContext context)
        {
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

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            var user = await _context.Users.ToListAsync();
            if(user == null) { return NotFound(); }
            return Ok(user);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserbyId(int id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/name
        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetUserbyName(string name)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id,User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            
                var existingUser = await _context.Users.Where(x=>x.UserId ==id)
                                                        .FirstOrDefaultAsync<User>();

                if (existingUser != null)
                {
                    existingUser.UserId = user.UserId;
                    existingUser.UserName = user.UserName;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            

                return Ok(user);
        }

           
        
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            
                _context.Users.Add(user);

                await _context.SaveChangesAsync();
            

                return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            
                var user = await _context.Users
                    .AsNoTracking().SingleOrDefaultAsync(s => s.UserId == id);
                _context.Remove(id);
                await _context.SaveChangesAsync();
                _context.Entry(user).State = EntityState.Deleted;
                
            

                return Ok();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
