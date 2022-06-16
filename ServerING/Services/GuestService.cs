using ServerING.Models;
using ServerING.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerING.Services {
    public class GuestService {

        IUserRepository userRepository;
        IServerRepository serverRepository;
        IPlatformRepository platformRepository;
        IWebHostingRepository webHostingRepository;
        IPlayerRepository playerRepository;

        public GuestService(IUserRepository userRepository,
                            IServerRepository serverRepository,
                            IPlatformRepository platformRepository,
                            IWebHostingRepository webHostingRepository,
                            IPlayerRepository playerRepository) {

            this.userRepository = userRepository;
            this.serverRepository = serverRepository;
            this.platformRepository = platformRepository;
            this.webHostingRepository = webHostingRepository;
            this.playerRepository = playerRepository;
        }


        public void RegisterUser(string name, string password) {

            User user = new User {
                Login = name,
                Password = password,
                Role = "User"
            };

            userRepository.Add(user);
        }


        public IEnumerable<Server> GetAllServers() {
            return serverRepository.GetAll();
        }


        public IEnumerable<Platform> GetAllPlatforms() {
            return platformRepository.GetAll();
        }


        public IEnumerable<Server> GetServersByPlatfromID(int id) {
            return serverRepository.GetByPlatformID(id);
        }


        public IEnumerable<Server> SortServersByServerName() {
            return serverRepository.GetAll().OrderBy(x => x.Name);
        }


        public IEnumerable<Server> SortServersByGameVersion() {
            return serverRepository.GetAll().OrderBy(x => x.GameVersion);
        }
    }
}
