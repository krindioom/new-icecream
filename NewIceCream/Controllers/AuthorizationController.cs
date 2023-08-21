using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NewIceCream.Domain.ViewModels;
using NewIceCream.Service.Services.Authorizations;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewIceCream.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            var response = _authorizationService.Register(userViewModel);

            if (ModelState.IsValid)
            {
                if (response.Result.StatusCode == Domain.Enums.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(response.Result.Data));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", response.Result.Description);
            }

            return View(userViewModel);
        }
    }
}
