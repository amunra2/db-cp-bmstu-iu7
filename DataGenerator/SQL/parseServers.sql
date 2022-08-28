-- Выбрать сервера (в случае необходимости берет избранные сервера пользователя по его айди)
CREATE OR REPLACE FUNCTION getServers(isFavorite boolean, userId integer)
RETURNS TABLE (SrvId integer, SrvName varchar, SrvIp varchar, SrvGameVersion varchar, SrvRating integer, SrvHostingID integer, SrvPlatformID integer)
AS $$
	BEGIN
		IF (isFavorite is False) THEN
			return query
			SELECT *
			FROM public."Server";
		ELSE
			return query
			SELECT Fav."ServerID", Fav."Name", Fav."Ip", Fav."GameVersion", Fav."Rating", Fav."HostingID", Fav."PlatformID"
			FROM (public."Server" AS S JOIN public."FavoriteServer" AS FS ON S."Id" = FS."ServerID") AS Fav
			WHERE Fav."UserID" = userId;
		END IF;
	END;
$$ LANGUAGE plpgsql;


-- Фильтрация по имени + айди платформы
CREATE OR REPLACE FUNCTION filterServers(nameParse varchar, platform_id integer, isFavorite boolean, userId integer)
RETURNS TABLE (FltId integer, FltName varchar, FltIp varchar, FltGameVersion varchar, FltRating integer, FltHostingID integer, FltPlatformID integer)
AS $$
	BEGIN
		IF (nameParse IS NULL) THEN
			nameParse = '';
		END IF;
	
		IF (platform_id > 0) THEN
			return query
			SELECT *
			FROM getServers(isFavorite, userId) as S
			WHERE S.SrvPlatformID = platform_id AND S.SrvName LIKE '%' || nameParse || '%';
		ELSE
			return query
			SELECT *
			FROM getServers(isFavorite, userId) as S
			WHERE S.SrvName LIKE '%' || nameParse || '%';
		END IF;
	END;
$$ LANGUAGE plpgsql;


-- Сортировка списка серверов (8 вариантов)
CREATE OR REPLACE FUNCTION sortServers(nameParse varchar, platform_id integer, sortId integer, isFavorite boolean, userId integer)
RETURNS TABLE (Id integer, Name varchar, Ip varchar, GameVersion varchar, Rating integer, HostingID integer, PlatformID integer)
AS $$
	BEGIN
		IF (sortId = 0) THEN -- Name ASC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltName;
		ELSEIF (sortId = 1) THEN -- Name DESC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltName DESC;
		ELSEIF (sortId = 2) THEN -- Ip ASC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltIp;
		ELSEIF (sortId = 3) THEN -- Ip DESC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltIp DESC;
		ELSEIF (sortId = 4) THEN -- GameVersion ASC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltGameVersion;
		ELSEIF (sortId = 5) THEN -- GameVersion DESC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltGameVersion DESC;
		ELSEIF (sortId = 6) THEN -- Rating ASC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltRating;
		ELSEIF (sortId = 7) THEN -- Rating DESC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltRating DESC;
		ELSEIF (sortId = 8) THEN -- Platform ASC
			return query
			SELECT PS.FltId, PS.FltName, PS.FltIp, PS.FltGameVersion, PS.FltRating, PS.FltHostingID, PS.FltPlatformID
			FROM (filterServers(nameParse, platform_id, isFavorite, userId) as S JOIN public."Platform" as P on S.FltPlatformID = P."Id") as PS
			ORDER BY PS."Name";
		ELSEIF (sortId = 9) THEN -- Platform DESC
			return query
			SELECT PS.FltId, PS.FltName, PS.FltIp, PS.FltGameVersion, PS.FltRating, PS.FltHostingID, PS.FltPlatformID
			FROM (filterServers(nameParse, platform_id, isFavorite, userId) as S JOIN public."Platform" as P on S.FltPlatformID = P."Id") as PS
			ORDER BY PS."Name" DESC;
		ELSE -- Default: Name ASC
			return query
			SELECT *
			FROM filterServers(nameParse, platform_id, isFavorite, userId) as S
			ORDER BY S.FltName;
		END IF;
	END;
$$ LANGUAGE plpgsql;


-- Парсинг серверов (обертка)
-- 1. Выбор серверов (если isFavorite - избранные сервера пользователя с айди = userId)
-- 2. Фильтрация списка серверов по Названию (вхождение) и айди платформы
-- 3. Сортировка полученных серверов (8 различных сортировок - по умолчанию: по Названию ASC)
CREATE OR REPLACE FUNCTION parseServers(nameParse varchar, platform_id integer, sortId integer, isFavorite boolean, userId integer)
RETURNS TABLE (Id integer, Name varchar, Ip varchar, GameVersion varchar, Rating integer, HostingID integer, PlatformID integer)
AS $$
	BEGIN
		return query
		SELECT * FROM sortServers(nameParse, platform_id, sortId, isFavorite, userId);
	END;
$$ LANGUAGE plpgsql;

-- Тестирование
select *
from parseServers(NULL, NULL, 0, False, 602)
