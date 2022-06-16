using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerING.Models;
using ServerING.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL {
    public class UnitTestServer {

        [Fact]
        public void TestServerGetById() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);
                var server = serverRepository.GetByID(1);

                Assert.Equal(1, server.Id);
                Assert.Equal("Server1", server.Name);
                Assert.Equal("127.0.0.1", server.Ip);
                Assert.Equal("1.2.3", server.GameVersion);
                Assert.Equal(1, server.HostingID);
                Assert.Equal(1, server.PlatformID);
            }
        }


        [Fact]
        public void TestServerAdd() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step - Compare
            using (var context = new AppDBContent(options)) {
                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                serverRepository.Add(expectedServer);

                Server actualServer = context.Server.Find(1);

                Assert.Equal(actualServer.Id, expectedServer.Id);
                Assert.Equal(actualServer.Name, expectedServer.Name);
                Assert.Equal(actualServer.Ip, expectedServer.Ip);
                Assert.Equal(actualServer.GameVersion, expectedServer.GameVersion);
                Assert.Equal(actualServer.HostingID, expectedServer.HostingID);
                Assert.Equal(actualServer.PlatformID, expectedServer.PlatformID);
            }
        }


        [Fact]
        public void TestServerDelete() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }


            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                Server actualServer = serverRepository.Delete(1);

                Assert.Equal(actualServer.Id, expectedServer.Id);
                Assert.Equal(actualServer.Name, expectedServer.Name);
                Assert.Equal(actualServer.Ip, expectedServer.Ip);
                Assert.Equal(actualServer.GameVersion, expectedServer.GameVersion);
                Assert.Equal(actualServer.HostingID, expectedServer.HostingID);
                Assert.Equal(actualServer.PlatformID, expectedServer.PlatformID);
            }
        }


        [Fact]
        public void TestServerUpdate() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                serverRepository.Update(expectedServer);

                Server actualServer = context.Server.Find(1);

                Assert.Equal(actualServer.Id, expectedServer.Id);
                Assert.Equal(actualServer.Name, expectedServer.Name);
                Assert.Equal(actualServer.Ip, expectedServer.Ip);
                Assert.Equal(actualServer.GameVersion, expectedServer.GameVersion);
                Assert.Equal(actualServer.HostingID, expectedServer.HostingID);
                Assert.Equal(actualServer.PlatformID, expectedServer.PlatformID);
            }
        }


        [Fact]
        public void TestServerGetByName() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                Server actualServer = serverRepository.GetByName("Server1");

                Assert.Equal(actualServer.Id, expectedServer.Id);
                Assert.Equal(actualServer.Name, expectedServer.Name);
                Assert.Equal(actualServer.Ip, expectedServer.Ip);
                Assert.Equal(actualServer.GameVersion, expectedServer.GameVersion);
                Assert.Equal(actualServer.HostingID, expectedServer.HostingID);
                Assert.Equal(actualServer.PlatformID, expectedServer.PlatformID);
            }
        }


        [Fact]
        public void TestServerGetByIp() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                Server actualServer = serverRepository.GetByIP("127.0.0.1");

                Assert.Equal(actualServer.Id, expectedServer.Id);
                Assert.Equal(actualServer.Name, expectedServer.Name);
                Assert.Equal(actualServer.Ip, expectedServer.Ip);
                Assert.Equal(actualServer.GameVersion, expectedServer.GameVersion);
                Assert.Equal(actualServer.HostingID, expectedServer.HostingID);
                Assert.Equal(actualServer.PlatformID, expectedServer.PlatformID);
            }
        }


        [Fact]
        public void TestServerGetByGameVersion() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                IEnumerable<Server> servers = serverRepository.GetByGameVersion("1.2.3");

                foreach (Server server in servers) {
                    Assert.Equal(server.Id, expectedServer.Id);
                    Assert.Equal(server.Name, expectedServer.Name);
                    Assert.Equal(server.Ip, expectedServer.Ip);
                    Assert.Equal(server.GameVersion, expectedServer.GameVersion);
                    Assert.Equal(server.HostingID, expectedServer.HostingID);
                    Assert.Equal(server.PlatformID, expectedServer.PlatformID);
                }
            }
        }


        [Fact]
        public void TestServerGetByWebHostingID() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                IEnumerable<Server> servers = serverRepository.GetByWebHostingID(1);

                foreach (Server server in servers) {
                    Assert.Equal(server.Id, expectedServer.Id);
                    Assert.Equal(server.Name, expectedServer.Name);
                    Assert.Equal(server.Ip, expectedServer.Ip);
                    Assert.Equal(server.GameVersion, expectedServer.GameVersion);
                    Assert.Equal(server.HostingID, expectedServer.HostingID);
                    Assert.Equal(server.PlatformID, expectedServer.PlatformID);
                }
            }
        }


        [Fact]
        public void TestServerGetByPlatformID() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Server.Add(new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                ServerRepository serverRepository = new ServerRepository(context);

                Server expectedServer = new Server {
                    Id = 1,
                    Name = "Server1",
                    Ip = "127.0.0.1",
                    GameVersion = "1.2.3",
                    HostingID = 1,
                    PlatformID = 1
                };

                IEnumerable<Server> servers = serverRepository.GetByPlatformID(1);

                foreach (Server server in servers) {
                    Assert.Equal(server.Id, expectedServer.Id);
                    Assert.Equal(server.Name, expectedServer.Name);
                    Assert.Equal(server.Ip, expectedServer.Ip);
                    Assert.Equal(server.GameVersion, expectedServer.GameVersion);
                    Assert.Equal(server.HostingID, expectedServer.HostingID);
                    Assert.Equal(server.PlatformID, expectedServer.PlatformID);
                }
            }
        }
    }
}
