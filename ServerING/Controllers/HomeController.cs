using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Models;
using ServerING.Services;
using ServerING.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServerING.Controllers {
    public class HomeController : Controller {
        /*private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger; 
        } */



        /*public HomeController(IServerService serverService) {
            this.serverService = serverService;
        }*/


        /// Test Connect
        static private IServerRepository serverRepository = new ServerMock();
        static private IPlatformRepository platformRepository = new PlatformMock();
        static private IUserRepository userRepository = new UserMock();

        private IServerService serverService = new ServerService(serverRepository, platformRepository, userRepository);
        private IUserService userService = new UserService(userRepository);
        ///
        

        public IActionResult Index(string name, int? platformId, int page = 1, ServerSortState sortOrder = ServerSortState.NameAsc) {

            var viewModel = serverService.ParseServers(name, platformId, page, sortOrder);

            if (User.Identity.IsAuthenticated) {
                User user = userService.GetUserByLogin(User.Identity.Name); // в сервисс ??? 
                var userFavoriteServerIds = serverService.GetUserFavoriteServersIds(user.Id); // в сервисс ???

                viewModel.UserFavoriteServerIds = userFavoriteServerIds.ToList();
            }

            return View(viewModel);
        }


        public async Task<IActionResult> Detail(int? id) {

            if (id != null) {

                var detailViewModel = serverService.DetailServer((int)id);

                if (detailViewModel != null) {
                    return View(detailViewModel);
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
