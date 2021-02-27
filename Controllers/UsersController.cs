using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BackendContext _context;

        public UsersController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            try{

                var duplicatedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

                if(duplicatedUser == null){

                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                     return CreatedAtAction("CreateUser", new {Id = newUser.Id}, newUser);
                }
                else
                    return BadRequest("Email already registered!");
                
            }
            catch (System.Exception){
                return BadRequest("Something went wrong when creating user!");
            }
           
        }
    }
}
