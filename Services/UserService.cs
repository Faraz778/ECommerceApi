using ECommerceApi.Data;
using ECommerceApi.DTOs;
using Microsoft.EntityFrameworkCore;
using ECommerceApi.Models;


namespace ECommerceApi.Services

{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
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
                UserPassword = registerUserDto.UserPassword,
            };
           await _context.Users.AddAsync(newuser);
           await _context.SaveChangesAsync();

            return true;
        }


    }
}
