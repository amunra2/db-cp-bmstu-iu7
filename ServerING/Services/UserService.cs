using ServerING.Interfaces;
using ServerING.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServerING.Services {

    public interface IUserService {
        void AddUser(User user);
        User DeleteUser(User user);
        void UpdateUser(User user);

        User GetUserByID(int id);
        IEnumerable<User> GetAllUsers();

        User GetUserByLogin(string login);
        IEnumerable<User> GetUsersByRole(string role);
    }

    public class UserService : IUserService {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }


        private bool IsExist(User user) {
            return userRepository.GetAll()
                .Any(item =>
                    item.Login == user.Login &&
                    item.Role == user.Role
                    );
        }


        private bool IsExistById(int id) {
            return userRepository.GetByID(id) != null;
        }


        public void AddUser(User user) {

            if (IsExist(user))
                throw new Exception("Such user is already exist");

            userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers() {
            return userRepository.GetAll();
        }

        public User GetUserByID(int id) {
            return userRepository.GetByID(id);
        }

        public User GetUserByLogin(string login) {
            return userRepository.GetByLogin(login);
        }

        public IEnumerable<User> GetUsersByRole(string role) {
            return userRepository.GetByRole(role);
        }

        public User DeleteUser(User user) {

            if (!IsExistById(user.Id))
                throw new Exception("No such user");

            return userRepository.Delete(user.Id);
        }

        public void UpdateUser(User user) {

            if (!IsExistById(user.Id))
                throw new Exception("No such user");

            userRepository.Update(user);
        }
    }
}
