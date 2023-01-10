using IT.Context;
using IT.Entities;
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
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
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
                Id= createUserDto.Id,
                Name= createUserDto.Name,
                Phone= createUserDto.Phone,
                Email= createUserDto.Email,
                Password= createUserDto.Password,
                ConfirmPassword= createUserDto.ConfirmPassword,

                
               
            };
            

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(GetModel(user));
        }

        [HttpPut]
        public IActionResult UpdateUser(int id,[FromBody] UpdateUserDto updateUserDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return BadRequest();
            }
           

            user.Email = updateUserDto.Email;
            
            user.Name = updateUserDto.Name;
            user.Phone = updateUserDto.Phone;
            user.Password = updateUserDto.Password;
            user.ConfirmPassword= updateUserDto.ConfirmPassword;



            _context.SaveChanges();


            return Ok(GetModel(user));
            
        }


        [HttpDelete]
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
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                Email = user.Email,

                
                
            };

            return getModel;
        }


    }
}
