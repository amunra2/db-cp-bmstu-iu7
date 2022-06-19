using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Models;
using ServerING.Services;
using ServerING.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ServerING.Controllers {
    public class AccountController : Controller {

        /*IUserService userService;

        public AccountController(IUserService userService) {
            this.userService = userService;
        }*/

        /// Test Connect
        static private IUserRepository userRepository = new UserMock();
        private IUserService userService = new UserService(userRepository);
        ///


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

                    userService.AddUser(user);

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");

                }
                catch (Exception ex) {
                    Console.Write(ex.Message);
                    ModelState.AddModelError("", "Логин занят");
                }

                return RedirectToAction("Index", "Home");
            }

            /*ModelState.AddModelError("", "Логин занят");*/

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
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect Login or Password");

                return View(model);
            }

            return View(model);
        }


        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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
    }
}
