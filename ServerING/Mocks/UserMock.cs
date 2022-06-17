using ServerING.Interfaces;
using ServerING.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerING.Mocks {
    public class UserMock : MockData, IUserRepository {

        public void Add(User model) {
            _users.Add(model);
        }

        public User Delete(int id) {
            User user = _users[id - 1];
            _users.Remove(user);

            return user;
        }

        public IEnumerable<User> GetAll() {
            return _users;
        }

        public User GetByID(int id) {
            return _users[id - 1];
        }

        public User GetByLogin(string login) {
            return _users.FirstOrDefault(item => item.Login == login);
        }

        public IEnumerable<User> GetByRole(string role) {
            return _users.Where(item => item.Role == role);
        }

        public IEnumerable<Server> GetFavoriteServersByUserId(int id) {
            var favServs = _favoriteServers
                .Where(x => x.UserID == id)
                .Select(x => x.ServerID);

            IEnumerable<Server> servers = _servers
                .Where(x => favServs.Contains(x.Id));

            return servers;
        }


        public void AddFavoriteServer(int serverID, int userID) {
            int count = _favoriteServers.Count();

            FavoriteServer favoriteServer = new FavoriteServer {
                Id = count + 1,
                ServerID = serverID,
                UserID = userID
            };

            _favoriteServers.Add(favoriteServer);
        }


        public void Update(User model) {
            User user = _users[model.Id - 1];

            user.Login = model.Login;
            user.Password = model.Password;
            user.Role = model.Role;

            _users[user.Id - 1] = user;
        }

        public FavoriteServer DeleteFavoriteServer(int id) {
                FavoriteServer favoriteServer = _favoriteServers.FirstOrDefault(fs => fs.Id == id);
                _favoriteServers.Remove(favoriteServer);

                return favoriteServer;
        }

        public FavoriteServer GetFavoriteServerByUserAndServerId(int userId, int serverId) {
            return _favoriteServers.FirstOrDefault(fs => fs.UserID == userId && fs.ServerID == serverId);
        }
    }
}
