
CREATE TABLE `звания` (
	`id` INT NOT NULL AUTO_INCREMENT,
    `название` VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);
RENAME TABLE категории TO виды_категорий;

RENAME TABLE звания TO виды_научных_званий;

RENAME TABLE специализации TO виды_специализаций;

CREATE TABLE `категории` (
	`id_категории` INTEGER NOT NULL,
	`id_врача` INTEGER NOT NULL,
	PRIMARY KEY (`id_категории`, `id_врача`)
);

CREATE TABLE `научные_звания` (
	`id_звания` INTEGER NOT NULL,
	`id_врача` INTEGER NOT NULL,
	PRIMARY KEY (`id_звания`, `id_врача`)
);

CREATE TABLE `виды_специализаций` (
	`id` INTEGER NOT NULL,
	`название` VARCHAR(50)
);

CREATE TABLE `специализации` (
	`id_специализации` INTEGER NOT NULL,
	`id_врача` INTEGER NOT NULL,
	PRIMARY KEY (`id_специализации`, `id_врача`)
);

SET FOREIGN_KEY_CHECKS=0; DROP TABLE `врачи`; SET FOREIGN_KEY_CHECKS=1;

CREATE TABLE `врачи` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`имя` varchar(20) NOT NULL,
	`фамилия` varchar(40) NOT NULL,
	`отчество` varchar(40) NOT NULL,
    `дополнительно` VARCHAR(100),
	PRIMARY KEY (`id`)
);

ALTER TABLE `специализации` ADD CONSTRAINT `специализации_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи`(`id`);
ALTER TABLE `специализации` ADD CONSTRAINT `специализации_fk1` FOREIGN KEY (`id_специализации`) REFERENCES `виды_специализаций`(`id`);

ALTER TABLE `научные_звания` ADD CONSTRAINT `научные_звания_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи`(`id`);
ALTER TABLE `научные_звания` ADD CONSTRAINT `научные_звания_fk1` FOREIGN KEY (`id_звания`) REFERENCES `виды_научных_званий`(`id`);

ALTER TABLE `категории` ADD CONSTRAINT `категории_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи`(`id`);
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
    VALUES ("Оксана", "Сергеевна", "Рябинская", "очень классная женщина");

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