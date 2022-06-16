using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerING.Models;
using ServerING.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL {
    public class UnitTestPlayer {

        [Fact]
        public void TestPlayerGetById() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlayerRepository playerRepository = new PlayerRepository(context);
                var player = playerRepository.GetByID(1);

                Assert.Equal(1, player.Id);
                Assert.Equal("Player1", player.Nickname);
                Assert.Equal(10, player.HoursPlayed);
                Assert.Equal(new DateTime(2022, 5, 5), player.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerAdd() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step - Compare
            using (var context = new AppDBContent(options)) {
                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname= "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                playerRepository.Add(expectedPlayer);

                Player actualPlayer = context.Player.Find(1);

                Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerDelete() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }


            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                Player actualPlayer = playerRepository.Delete(1);

                Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerUpdate() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                playerRepository.Update(expectedPlayer);

                Player actualPlayer = context.Player.Find(1);

                Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerGetByNickname() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                Player actualPlayer = playerRepository.GetByNickname("Player1");

                Assert.Equal(expectedPlayer.Id, actualPlayer.Id);
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerGetByHoursPlayed() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                IEnumerable<Player> players = playerRepository.GetByHoursPlayed(10);

                foreach (Player player in players) {
                    Assert.Equal(expectedPlayer.Id, player.Id);
                    Assert.Equal(expectedPlayer.Nickname, player.Nickname);
                    Assert.Equal(expectedPlayer.HoursPlayed, player.HoursPlayed);
                    Assert.Equal(expectedPlayer.LastPlayed, player.LastPlayed);
                }
            }
        }


        [Fact]
        public void TestPlayerGetByLastPlayed() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Player.Add(new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player expectedPlayer = new Player {
                    Id = 1,
                    Nickname = "Player1",
                    HoursPlayed = 10,
                    LastPlayed = new DateTime(2022, 5, 5)
                };

                IEnumerable<Player> players = playerRepository.GetByLastPlayed(new DateTime(2022, 5, 5));

                foreach (Player player in players) {
                    Assert.Equal(expectedPlayer.Id, player.Id);
                    Assert.Equal(expectedPlayer.Nickname, player.Nickname);
                    Assert.Equal(expectedPlayer.HoursPlayed, player.HoursPlayed);
                    Assert.Equal(expectedPlayer.LastPlayed, player.LastPlayed);
                }
            }
        }
    }
}
