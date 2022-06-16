﻿using Microsoft.EntityFrameworkCore;
using ServerING.Interfaces;
using ServerING.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerING.Repository {
    public class UserRepository : IUserRepository {

        ///
        private readonly AppDBContent appDBContent;

        public UserRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }
        ///

        public void Add(User user) {

            try {
                appDBContent.User.Add(user);
                appDBContent.SaveChanges();
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
                throw new Exception("User Add Error");
            }
        }

        public User Delete(int id) {
            
            try {
                User user = appDBContent.User.Find(id);

                if (user == null) {
                    return null;
                }
                else {
                    appDBContent.User.Remove(user);
                    appDBContent.SaveChanges();

                    return user;
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
                throw new Exception("User Delete Error");
            }
        }

        public void Update(User user) {

            try {
                appDBContent.User.Update(user);
                appDBContent.SaveChanges();
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
                throw new Exception("User Update Error");
            }
        }

        public IEnumerable<User> GetAll() {
            return appDBContent.User;
        }

        public User GetByID(int id) {
            return appDBContent.User.Find(id);
        }

        public User GetByLogin(string login) {
            return appDBContent.User.FirstOrDefault(u => u.Login == login);
        }

        public IEnumerable<User> GetByRole(string role) {
            return appDBContent.User.Where(u => u.Role == role);
        }

        public IEnumerable<Server> GetFavoriteServersByUserId(int id) {

            var favServs = appDBContent.FavoriteServer
                .Where(x => x.UserID == id)
                .Select(x => x.ServerID);

            IEnumerable<Server> servers = appDBContent.Server
                .Where(x => favServs.Contains(x.Id));

            return servers;
        }

        public void AddFavoriteServer(int serverID, int userID) {
            FavoriteServer favoriteServer = new FavoriteServer {
                UserID = userID,
                ServerID = serverID
            };

            try {
                appDBContent.FavoriteServer.Add(favoriteServer);
                appDBContent.SaveChanges();
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
                throw new Exception("FavoriteServer Add Error");
            }
        }

        public FavoriteServer DeleteFavoriteServer(int id) {

            try {
                FavoriteServer favoriteServer = appDBContent.FavoriteServer.Find(id);

                if (favoriteServer == null) {
                    return null;
                }
                else {
                    appDBContent.FavoriteServer.Remove(favoriteServer);
                    appDBContent.SaveChanges();

                    return favoriteServer;
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
                throw new Exception("FavoriteServer Delete Error");
            }
        }

        public FavoriteServer GetFavoriteServerByUserAndServerId(int userId, int serverId) {
            return appDBContent.FavoriteServer.FirstOrDefault(fs => fs.UserID == userId && fs.ServerID == serverId);
        }
    }
}