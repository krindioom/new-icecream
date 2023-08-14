using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NewIceCream.Domain.ViewModels;
using NewIceCream.Service.Services.Authorizations;
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

        [HttpGet]
        public IActionResult Login()
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
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(response.Result.Data));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", response.Result.Description);
            }

            return View(userViewModel);
        }
    }
}
