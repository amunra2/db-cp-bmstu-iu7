-- Выдает роль новому пользователю
-- Если пользователь имеет логин 'admin', то он автоматически получает роль админа
CREATE OR REPLACE FUNCTION setUserRole() RETURNS trigger AS $$
	BEGIN
		NEW."Role" := 'User';
		
		-- Если ник админ, то роль выдать админа
		IF (NEW."Login" = 'admin') THEN
			NEW."Role" := 'Admin';
		END IF;
		
		RETURN NEW;
	END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER setUserRoleTrigger BEFORE INSERT ON public."User"
    FOR EACH ROW EXECUTE PROCEDURE setUserRole();