using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Models;
using ServerING.Services;
using ServerING.ViewModels;
using System;

namespace ServerING.Controllers {
    public class AdminController : Controller {

        /// Test Connect
        static private IServerRepository serverRepository = new ServerMock();
        static private IPlatformRepository platformRepository = new PlatformMock();
        static private IUserRepository userRepository = new UserMock();
        static private IWebHostingRepository webHostingRepository = new WebHostingMock();

        private IServerService serverService = new ServerService(serverRepository, platformRepository, userRepository);
        private IPlatformService platformService = new PlatformService(platformRepository);
        private IWebHostingService webHostingService = new WebHostingService(webHostingRepository);
        private IUserService userService = new UserService(userRepository);
        ///

        public IActionResult Control() {
            return View();
        }

        [Authorize(Roles="Admin")]
        public IActionResult ControlServer(string name, int? platformId, int page = 1, ServerSortState sortOrder = ServerSortState.NameAsc) {

            var servers = serverService.GetAllServers();
            var viewModel = serverService.ParseServers(servers, name, platformId, page, sortOrder);

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult AddServer() { // для принятия данных из формы

            ViewBag.Platforms = new SelectList(platformService.GetAllPlatforms(), "Id", "Name");
            ViewBag.WebHostings = new SelectList(webHostingService.GetAllWebHostings(), "Id", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult AddServer(InfoServerViewModel model) {

            if (ModelState.IsValid) {
                Server server = new Server {
                    Name = model.Name,
                    Ip = model.Ip,
                    GameVersion = model.GameVersion,
                    HostingID = model.WebHostingId,
                    PlatformID = model.PlatformId
                };

                serverService.AddServer(server);

                return RedirectToAction("ControlServer");
            }

            ViewBag.Platforms = new SelectList(platformService.GetAllPlatforms(), "Id", "Name");
            ViewBag.WebHostings = new SelectList(webHostingService.GetAllWebHostings(), "Id", "Name");

            return View(model);
        }


        [HttpGet]
        public IActionResult UpdateServer(int id) {

            ViewBag.Platforms = new SelectList(platformService.GetAllPlatforms(), "Id", "Name");
            ViewBag.WebHostings = new SelectList(webHostingService.GetAllWebHostings(), "Id", "Name");

            Server server = serverService.GetServerByID(id);

            if (server != null) {
                InfoServerViewModel model = new InfoServerViewModel {
                    Id = server.Id,
                    Name = server.Name,
                    Ip = server.Ip,
                    GameVersion = server.GameVersion,
                    WebHostingId = server.HostingID,
                    PlatformId = server.PlatformID
                };

                return View(model);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateServer(InfoServerViewModel model) {

            if (ModelState.IsValid) {

                Server server = new Server {
                    Id = model.Id,
                    Name = model.Name,
                    Ip = model.Ip,
                    GameVersion = model.GameVersion,
                    HostingID = model.WebHostingId,
                    PlatformID = model.PlatformId
                };

                if (serverService.IsServerExists(server)) {
                    ModelState.AddModelError("", "Name or IP have already exist");
                }
                else {
                    serverService.UpdateServer(server);

                    return RedirectToAction("ControlServer");
                }
            }

            ViewBag.Platforms = new SelectList(platformService.GetAllPlatforms(), "Id", "Name");
            ViewBag.WebHostings = new SelectList(webHostingService.GetAllWebHostings(), "Id", "Name");

            return View(model);
        }


        public IActionResult DeleteServer(int id) {

            Server server = serverService.GetServerByID(id);

            if (server != null) { // Delete FavoriteServers and ServerPlayers == Delete On Cascade???
                serverService.DeleteServer(server);
                return RedirectToAction("ControlServer");
            }

            return NotFound();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ControlUser(string login, int page = 1, UserSortState sortOrder = UserSortState.LoginAsc) {

            var users = userService.GetAllUsers();
            var viewModel = userService.ParseUsers(users, login, page, sortOrder);

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult UserDetail(int id) {

            User user = userService.GetUserByID(id);

            if (user != null) {
                return View(user);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult UserDetail(int id, string role) {

            User user = userService.GetUserByID(id);

            Console.WriteLine(user.Login);
            Console.WriteLine(user.Role);

            if (ModelState.IsValid) {
                user.Role = role;
                userService.UpdateUser(user);

                return RedirectToAction("ControlUser");
            }

            return View(user);
        }
    }
}
