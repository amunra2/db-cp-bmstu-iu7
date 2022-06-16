using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerING.Models;
using ServerING.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL {
    public class UnitTestUser {

        [Fact]
        public void TestUserGetById() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {
                
                context.User.Add(new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {


                UserRepository userRepository = new UserRepository(context);
                var user = userRepository.GetByID(1);

                Assert.Equal(1, user.Id);
                Assert.Equal("User1", user.Login);
                Assert.Equal("12345", user.Password);
            }
        }


        [Fact]
        public void TestUserAdd() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step - Compare
            using (var context = new AppDBContent(options)) {
                UserRepository userRepository = new UserRepository(context);

                User expectedUser = new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                };

                userRepository.Add(expectedUser);

                User actualUser = context.User.Find(1);

                Assert.Equal(expectedUser.Id, actualUser.Id);
                Assert.Equal(expectedUser.Login, actualUser.Login);
                Assert.Equal(expectedUser.Password, actualUser.Password);
            }
        }


        [Fact]
        public void TestUserDelete() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.User.Add(new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                });

                context.SaveChanges();
            }


            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                UserRepository userRepository = new UserRepository(context);

                User expectedUser = new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                };

                User actualUser = userRepository.Delete(1);

                Assert.Equal(expectedUser.Id, actualUser.Id);
                Assert.Equal(expectedUser.Login, actualUser.Login);
                Assert.Equal(expectedUser.Password, actualUser.Password);
            }
        }


        [Fact]
        public void TestUserUpdate() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.User.Add(new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                
                UserRepository userRepository = new UserRepository(context);

                User expectedUser = new User {
                    Id = 1,
                    Login = "UpdatedUser",
                    Password = "54321"
                };

                userRepository.Update(expectedUser);

                User actualUser = context.User.Find(1);

                Assert.Equal(expectedUser.Id, actualUser.Id);
                Assert.Equal(expectedUser.Login, actualUser.Login);
                Assert.Equal(expectedUser.Password, actualUser.Password);
            }
        }


        [Fact]
        public void TestUserGetByLogin() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.User.Add(new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                UserRepository userRepository = new UserRepository(context);

                User expectedUser = new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345"
                };
                
                User actualUser = userRepository.GetByLogin("User1");

                Assert.Equal(expectedUser.Id, actualUser.Id);
                Assert.Equal(expectedUser.Login, actualUser.Login);
                Assert.Equal(expectedUser.Password, actualUser.Password);
            }
        }


        [Fact]
        public void TestUserGetByRole() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.User.Add(new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345",
                    Role = "User"
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                UserRepository userRepository = new UserRepository(context);

                User expectedUser = new User {
                    Id = 1,
                    Login = "User1",
                    Password = "12345",
                    Role = "User"
                };

                IEnumerable<User> users = userRepository.GetByRole("User");

                foreach (User user in users) {
                    Assert.Equal(expectedUser.Id, user.Id);
                    Assert.Equal(expectedUser.Login, user.Login);
                    Assert.Equal(expectedUser.Password, user.Password);
                    Assert.Equal(expectedUser.Role, user.Role);
                }
            }
        }
    }
}
