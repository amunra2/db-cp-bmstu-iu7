COPY public."Platform"("Name", "Popularity", "Cost") 
from 'E:\PGAdminData\platform_data.csv' delimiter ';';

COPY public."WebHosting"("Name", "PricePerMonth", "SubMonths") 
from 'E:\PGAdminData\webhosting_data.csv' delimiter ';';

COPY public."Server"("Name", "Ip", "GameVersion", "Rating", "HostingID", "PlatformID") 
from 'E:\PGAdminData\server_data.csv' delimiter ';';

COPY public."Player"("Nickname", "HoursPlayed", "LastPlayed") 
from 'E:\PGAdminData\player_data.csv' delimiter ';';

COPY public."ServerPlayer"("ServerID", "PlayerID") 
from 'E:\PGAdminData\server_player_data.csv' delimiter ';';

COPY public."User"("Login", "Password", "Role")
from 'E:\PGAdminData\user_data.csv' delimiter ';';

COPY public."FavoriteServer"("ServerID", "UserID") 
from 'E:\PGAdminData\fav_servs_data.csv' delimiter ';';