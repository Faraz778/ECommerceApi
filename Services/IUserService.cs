using ECommerceApi.DTOs;

namespace ECommerceApi.Services
{
    public interface IUserService
    {
         Task<bool> Register(RegisterUserDto registerUserDto);
         Task<string?> Login(LoginUserDto loginUserDto);

    }
}
