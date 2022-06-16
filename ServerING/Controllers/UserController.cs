using Microsoft.AspNetCore.Mvc;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Models;
using ServerING.Services;

namespace ServerING.Controllers {
    public class UserController : Controller {

        /// Test Connect
        static private IServerRepository serverRepository = new ServerMock();
        static private IPlatformRepository platformRepository = new PlatformMock();
        static private IUserRepository userRepository = new UserMock();

        private IUserService userService = new UserService(userRepository);
        private IServerService serverService = new ServerService(serverRepository, platformRepository, userRepository);
        ///


        public IActionResult AddToFavorite(int? id) {

            if (id != null) {

                User user = userService.GetUserByLogin(User.Identity.Name);

                serverService.AddFavoriteServer((int)id, user.Id);
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult DeleteFromFavorite(int? id) {

            if (id != null) {

                User user = userService.GetUserByLogin(User.Identity.Name);

                serverService.DeleteFavoriteServer((int)id, user.Id);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
