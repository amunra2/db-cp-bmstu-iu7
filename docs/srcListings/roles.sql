-- Создать роль: Админ
CREATE ROLE admin WITH
  LOGIN
  SUPERUSER
  CREATEDB
  CREATEROLE
  NOREPLICATION
  PASSWORD 'admin'
  CONNECTION LIMIT  -1;

-- Привелегии
GRANT ALL PRIVILEGES ON ALL TABLES in schema public TO admin;


-- Создать роль: Неавторизованный пользователь
CREATE ROLE non_auth_user WITH
  LOGIN
  NOSUPERUSER
  NOCREATEDB
  NOCREATEROLE
  NOREPLICATION
  PASSWORD 'non_auth_user'
  CONNECTION LIMIT  -1;

-- Привелегии
GRANT SELECT ON public."Server" TO non_auth_user;
GRANT SELECT ON public."Platform" TO non_auth_user;
GRANT SELECT ON public."User" TO non_auth_user;

GRANT INSERT ON public."User" TO non_auth_user;


-- Создать роль: Авторизованный пользователь
CREATE ROLE auth_user WITH
  LOGIN
  NOSUPERUSER
  NOCREATEDB
  NOCREATEROLE
  NOREPLICATION
  PASSWORD 'auth_user'
  CONNECTION LIMIT  -1;

-- Привелегии
GRANT SELECT ON public."Server" TO auth_user;
GRANT SELECT ON public."Platform" TO auth_user;
GRANT SELECT ON public."FavoriteServer" TO auth_user;
GRANT SELECT ON public."ServerPlayer" TO auth_user;
GRANT SELECT ON public."Player" TO auth_user;
GRANT SELECT ON public."User" TO auth_user;
GRANT SELECT ON public."WebHosting" TO auth_user;

GRANT INSERT ON public."FavoriteServer" TO auth_user;
GRANT INSERT ON public."User" TO auth_user;

GRANT UPDATE ON public."Server" TO auth_user;

GRANT DELETE ON public."FavoriteServer" TO auth_user;


-- Удалить привилегию
-- REVOKE SELECT ON public."Platform" TO nonAuthUser;

-- Удалить роль
-- DROP ROLE nonAuthUser;