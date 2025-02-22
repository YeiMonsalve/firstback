using Microsoft.AspNetCore.Mvc;
using BackendProject.Data;
using BackendProject.Models;
using BackendProject.Services;
using System.Security.Cryptography;
using System.Text;


namespace BackendProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;
        public AuthController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            user.Password =
           Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "Usuario registrado" });
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.FirstName ==
           user.FirstName);
            if (existingUser == null || existingUser.Password !=
           Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password))))
            {
                return Unauthorized();
            }
            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { token });
        }
    }
}