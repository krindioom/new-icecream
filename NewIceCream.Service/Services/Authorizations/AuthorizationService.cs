using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewIceCream.DAL.Repository;
using NewIceCream.Domain.Models;
using NewIceCream.Domain.Response;
using NewIceCream.Domain.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewIceCream.Service.Services.Authorizations;

public class AuthorizationService : IAuthorizationService
{
    private readonly IRepository<AppUser> _userRepository;

    public AuthorizationService(IRepository<AppUser> userRepository) 
    { 
        _userRepository = userRepository;
    }

    public async Task<Response<ClaimsIdentity>> Register(UserViewModel userViewModel)
    {
        try
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == userViewModel.Email);

            if (user != null)
            {
                return new Response<ClaimsIdentity>()
                {
                    Description = "пользователь уже есть"
                };
            }

            user = new AppUser()
            {
                Email = userViewModel.Email,
                UserName = userViewModel.UserName,
                UserPassword = userViewModel.UserPassword
            };

            await _userRepository.Create(user);

            var token = Authorize(user);

            return new Response<ClaimsIdentity>()
            {
                Data = token,
                Description = $"регистрация прошла успешно",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        catch (Exception)
        {
            return new Response<ClaimsIdentity>()
            {
                Description = "полител сервак",
                StatusCode = Domain.Enums.StatusCode.InternalServiceError
            };
        }
    }

    private ClaimsIdentity Authorize(AppUser user)
    {
        IEnumerable<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Id", user.Id.ToString())
        };
        
        var identities = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return identities;
    }
}

