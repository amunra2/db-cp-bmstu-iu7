-- Изменяет рейтинг сервера
-- Если сервер добавлен в избранное, то добавлется запись в таблицу FavoriteServer
-- и срабатывает триггер incServerRatingTrigger, повышающий рейтинг сервера;
-- если сервер из избранного удаляется decServerRatingTrigger понижает рейтинг сервера
CREATE OR REPLACE FUNCTION changeServerRating() RETURNS trigger AS $$
	BEGIN
		IF (TG_OP = 'INSERT') THEN
			UPDATE public."Server" 
			SET "Rating" = "Rating" + 1 
			WHERE "Id" = NEW."ServerID";
			
			RETURN NEW;
		ELSIF (TG_OP = 'DELETE') THEN
			UPDATE public."Server" 
			SET "Rating" = "Rating" - 1 
			WHERE "Id" = OLD."ServerID";
	
			RETURN OLD;
		END IF;
	END;
$$ LANGUAGE plpgsql;


-- Триггер повышения рейтинга сервера
CREATE OR REPLACE TRIGGER incServerRatingTrigger AFTER INSERT ON public."FavoriteServer"
    FOR EACH ROW EXECUTE PROCEDURE changeServerRating();

-- Триггер понижения рейтинга сервера
CREATE OR REPLACE TRIGGER decServerRatingTrigger AFTER DELETE ON public."FavoriteServer"
    FOR EACH ROW EXECUTE PROCEDURE changeServerRating();
	
