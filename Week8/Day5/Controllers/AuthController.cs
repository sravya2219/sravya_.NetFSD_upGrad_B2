using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase   // ✅ FIXED
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext context, ILogger<ContactController> logger)
        {
            _context = context;
            _logger = (ILogger<AuthController>)logger;
        }

        // ✅ REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)  // ✅ FIXED
        {
            if (user == null)
                return BadRequest("Invalid Data");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User Registered Successfully");
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)  // ✅ FIXED
        {
            if (login == null)
                return BadRequest("Invalid Data");

            var user = _context.Users
                .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            // 🔐 JWT Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role ?? string.Empty)
            };

            // 🔐 Secret Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecureSecretKey1234567890!"));

            // 🔐 Token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            _logger.LogInformation("User login attempt: {Username}", login.Username);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}