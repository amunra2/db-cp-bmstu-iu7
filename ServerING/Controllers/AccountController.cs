using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServerING.Models;
using ServerING.Services;
using ServerING.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ServerING.Controllers {
    public class AccountController : Controller {

        IUserService userService;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration configuration;

        public AccountController(IUserService userService, ILogger<AccountController> logger, IConfiguration configuration) {
            this.userService = userService;
            this._logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (ModelState.IsValid) {
                try {
                    User user = new User {
                        Login = model.Login,
                        Password = model.Password,
                        Role = "User"
                    };

                    ChangeConnection(user.Role);

                    userService.AddUser(user);

                    await Authenticate(user);

                    _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("Index", "Home");

                }
                catch (Exception ex) {
                    _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1} - Exception: {2}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name,
                        ex.Message);

                    ChangeConnection("nonAuthUser");

                    ModelState.AddModelError("", "Логин занят");
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                User user = userService.ValidateUser(model);

                if (user != null) {
                    ChangeConnection(user.Role);

                    await Authenticate(user); // аутентификация

                    _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("Index", "Home");
                }

                _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1} - Exception: {2}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name,
                        "Incorrect Login or Password");

                ModelState.AddModelError("", "Incorrect Login or Password");

                return View(model);
            }

            return View(model);
        }


        public async Task<IActionResult> Logout() {
            _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ChangeConnection("nonAuthUser");

            return RedirectToAction("Index", "Home");
        }


        private async Task Authenticate(User user) {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private void ChangeConnection(string userRole) {
            if (userRole == "User")
                configuration["DatabaseConnection"] = configuration.GetConnectionString("authUserConnection");
            else if (userRole == "Admin")
                configuration["DatabaseConnection"] = configuration.GetConnectionString("adminConnection");
            else
                configuration["DatabaseConnection"] = configuration.GetConnectionString("nonAuthUserConnection");

            Console.WriteLine(userRole);
            Console.WriteLine(configuration["DatabaseConnection"]);
        }
    }
}
