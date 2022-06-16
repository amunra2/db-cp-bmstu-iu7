using System;
using Xunit;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Services;
using ServerING.Models;
using System.Collections.Generic;

namespace UnitDBL {
    public class UnitTestServicePlayer {

        [Fact]
        public void TestPlayerAdd() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 4,
                Nickname = "NN4",
                HoursPlayed = 4,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            playerService.AddPlayer(expectedPlayer);

            Player actualPlayer = playerService.GetPlayerByID(4);

            Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
            Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
            Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
        }


        [Fact]
        public void TestPlayerUpdate() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 1,
                Nickname = "NN1Changed",
                HoursPlayed = 1,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            playerService.UpdatePlayer(expectedPlayer);

            Player actualPlayer = playerService.GetPlayerByID(1);

            Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
            Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
            Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
        }


        [Fact]
        public void TestPlayerDelete() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 1,
                Nickname = "NN1",
                HoursPlayed = 1,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            Player actualPlayer = playerService.DeletePlayer(expectedPlayer);

            Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
            Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
            Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
        }


        [Fact]
        public void TestPlayerGetByNickname() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 1,
                Nickname = "NN1",
                HoursPlayed = 1,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            Player actualPlayer = playerService.GetPlayerByNickname("NN1");

            Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
            Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
            Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
        }


        [Fact]
        public void TestPlayerGetByHoursPlayed() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 1,
                Nickname = "NN1",
                HoursPlayed = 1,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            IEnumerable<Player> actualPlayers = playerService.GetPlayersByHoursPlayed(1);

            foreach (Player actualPlayer in actualPlayers) {
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }


        [Fact]
        public void TestPlayerGetByLastPlayed() {
            IPlayerRepository playerRepository = new PlayerMock();
            PlayerService playerService = new PlayerService(playerRepository);

            Player expectedPlayer = new Player {
                Id = 1,
                Nickname = "NN1",
                HoursPlayed = 1,
                LastPlayed = new DateTime(2022, 5, 5)
            };

            IEnumerable<Player> actualPlayers = playerService.GetPlayersByLastPlayed(new DateTime(2022, 5, 5));

            foreach (Player actualPlayer in actualPlayers) {
                Assert.Equal(expectedPlayer.Nickname, actualPlayer.Nickname);
                Assert.Equal(expectedPlayer.HoursPlayed, actualPlayer.HoursPlayed);
                Assert.Equal(expectedPlayer.LastPlayed, actualPlayer.LastPlayed);
            }
        }
    }
}
