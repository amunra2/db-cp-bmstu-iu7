using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerING.Models;
using ServerING.Services;
using System.Reflection;

namespace ServerING.Controllers {
    public class UserController : Controller {
        private readonly ILogger<UserController> _logger;

        private IUserService userService;
        private IServerService serverService;

        public UserController(IUserService userService, IServerService serverService, ILogger<UserController> logger) {
            this.userService = userService;
            this.serverService = serverService;
            this._logger = logger;
        }

        [Authorize]
        public IActionResult AddToFavorite(int? id) {
            if (id != null) {

                _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}, ServerId = {2}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name,
                        id);

                User user = userService.GetUserByLogin(User.Identity.Name);

                serverService.AddFavoriteServer((int)id, user.Id);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult DeleteFromFavorite(int? id, string page) {
            if (id != null) {

                _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}, ServerId = {2}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name,
                        id);

                User user = userService.GetUserByLogin(User.Identity.Name);

                serverService.DeleteFavoriteServer((int)id, user.Id);
            }

            if (page == "FavoriteServers") {
                return RedirectToAction("FavoriteServers", "User");
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public IActionResult FavoriteServers(string name, int? platformId, int page = 1, ServerSortState sortOrder = ServerSortState.NameAsc) {
            _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}",
                        User.Identity.Name,
                        MethodBase.GetCurrentMethod().Name);

            /*// Для фильтрации и сортировки через C#
            User user = userService.GetUserByLogin(User.Identity.Name);
            IEnumerable<Server> servers = userService.GetUserFavoriteServers(user);*/

            // Для фильтрации и сортировки через БД (не нужен список серверов, поиск происходит в базе)
            User user = userService.GetUserByLogin(User.Identity.Name);

            var viewModel = serverService.ParseServers(name, platformId, page, sortOrder, true, user.Id);

            return View(viewModel);
        }
    }
}
