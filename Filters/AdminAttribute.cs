using IT.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace IT.Filters
{
    public class AdminAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = new User();
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role,"admin"),
                new Claim(ClaimTypes.Email, user.Email!)

                
            };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);

        }
    }
}
