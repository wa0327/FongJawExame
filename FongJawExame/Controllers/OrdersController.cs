using FongJawExame.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FongJawExame.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var token = Request.Cookies["JwtToken"];
            if (token == null)
            {
                return Unauthorized();
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = (JwtSecurityToken)handler.ReadToken(token);
            var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);
            var lastDate = DateTime.Today.AddDays(-30);

            var query = from o in _context.Orders
                        where o.UserId == userId
                           && o.CreatedAt >= lastDate
                           && o.TotalAmount > 5000
                        orderby o.CreatedAt descending
                        select o;

            return View();
        }
    }
}
