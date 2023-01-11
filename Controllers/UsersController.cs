using IT.Context;
using IT.Entities;
using IT.Filters;
using IT.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        //[Admin]
        public IActionResult GetUsers()
        {

           
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Admin]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Id == id);
            if (user == null)
            {
                return BadRequest();
            }
        
            return Ok(GetModel(user));
        }


        [HttpPost]
        public IActionResult CreateUser(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           

            var user = new User
            {
                Name= createUserDto.Name,
                Phone= createUserDto.Phone,
               
            };
            
            if (_context.Users.Any(u=>u.Phone == user.Phone))
            { 
                return BadRequest();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(GetModel(user));
        }




        [HttpDelete]
        [Admin]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return BadRequest();

            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

        private CreateUserDto GetModel(User user)
        {
            var getModel = new CreateUserDto
            {
                Name = user.Name,
                Phone = user.Phone,
            };

            return getModel;
        }


    }
}
