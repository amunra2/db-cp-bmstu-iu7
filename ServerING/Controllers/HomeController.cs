using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServerING.Models;
using ServerING.Services;
using ServerING.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ServerING.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private IServerService serverService;
        private IUserService userService;
        private IWebHostingService webHostService;
        private IPlayerService playerService;

        private readonly IConfiguration configuration; //

        public HomeController(IServerService serverService, IUserService userService, ILogger<HomeController> logger, 
                              IConfiguration configuration, IPlayerService playerService, IWebHostingService webHostingService) {
            this.serverService = serverService;
            this.userService = userService;
            this._logger = logger;
            this.configuration = configuration;
            this.playerService = playerService;
            this.webHostService = webHostingService;
        }

        public IActionResult Index(string name, int? platformId, int page = 1, ServerSortState sortOrder = ServerSortState.NameAsc) {
            //var servers = serverService.GetAllServers(); // Для фильтрации+сортировки через БД не нужно
            var viewModel = serverService.ParseServers(name, platformId, page, sortOrder, false, null);

            Console.WriteLine(User.Identity.Name);
            Console.WriteLine(configuration["DatabaseConnection"]); // TEST

            if (User.Identity.IsAuthenticated) {
                User user = userService.GetUserByLogin(User.Identity.Name);
                var userFavoriteServerIds = serverService.GetUserFavoriteServersIds(user.Id);

                viewModel.UserFavoriteServerIds = userFavoriteServerIds.ToList();
            }

            _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}",
                User.Identity.Name,
                MethodBase.GetCurrentMethod().Name);

            return View(viewModel);
        }

        public IActionResult Detail(int? id) {
            _logger.Log(LogLevel.Information, "User: login = {0}; in method = {1}, ServerDetailId = {2}",
                User.Identity.Name,
                MethodBase.GetCurrentMethod().Name,
                id);

            /*var detailViewModel = serverService.DetailServer((int)id);*/
            if (id != null) {
                var server = serverService.GetServerByID((int)id);

                WebHosting webHosting = null;
                IEnumerable<Player> players = new List<Player>();

                if (User.Identity.IsAuthenticated && server != null) {
                    webHosting = serverService.GetWebHostingByServerId((int)id);
                    players = serverService.GetPlayersByServerId((int)id);
                }

                DetailViewModel viewModel = new DetailViewModel {
                    Server = server,
                    WebHosting = webHosting,
                    Players = players
                };

                if (viewModel != null) {
                    return View(viewModel);
                }
            }

            

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
