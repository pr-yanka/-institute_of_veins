RENAME TABLE категории TO виды_категорий;

CREATE TABLE `категории` (
	`id_категории` INTEGER NOT NULL,
	`id_врача` INTEGER NOT NULL,
	PRIMARY KEY (`id_категории`, `id_врача`)
);

ALTER TABLE `категории` ADD CONSTRAINT `категории_fk1` FOREIGN KEY (`id_категории`) REFERENCES `виды_категории`(`id`);

INSERT into виды_категории
	(название)
    VALUES("первая");

INSERT into виды_категории
	(название)
    VALUES("высшая");
    
INSERT into виды_научных_званий
	(название)
    VALUES("профессор");

INSERT into виды_научных_званий
	(название)
    VALUES("доктор_наук");
    
INSERT into виды_специализаций
	(название)
    VALUES("флеболог");
    
INSERT into виды_специализаций
	(название)
    VALUES("главный врач");

INSERT into виды_специализаций
	(название)
    VALUES("дерматолог");
    
INSERT into виды_специализаций
	(название)
    VALUES("хирург");


INSERT INTO врачи
	(имя, фамилия, отчество, дополнительно)
    VALUES ("Сергеевна", "Оксана", "Рябинская", "очень классная женщина");

INSERT INTO врачи
	(имя, фамилия, отчество, дополнительно)
    VALUES ("Виталий", "Шторгин", "Владимирович", "умеет работать с Excel");

INSERT INTO врачи
	(имя, фамилия, отчество, дополнительно)
    VALUES ("Сергей", "Замчий", "Владимирович", "");
    
SELECT * from врачи;

INSERT into специализации (id_специализации, id_врача) VALUES (1, 1);
INSERT into научные_звания (id_звания, id_врача) VALUES (1, 1);
INSERT into категории (id_категории, id_врача) VALUES (2, 1);

INSERT into специализации (id_специализации, id_врача) VALUES (4, 2);
INSERT into научные_звания (id_звания, id_врача) VALUES (2, 2);

INSERT into специализации (id_специализации, id_врача) VALUES (2, 3);
INSERT into специализации (id_специализации, id_врача) VALUES (3, 3);
INSERT into научные_звания (id_звания, id_врача) VALUES (2, 3);
INSERT into категории (id_категории, id_врача) VALUES (1, 3);


