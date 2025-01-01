-- Первичный ключ таблицы Server
CREATE INDEX server_id_index on public."Server" using btree("Id");

-- Столбец табилцы Server
CREATE INDEX server_rating_index on public."Server" using btree("Rating");
