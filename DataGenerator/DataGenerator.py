from faker import Faker
from random import randint, sample

from Utils.ServerNamesGenerator import generateUniqueServerNamesSet

import psycopg2


COPY_SQL = "SQL\\PostgresCopyAllData.sql"

SERVER_DATA = "E:\\PGAdminData\\server_data.csv"
PLAYER_DATA = "E:\\PGAdminData\\player_data.csv"
SERVER_PLAYER_DATA = "E:\\PGAdminData\\server_player_data.csv"
PLATFORM_DATA = "E:\\PGAdminData\platform_data.csv"
WEBHOSTING_DATA = "E:\\PGAdminData\\webhosting_data.csv"
FAV_SERVS_DATA = "E:\\PGAdminData\\fav_servs_data.csv"
USER_DATA = "E:\\PGAdminData\\user_data.csv"



MAX_SERVERS = 100
MAX_PLAYERS = 100
MAX_WEBHOSTINGS = 10
MAX_PLATFORMS = 10
MAX_USERS = 100


class DataBase:
    
    def __init__(self):

        try:
            self.__connection = psycopg2.connect(host = 'localhost', user = 'postgres', password = '12345687', database = 'ServerING')

            self.__connection.autocommit = True
            self.__cursor = self.__connection.cursor()

            print("\nPostgreSQL: Connection opened\n")

        except Exception as error:
            print("\nError ocured while init. Exception: ", error)

    
    def copy_data(self):

        f = open(COPY_SQL, "r")
        str_execute = f.read()

        self.__cursor.execute(str_execute)



# Old: serverName = faker.unique.domain_word();
def generateServerData():
    f = open(SERVER_DATA, "w")
    faker = Faker()

    serverNames = generateUniqueServerNamesSet(MAX_SERVERS)

    for serverName in serverNames:
        ip = faker.unique.ipv4()
        version = faker.bothify(text = "1.1#.#")
        rating = 0
        hostingId = randint(1, MAX_WEBHOSTINGS)
        platformId = randint(1, MAX_PLATFORMS)

        line = "{0};{1};{2};{3};{4};{5}\n".format(serverName, ip, version, rating, hostingId, platformId)

        f.write(line)

    print("Server data created")
    f.close()


def generatePlayerData():
    f = open(PLAYER_DATA, "w")
    faker = Faker()

    for _ in range(0, MAX_PLAYERS):
        nickname = faker.unique.user_name()
        hoursPlayed = randint(1, 100)
        lastPlayed = faker.date_between(start_date = '-1y', end_date = 'today')

        line = "{0};{1};{2}\n".format(nickname, hoursPlayed, lastPlayed)

        f.write(line)

    print("Player data created")
    f.close()



def generateUserData():
    f = open(USER_DATA, "w")
    faker = Faker()

    for _ in range(0, MAX_USERS):
        nickname = faker.unique.user_name()
        password = faker.password(length=12)
        role = "User"

        line = "{0};{1};{2}\n".format(nickname, password, role)

        f.write(line)

    print("User data created")
    f.close()


def generateServerPlayerData():
    f = open(SERVER_PLAYER_DATA, "w")

    for serverId in range(1, MAX_SERVERS + 1):
        playersOnServer = randint(1, MAX_PLAYERS - 1)
        playerIds = sample(range(1, MAX_PLAYERS), playersOnServer)

        for playerId in playerIds:
            line = "{0};{1}\n".format(serverId, playerId)
            f.write(line)

    print("ServerPlayer data created")
    f.close()


def generateFavoriteServersData():
    f = open(FAV_SERVS_DATA, "w")

    for serverId in range(1, MAX_SERVERS + 1):
        usersLikesServer = randint(1, MAX_USERS - 1)
        userIds = sample(range(1, MAX_USERS), usersLikesServer)

        for userId in userIds:
            line = "{0};{1}\n".format(serverId, userId)
            f.write(line)

    print("FavoriteServers data created")
    f.close()


def generatePlatformData():
    f = open(PLATFORM_DATA, "w")

    platforms = ["Xbox One", "Xbox Series", "PlayStation 4", "PlayStation 5", "PC", "Android", "IOS", "PSP", "PS Vita", "Nintendo Switch"]
    
    for platform in platforms:
        popularity = randint(1, 100)
        cost = randint(10, 150) * 1000

        line = "{0};{1};{2}\n".format(platform, popularity, cost)
        f.write(line)

    print("Platform data created")
    f.close()


def generateWebHostingData():
    f = open(WEBHOSTING_DATA, "w")
    faker = Faker()

    for _ in range(0, MAX_WEBHOSTINGS):
        webHostingName = faker.unique.uri()
        pricePerMonth = randint(1, 15) * 1000
        subMonths = randint(1, 12)

        line = "{0};{1};{2}\n".format(webHostingName, pricePerMonth, subMonths)
        f.write(line)

    print("WebHosting data created")
    f.close()


def main():

    #generatePlatformData()
    #generateWebHostingData()
    #generatePlayerData()
    #generateServerData()
    #generateServerPlayerData()
    generateUserData()
    generateFavoriteServersData()

    db = DataBase()

    db.copy_data()



if __name__ == "__main__":
    main()