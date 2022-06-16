using System;
using Xunit;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Services;
using ServerING.Models;
using System.Collections.Generic;

namespace UnitDBL {
    public class UnitTestServiceServer {

        [Fact]
        public void TesServerAdd() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 4,
                Name = "Server4",
                Ip = "ip4",
                GameVersion = "gv4",
                HostingID = 1,
                PlatformID = 1
            };

            serverService.AddServer(expectedServer);

            Server actualServer = serverService.GetServerByID(4);

            Assert.Equal(expectedServer.Name, actualServer.Name);
            Assert.Equal(expectedServer.Ip, actualServer.Ip);
            Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
        }


        [Fact]
        public void TesServerUpdate() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 1,
                Name = "ServerUpdated",
                Ip = "IPUpdated",
                GameVersion = "gvUpdated",
                HostingID = 1,
                PlatformID = 1
            };

            serverService.UpdateServer(expectedServer);

            Server actualServer = serverService.GetServerByID(1);

            Assert.Equal(expectedServer.Name, actualServer.Name);
            Assert.Equal(expectedServer.Ip, actualServer.Ip);
            Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
        }


        [Fact]
        public void TestServerDelete() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 1,
                Name = "Server1",
                Ip = "IP1",
                GameVersion = "GV1",
                HostingID = 1,
                PlatformID = 1
            };

            Server actualServer = serverService.DeleteServer(expectedServer);

            Assert.Equal(expectedServer.Name, actualServer.Name);
            Assert.Equal(expectedServer.Ip, actualServer.Ip);
            Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
        }


        [Fact]
        public void TestServerGetByName() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 1,
                Name = "Server1",
                Ip = "IP1",
                GameVersion = "GV1",
                HostingID = 1,
                PlatformID = 1
            };

            Server actualServer = serverService.GetServerByName("Server1");

            Assert.Equal(expectedServer.Name, actualServer.Name);
            Assert.Equal(expectedServer.Ip, actualServer.Ip);
            Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
        }


        [Fact]
        public void TestServerGetByIP() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 1,
                Name = "Server1",
                Ip = "IP1",
                GameVersion = "GV1",
                HostingID = 1,
                PlatformID = 1
            };

            Server actualServer = serverService.GetServerByIP("IP1");

            Assert.Equal(expectedServer.Name, actualServer.Name);
            Assert.Equal(expectedServer.Ip, actualServer.Ip);
            Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
        }


        [Fact]
        public void TestServerGetByGameVersion() {
            IServerRepository serverRepository = new ServerMock();
            ServerService serverService = new ServerService(serverRepository);

            Server expectedServer = new Server {
                Id = 1,
                Name = "Server1",
                Ip = "IP1",
                GameVersion = "GV1",
                HostingID = 1,
                PlatformID = 1
            };

            IEnumerable<Server> actualServers = serverService.GetServersByGameVersion("GV1");

            foreach (Server actualServer in actualServers) {
                Assert.Equal(expectedServer.Name, actualServer.Name);
                Assert.Equal(expectedServer.Ip, actualServer.Ip);
                Assert.Equal(expectedServer.GameVersion, actualServer.GameVersion);
            }
        }
    }
}
