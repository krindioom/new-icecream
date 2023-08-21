using NewIceCream.Domain.Response;
using NewIceCream.Domain.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewIceCream.Service.Services.Authorizations;

public interface IAuthorizationService
{
    Task<Response<ClaimsIdentity>> Register(UserViewModel userViewModel);
}

