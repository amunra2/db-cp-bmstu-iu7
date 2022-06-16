using System;
using Xunit;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Services;
using ServerING.Models;
using System.Collections.Generic;

namespace UnitDBL {
    public class UnitTestServiceUser {

        [Fact]
        public void TestUserAdd() {
            IUserRepository userRepository = new UserMock();
            UserService userService = new UserService(userRepository);

            User expectedUser = new User {
                Id = 4,
                Login = "Login4",
                Password = "12345",
                Role = "User4"
            };

            userService.AddUser(expectedUser);

            User actualUser = userService.GetUserByID(4);

            Assert.Equal(expectedUser.Login, actualUser.Login);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.Role, actualUser.Role);
        }


        [Fact]
        public void TestUserUpdate() {
            IUserRepository userRepository = new UserMock();
            UserService userService = new UserService(userRepository);

            User expectedUser = new User {
                Id = 1,
                Login = "Login1Changed",
                Password = "12345Changed",
                Role = "User4"
            };

            userService.UpdateUser(expectedUser);

            User actualUser = userService.GetUserByID(1);

            Assert.Equal(expectedUser.Login, actualUser.Login);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.Role, actualUser.Role);
        }


        [Fact]
        public void TestUserDelete () {
            IUserRepository userRepository = new UserMock();
            UserService userService = new UserService(userRepository);

            User expectedUser = new User {
                Id = 1,
                Login = "Login1",
                Password = "12345",
                Role = "User1"
            };

            User actualUser = userService.DeleteUser(expectedUser);

            Assert.Equal(expectedUser.Login, actualUser.Login);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.Role, actualUser.Role);
        }


        [Fact]
        public void TestUserGetByLogin() {
            IUserRepository userRepository = new UserMock();
            UserService userService = new UserService(userRepository);

            User expectedUser = new User {
                Id = 1,
                Login = "Login1",
                Password = "12345",
                Role = "User1"
            };

            User actualUser = userService.GetUserByLogin("Login1");

            Assert.Equal(expectedUser.Login, actualUser.Login);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.Role, actualUser.Role);
        }


        [Fact]
        public void TestUserGetByPermission() {
            IUserRepository userRepository = new UserMock();
            UserService userService = new UserService(userRepository);

            User expectedUser = new User {
                Id = 1,
                Login = "Login1",
                Password = "12345",
                Role = "User1"
            };

            IEnumerable<User> actualUsers = userService.GetUsersByRole("User1");

            foreach (User actualUser in actualUsers) {
                Assert.Equal(expectedUser.Login, actualUser.Login);
                Assert.Equal(expectedUser.Password, actualUser.Password);
                Assert.Equal(expectedUser.Role, actualUser.Role);
            }
        }
    }
}
