using FongJawWeb.Data;
using FongJawWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace FongJawWeb.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var token = Request.Cookies["JwtToken"];
        if (token == null)
        {
            return RedirectToAction("Login", "Users");
        }

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub);
        var emailClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email);

        if (userIdClaim == null || emailClaim == null)
        {
            return RedirectToAction("Login", "Users");
        }

        var userId = int.Parse(userIdClaim.Value);
        var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (currentUser == null)
        {
            return RedirectToAction("Login", "Users");
        }

        return View(currentUser);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
