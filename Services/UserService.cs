using ECommerceApi.Data;
using ECommerceApi.DTOs;
using Microsoft.EntityFrameworkCore;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace ECommerceApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context; 
            _passwordHasher = new PasswordHasher<User>();
            _configuration = configuration;
        }

        public async Task<bool> Register(RegisterUserDto registerUserDto)
        {
            var user = await _context.Users.AnyAsync(x => x.UserEmail == registerUserDto.UserEmail);
            if (user)
            {
                return false;
            }
            var newuser = new User
            {
                UserName = registerUserDto.UserName,
                UserEmail = registerUserDto.UserEmail,
            };
           newuser.UserPassword = _passwordHasher.HashPassword(newuser, registerUserDto.UserPassword);

           await _context.Users.AddAsync(newuser);
           await _context.SaveChangesAsync();

            return true;
        }



        public async Task<string?> Login(LoginUserDto loginUserDto)
        {
          var user = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail ==  loginUserDto.UserEmail);
            if (user == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.UserPassword,
                loginUserDto.UserPassword

                );
            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }  

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.UserEmail)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                      _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(
                     double.Parse(_configuration["Jwt:DurationInMinutes"]!)
                     ),
                       signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }






    }
}
