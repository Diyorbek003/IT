using IT.Context;
using IT.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Admin]
    public class AdminsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            var Admnis = _context.Admins?.ToList();
            return Ok(Admnis);
        }

        [HttpPost]
        public IActionResult CreateAdmin()
        {
            return Ok();
        }
    }
}
