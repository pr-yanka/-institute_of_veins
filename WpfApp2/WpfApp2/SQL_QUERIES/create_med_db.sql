DROP DATABASE med_db;
CREATE DATABASE med_db;

CREATE TABLE `метрика` (
	`id` INTEGER NOT NULL AUTO_INCREMENT,
	`название` varchar(5) UNIQUE,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_бедро_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_бедро_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(50),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_бедро_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	`структура4` INT,
	`структура5` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_бедра_и_несафенные_вены` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	`подзапись4` INT,
	`подзапись5` INT,
	`комментарий` VARCHAR(100),
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_голень_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура_1` INT NOT NULL,
	`структура_2` INT,
	`структура_3` INT,
	`структура_4` INT,
	`структура_5` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_голень_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_голень_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `перфорант_голень` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись_1` INT NOT NULL,
	`подзапись_2` INT,
	`подзапись_3` INT,
	`подзапись_4` INT,
	`подзапись_5` INT,
	`комментарий` VARCHAR(100),
	PRIMARY KEY (`id`)
);

CREATE TABLE `обследование_ноги` (
	`id_обследования` INT NOT NULL AUTO_INCREMENT,
	`id_СФС` INT NOT NULL UNIQUE,
	`id_БПВ_на_бедре` INT NOT NULL UNIQUE,
	`id_ПДСВ` INT UNIQUE,
	`id_ЗДСВ` INT UNIQUE,
	`id_перфоранты_бедра` INT NOT NULL UNIQUE,
	`id_БПВ_на_голени` INT NOT NULL UNIQUE,
	`id_перфорант_голени` INT UNIQUE,
	`id_СПС` INT NOT NULL UNIQUE,
	`id_МПВ` INT NOT NULL UNIQUE,
	`id_ТЕ_МПВ` INT UNIQUE,
	`id_ППВ` INT UNIQUE,
	`Примечание` varchar(300),
	`id_глубокие_вены` INT UNIQUE,
	`C` INT NOT NULL,
	`E` INT NOT NULL,
	`A` INT NOT NULL,
	`P` INT NOT NULL,
	PRIMARY KEY (`id_обследования`)
);

CREATE TABLE `диагноз` (
	`id_обследование_ноги` INT NOT NULL,
	`id_диагноз` INT NOT NULL
);

CREATE TABLE `вид_диагноз` (
	`id_вида` INT NOT NULL AUTO_INCREMENT,
	`описание` VARCHAR(200) NOT NULL,
	PRIMARY KEY (`id_вида`)
);

CREATE TABLE `Сафено-феморальное соустье` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	`подзапись4` INT,
	`подзапись5` INT,
	`подзапись6` INT,
	`комментарий` VARCHAR(100),
	PRIMARY KEY (`id`)
);

CREATE TABLE `СФС_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` VARCHAR(100) NOT NULL,
	`метрика1` FLOAT,
    `метрика2` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `СФС_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
    `двойная_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `СФС_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	`структура4` INT,
	`структура5` INT,
	`структура6` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `большая_подкожная_вена_на_бедре` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_хода` INT NOT NULL,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	`подзапись4` INT,
	`подзапись5` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `вид_БПВ_хода` (
	`id_вида` INTEGER NOT NULL AUTO_INCREMENT,
	`описание` varchar(40) NOT NULL,
	PRIMARY KEY (`id_вида`)
);

CREATE TABLE `БПВ_на_бедре_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(50),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_бедре_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_бедре_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	`структура4` INT,
	`структура5` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `задняя_добавочная_сафенная_вена` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ЗДСВ_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100) NOT NULL,
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ЗДСВ_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`есть_метрика` BOOLEAN,
	`id_метрики` INT,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ЗДСВ_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_голени` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	`подзапись4` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_голени_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100) NOT NULL,
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_голени_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `БПВ_на_голени_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	`структура4` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ПДСВ_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`есть_метрика` BOOLEAN NOT NULL,
	`id_метрики` INT,
	`уровень_вложенности` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ПДСВ_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Передняя_добавочная_сафенная_вена` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ПДСВ_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Сафено_поплитеальное_соустье` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `СПС_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INTEGER,
	`есть_метрика` BOOLEAN NOT NULL,
    `двойная_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `СПС_голень_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика1` FLOAT,
    `метрика2` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `СПС_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Вид_МПВ_хода` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(40) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `МПВ_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `МПВ_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Малая_подкожная_вена` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	`подзапись4` INT,
	`вид_хода` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `МПВ_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	`структура4` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Бедренное_продолжение_малой_подкожной_вены` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_хода_ФФ` INT,
	`протяженность_ФФ` FLOAT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	`подзапись3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ТЕ_МПВ_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT(50),
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ТЕ_МПВ_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Ход_в_фасциальном_футляре` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(40) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ТЕ_МПВ_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	`структура3` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Подколенная_перфорантная_вена` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`подзапись1` INT NOT NULL,
	`подзапись2` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ППВ_структура` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название1` varchar(150),
	`название2` varchar(100),
	`id_метрики` INT,
	`есть_метрика` BOOLEAN NOT NULL,
	`уровень_вложенности` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ППВ_подзапись` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_структуры` INT NOT NULL,
	`комментарий` varchar(100),
	`метрика` FLOAT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `ППВ_комбо` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`структура1` INT NOT NULL,
	`структура2` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `С` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`буква` INT NOT NULL,
	`индекс` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `С_клинический_класс_заболевания` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(5) NOT NULL UNIQUE,
	`описание` varchar(500),
	PRIMARY KEY (`id`)
);

CREATE TABLE `C_субъективные_симптомы` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(5) NOT NULL UNIQUE,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Е` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`буквы` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `этиология_заболевания` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(5) NOT NULL UNIQUE,
	`описание` varchar(200),
	PRIMARY KEY (`id`)
);

CREATE TABLE `А` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`буквы` integer NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `анатомическая_локализация_заболевания` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(5) NOT NULL UNIQUE,
	`описание` varchar(200),
	PRIMARY KEY (`id`)
);

CREATE TABLE `P` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`буквы` INTEGER NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `тип_расстройства` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(5) NOT NULL UNIQUE,
	`описание` varchar(200),
	PRIMARY KEY (`id`)
);

CREATE TABLE `обследование` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_пациента` INT NOT NULL,
	`дата_обследования` DATE NOT NULL,
	`вес` FLOAT(3) NOT NULL,
	`рост` FLOAT(3) NOT NULL,
	`id_обследования_правой_ноги` INT NOT NULL,
	`id_обследования_левой_ноги` INT NOT NULL,
	`id_врача` INT,
	`NB!` varchar(60),
	`нужна_операция` BOOLEAN NOT NULL,
	`вид_операции` INT,
	`комментарий_к_операции` varchar(200),
	PRIMARY KEY (`id`)
);

CREATE TABLE `рекомендации` (
	`id_рекомендации` INT NOT NULL,
	`id_обследования` INT NOT NULL,
	PRIMARY KEY (`id_рекомендации`,`id_обследования`)
);

CREATE TABLE `виды_рекомендаций` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(200) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `жалобы` (
	`id_обследования` INT NOT NULL,
	`id_жалобы` INT NOT NULL,
	PRIMARY KEY (`id_обследования`,`id_жалобы`)
);

CREATE TABLE `виды_жалоб` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(200) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `пациент` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`имя` varchar(20) NOT NULL,
	`фамилия` varchar(40) NOT NULL,
	`отчество` varchar(40) NOT NULL,
	`пол` varchar(1) NOT NULL,
	`дата_рождения` DATE NOT NULL,
	`город_проживания` varchar(30) NOT NULL DEFAULT 'Харьков',
	`улица_проживания` varchar(40) NOT NULL,
	`номер_дома` varchar(5) NOT NULL,
	`номер_квартиры` INT(3) NOT NULL,
	`телефон` varchar(16) NOT NULL,
	`электронная_почта` varchar(40),
	PRIMARY KEY (`id`)
);

CREATE TABLE `виды_патологий` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(150) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `патологии` (
	`id_патологии` INT NOT NULL,
	`id_пациента` INT NOT NULL,
	PRIMARY KEY (`id_патологии`,`id_пациента`)
);

CREATE TABLE `виды_анализа` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(100) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `анализы` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`тип_анализа` INT NOT NULL,
	`дата` DATE NOT NULL,
	`id_пациента` INT NOT NULL,
	`анализ` LONGBLOB NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `виды_операции` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`короткое_название` varchar(20) NOT NULL,
	`длинное_название` varchar(80),
	PRIMARY KEY (`id`)
);

CREATE TABLE `виды_анестезика` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(30) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `операции` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_пациента` INT NOT NULL,
	`дата_операции` DATE NOT NULL,
	`время_операции` TIME NOT NULL,
	`id_вида_операции` INT NOT NULL,
	`id_вида_анестетика` INT NOT NULL,
	`NB!` varchar(100),
	`перенос_операции` INT,
	`итоги_операции` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `категории` (
	`id` INT NOT NULL AUTO_INCREMENT,
    `название` VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);

CREATE TABLE `звания` (
	`id` INT NOT NULL AUTO_INCREMENT,
    `название` VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);

CREATE TABLE `врачи` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`имя` varchar(20) NOT NULL,
	`фамилия` varchar(40) NOT NULL,
	`отчество` varchar(40) NOT NULL,
    `id_категории` INT,
    `id_звания` INT,
    `дополнительно` VARCHAR(50),
	PRIMARY KEY (`id`)
);

ALTER TABLE `врачи` ADD CONSTRAINT `врачи_fk0` FOREIGN KEY (`id_категории`) REFERENCES `категории`(`id`);
ALTER TABLE `врачи` ADD CONSTRAINT `врачи_fk1` FOREIGN KEY (`id_звания`) REFERENCES `звания`(`id`);

CREATE TABLE `специализации` (
	`id` INT NOT NULL AUTO_INCREMENT,
    `название` VARCHAR(30) NOT NULL UNIQUE,
    PRIMARY KEY (`id`)
);

CREATE TABLE `врачи_специализации` (
	`id_врача` INT NOT NULL,
	`id_специлизации` INT NOT NULL,
	PRIMARY KEY (`id_врача`,`id_специлизации`)
);

ALTER TABLE `врачи_специализации` ADD CONSTRAINT `врачи_специализации_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи`(`id`);
ALTER TABLE `врачи_специализации` ADD CONSTRAINT `врачи_специализации_fk1` FOREIGN KEY (`id_специлизации`) REFERENCES `специализации`(`id`);

CREATE TABLE `бригада` (
	`id_врача` INT NOT NULL,
	`id_операции` INT NOT NULL,
	PRIMARY KEY (`id_врача`,`id_операции`)
);

ALTER TABLE `бригада` ADD CONSTRAINT `бригада_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи`(`id`);

ALTER TABLE `бригада` ADD CONSTRAINT `бригада_fk1` FOREIGN KEY (`id_операции`) REFERENCES `операции`(`id`);

CREATE TABLE `перенос_операции` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`дата_переноса` DATE NOT NULL,
	`причина` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `итоги_операции` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`описание` varchar(200) NOT NULL,
	`id_следущей_операции` INT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `причины_переноса` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`причина` varchar(100) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `аккаунты` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`роль` INT NOT NULL,
	`врач` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `виды_ролей` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(20) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `история_изменений` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_аккаунта` INT NOT NULL,
	`название_таблицы` varchar(50) NOT NULL,
	`название_столбца` varchar(50) NOT NULL,
	`дата_изменения` DATETIME NOT NULL,
	`старое_значение` varchar(200),
	`новое_значение` varchar(200),
	`тип_изменения` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `виды_изменений` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`название` varchar(20) NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `перфорант_бедро_структура` ADD CONSTRAINT `перфорант_бедро_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `перфорант_бедро_подзапись` ADD CONSTRAINT `перфорант_бедро_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедро_комбо` ADD CONSTRAINT `перфорант_бедро_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедро_комбо` ADD CONSTRAINT `перфорант_бедро_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедро_комбо` ADD CONSTRAINT `перфорант_бедро_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедро_комбо` ADD CONSTRAINT `перфорант_бедро_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедро_комбо` ADD CONSTRAINT `перфорант_бедро_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `перфорант_бедро_структура`(`id`);

ALTER TABLE `перфорант_бедра_и_несафенные_вены` ADD CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `перфорант_бедро_подзапись`(`id`);

ALTER TABLE `перфорант_бедра_и_несафенные_вены` ADD CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `перфорант_бедро_подзапись`(`id`);

ALTER TABLE `перфорант_бедра_и_несафенные_вены` ADD CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `перфорант_бедро_подзапись`(`id`);

ALTER TABLE `перфорант_бедра_и_несафенные_вены` ADD CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `перфорант_бедро_подзапись`(`id`);

ALTER TABLE `перфорант_бедра_и_несафенные_вены` ADD CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk4` FOREIGN KEY (`подзапись5`) REFERENCES `перфорант_бедро_подзапись`(`id`);

ALTER TABLE `перфорант_голень_комбо` ADD CONSTRAINT `перфорант_голень_комбо_fk0` FOREIGN KEY (`структура_1`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень_комбо` ADD CONSTRAINT `перфорант_голень_комбо_fk1` FOREIGN KEY (`структура_2`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень_комбо` ADD CONSTRAINT `перфорант_голень_комбо_fk2` FOREIGN KEY (`структура_3`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень_комбо` ADD CONSTRAINT `перфорант_голень_комбо_fk3` FOREIGN KEY (`структура_4`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень_комбо` ADD CONSTRAINT `перфорант_голень_комбо_fk4` FOREIGN KEY (`структура_5`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень_структура` ADD CONSTRAINT `перфорант_голень_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `перфорант_голень_подзапись` ADD CONSTRAINT `перфорант_голень_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `перфорант_голень_структура`(`id`);

ALTER TABLE `перфорант_голень` ADD CONSTRAINT `перфорант_голень_fk0` FOREIGN KEY (`подзапись_1`) REFERENCES `перфорант_голень_подзапись`(`id`);

ALTER TABLE `перфорант_голень` ADD CONSTRAINT `перфорант_голень_fk1` FOREIGN KEY (`подзапись_2`) REFERENCES `перфорант_голень_подзапись`(`id`);

ALTER TABLE `перфорант_голень` ADD CONSTRAINT `перфорант_голень_fk2` FOREIGN KEY (`подзапись_3`) REFERENCES `перфорант_голень_подзапись`(`id`);

ALTER TABLE `перфорант_голень` ADD CONSTRAINT `перфорант_голень_fk3` FOREIGN KEY (`подзапись_4`) REFERENCES `перфорант_голень_подзапись`(`id`);

ALTER TABLE `перфорант_голень` ADD CONSTRAINT `перфорант_голень_fk4` FOREIGN KEY (`подзапись_5`) REFERENCES `перфорант_голень_подзапись`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk0` FOREIGN KEY (`id_СФС`) REFERENCES `Сафено-феморальное соустье`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk1` FOREIGN KEY (`id_БПВ_на_бедре`) REFERENCES `большая_подкожная_вена_на_бедре`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk2` FOREIGN KEY (`id_ПДСВ`) REFERENCES `Передняя_добавочная_сафенная_вена`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk3` FOREIGN KEY (`id_ЗДСВ`) REFERENCES `задняя_добавочная_сафенная_вена`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk4` FOREIGN KEY (`id_перфоранты_бедра`) REFERENCES `перфорант_бедра_и_несафенные_вены`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk5` FOREIGN KEY (`id_БПВ_на_голени`) REFERENCES `БПВ_на_голени`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk6` FOREIGN KEY (`id_перфорант_голени`) REFERENCES `перфорант_голень`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk7` FOREIGN KEY (`id_СПС`) REFERENCES `Сафено_поплитеальное_соустье`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk8` FOREIGN KEY (`id_МПВ`) REFERENCES `Малая_подкожная_вена`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk9` FOREIGN KEY (`id_ТЕ_МПВ`) REFERENCES `Бедренное_продолжение_малой_подкожной_вены`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk10` FOREIGN KEY (`id_ППВ`) REFERENCES `Подколенная_перфорантная_вена`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk11` FOREIGN KEY (`C`) REFERENCES `С`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk12` FOREIGN KEY (`E`) REFERENCES `Е`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk13` FOREIGN KEY (`A`) REFERENCES `А`(`id`);

ALTER TABLE `обследование_ноги` ADD CONSTRAINT `обследование_ноги_fk14` FOREIGN KEY (`P`) REFERENCES `P`(`id`);

ALTER TABLE `диагноз` ADD CONSTRAINT `диагноз_fk0` FOREIGN KEY (`id_обследование_ноги`) REFERENCES `обследование_ноги`(`id_обследования`);

ALTER TABLE `диагноз` ADD CONSTRAINT `диагноз_fk1` FOREIGN KEY (`id_диагноз`) REFERENCES `вид_диагноз`(`id_вида`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk4` FOREIGN KEY (`подзапись5`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `Сафено-феморальное соустье` ADD CONSTRAINT `Сафено-феморальное соустье_fk5` FOREIGN KEY (`подзапись6`) REFERENCES `СФС_подзапись`(`id`);

ALTER TABLE `СФС_подзапись` ADD CONSTRAINT `СФС_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_структура` ADD CONSTRAINT `СФС_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `СФС_комбо` ADD CONSTRAINT `СФС_комбо_fk5` FOREIGN KEY (`структура6`) REFERENCES `СФС_структура`(`id`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk0` FOREIGN KEY (`id_хода`) REFERENCES `вид_БПВ_хода`(`id_вида`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk1` FOREIGN KEY (`подзапись1`) REFERENCES `БПВ_на_бедре_подзапись`(`id`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk2` FOREIGN KEY (`подзапись2`) REFERENCES `БПВ_на_бедре_подзапись`(`id`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk3` FOREIGN KEY (`подзапись3`) REFERENCES `БПВ_на_бедре_подзапись`(`id`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk4` FOREIGN KEY (`подзапись4`) REFERENCES `БПВ_на_бедре_подзапись`(`id`);

ALTER TABLE `большая_подкожная_вена_на_бедре` ADD CONSTRAINT `большая_подкожная_вена_на_бедре_fk5` FOREIGN KEY (`подзапись5`) REFERENCES `БПВ_на_бедре_подзапись`(`id`);

ALTER TABLE `БПВ_на_бедре_подзапись` ADD CONSTRAINT `БПВ_на_бедре_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `БПВ_на_бедре_структура` ADD CONSTRAINT `БПВ_на_бедре_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `БПВ_на_бедре_комбо` ADD CONSTRAINT `БПВ_на_бедре_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `БПВ_на_бедре_комбо` ADD CONSTRAINT `БПВ_на_бедре_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `БПВ_на_бедре_комбо` ADD CONSTRAINT `БПВ_на_бедре_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `БПВ_на_бедре_комбо` ADD CONSTRAINT `БПВ_на_бедре_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `БПВ_на_бедре_комбо` ADD CONSTRAINT `БПВ_на_бедре_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `БПВ_на_бедре_структура`(`id`);

ALTER TABLE `задняя_добавочная_сафенная_вена` ADD CONSTRAINT `задняя_добавочная_сафенная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `ЗДСВ_подзапись`(`id`);

ALTER TABLE `задняя_добавочная_сафенная_вена` ADD CONSTRAINT `задняя_добавочная_сафенная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `ЗДСВ_подзапись`(`id`);

ALTER TABLE `задняя_добавочная_сафенная_вена` ADD CONSTRAINT `задняя_добавочная_сафенная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `ЗДСВ_подзапись`(`id`);

ALTER TABLE `ЗДСВ_подзапись` ADD CONSTRAINT `ЗДСВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `ЗДСВ_структура`(`id`);

ALTER TABLE `ЗДСВ_структура` ADD CONSTRAINT `ЗДСВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `ЗДСВ_комбо` ADD CONSTRAINT `ЗДСВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `ЗДСВ_структура`(`id`);

ALTER TABLE `ЗДСВ_комбо` ADD CONSTRAINT `ЗДСВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `ЗДСВ_структура`(`id`);

ALTER TABLE `ЗДСВ_комбо` ADD CONSTRAINT `ЗДСВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `ЗДСВ_структура`(`id`);

ALTER TABLE `БПВ_на_голени` ADD CONSTRAINT `БПВ_на_голени_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `БПВ_на_голени_подзапись`(`id`);

ALTER TABLE `БПВ_на_голени` ADD CONSTRAINT `БПВ_на_голени_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `БПВ_на_голени_подзапись`(`id`);

ALTER TABLE `БПВ_на_голени` ADD CONSTRAINT `БПВ_на_голени_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `БПВ_на_голени_подзапись`(`id`);

ALTER TABLE `БПВ_на_голени` ADD CONSTRAINT `БПВ_на_голени_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `БПВ_на_голени_подзапись`(`id`);

ALTER TABLE `БПВ_на_голени_подзапись` ADD CONSTRAINT `БПВ_на_голени_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `БПВ_на_голени_структура`(`id`);

ALTER TABLE `БПВ_на_голени_структура` ADD CONSTRAINT `БПВ_на_голени_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `БПВ_на_голени_комбо` ADD CONSTRAINT `БПВ_на_голени_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `БПВ_на_голени_структура`(`id`);

ALTER TABLE `БПВ_на_голени_комбо` ADD CONSTRAINT `БПВ_на_голени_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `БПВ_на_голени_структура`(`id`);

ALTER TABLE `БПВ_на_голени_комбо` ADD CONSTRAINT `БПВ_на_голени_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `БПВ_на_голени_структура`(`id`);

ALTER TABLE `БПВ_на_голени_комбо` ADD CONSTRAINT `БПВ_на_голени_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `БПВ_на_голени_структура`(`id`);

ALTER TABLE `ПДСВ_структура` ADD CONSTRAINT `ПДСВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `ПДСВ_подзапись` ADD CONSTRAINT `ПДСВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `Передняя_добавочная_сафенная_вена` ADD CONSTRAINT `Передняя_добавочная_сафенная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `ПДСВ_подзапись`(`id`);

ALTER TABLE `Передняя_добавочная_сафенная_вена` ADD CONSTRAINT `Передняя_добавочная_сафенная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `ПДСВ_подзапись`(`id`);

ALTER TABLE `Передняя_добавочная_сафенная_вена` ADD CONSTRAINT `Передняя_добавочная_сафенная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `ПДСВ_подзапись`(`id`);

ALTER TABLE `ПДСВ_комбо` ADD CONSTRAINT `ПДСВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `ПДСВ_комбо` ADD CONSTRAINT `ПДСВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `ПДСВ_комбо` ADD CONSTRAINT `ПДСВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `Сафено_поплитеальное_соустье` ADD CONSTRAINT `Сафено_поплитеальное_соустье_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `СПС_голень_подзапись`(`id`);

ALTER TABLE `Сафено_поплитеальное_соустье` ADD CONSTRAINT `Сафено_поплитеальное_соустье_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `СПС_голень_подзапись`(`id`);

ALTER TABLE `Сафено_поплитеальное_соустье` ADD CONSTRAINT `Сафено_поплитеальное_соустье_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `СПС_голень_подзапись`(`id`);

ALTER TABLE `СПС_структура` ADD CONSTRAINT `СПС_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `СПС_голень_подзапись` ADD CONSTRAINT `СПС_голень_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `СПС_структура`(`id`);

ALTER TABLE `СПС_комбо` ADD CONSTRAINT `СПС_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `СПС_структура`(`id`);

ALTER TABLE `СПС_комбо` ADD CONSTRAINT `СПС_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `СПС_структура`(`id`);

ALTER TABLE `СПС_комбо` ADD CONSTRAINT `СПС_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `СПС_структура`(`id`);

ALTER TABLE `МПВ_структура` ADD CONSTRAINT `МПВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `МПВ_подзапись` ADD CONSTRAINT `МПВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `МПВ_структура`(`id`);

ALTER TABLE `Малая_подкожная_вена` ADD CONSTRAINT `Малая_подкожная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `МПВ_подзапись`(`id`);

ALTER TABLE `Малая_подкожная_вена` ADD CONSTRAINT `Малая_подкожная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `МПВ_подзапись`(`id`);

ALTER TABLE `Малая_подкожная_вена` ADD CONSTRAINT `Малая_подкожная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `МПВ_подзапись`(`id`);

ALTER TABLE `Малая_подкожная_вена` ADD CONSTRAINT `Малая_подкожная_вена_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `МПВ_подзапись`(`id`);

ALTER TABLE `Малая_подкожная_вена` ADD CONSTRAINT `Малая_подкожная_вена_fk4` FOREIGN KEY (`вид_хода`) REFERENCES `Вид_МПВ_хода`(`id`);

ALTER TABLE `МПВ_комбо` ADD CONSTRAINT `МПВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `МПВ_структура`(`id`);

ALTER TABLE `МПВ_комбо` ADD CONSTRAINT `МПВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `МПВ_структура`(`id`);

ALTER TABLE `МПВ_комбо` ADD CONSTRAINT `МПВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `МПВ_структура`(`id`);

ALTER TABLE `МПВ_комбо` ADD CONSTRAINT `МПВ_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `МПВ_структура`(`id`);

ALTER TABLE `Бедренное_продолжение_малой_подкожной_вены` ADD CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk0` FOREIGN KEY (`id_хода_ФФ`) REFERENCES `Ход_в_фасциальном_футляре`(`id`);

ALTER TABLE `Бедренное_продолжение_малой_подкожной_вены` ADD CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk1` FOREIGN KEY (`подзапись1`) REFERENCES `ТЕ_МПВ_подзапись`(`id`);

ALTER TABLE `Бедренное_продолжение_малой_подкожной_вены` ADD CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk2` FOREIGN KEY (`подзапись2`) REFERENCES `ТЕ_МПВ_подзапись`(`id`);

ALTER TABLE `Бедренное_продолжение_малой_подкожной_вены` ADD CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk3` FOREIGN KEY (`подзапись3`) REFERENCES `ТЕ_МПВ_подзапись`(`id`);

ALTER TABLE `ТЕ_МПВ_структура` ADD CONSTRAINT `ТЕ_МПВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `ТЕ_МПВ_подзапись` ADD CONSTRAINT `ТЕ_МПВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `ТЕ_МПВ_структура`(`id`);

ALTER TABLE `ТЕ_МПВ_комбо` ADD CONSTRAINT `ТЕ_МПВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `ТЕ_МПВ_структура`(`id`);

ALTER TABLE `ТЕ_МПВ_комбо` ADD CONSTRAINT `ТЕ_МПВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `ТЕ_МПВ_структура`(`id`);

ALTER TABLE `ТЕ_МПВ_комбо` ADD CONSTRAINT `ТЕ_МПВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `ТЕ_МПВ_структура`(`id`);

ALTER TABLE `Подколенная_перфорантная_вена` ADD CONSTRAINT `Подколенная_перфорантная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `ППВ_подзапись`(`id`);

ALTER TABLE `Подколенная_перфорантная_вена` ADD CONSTRAINT `Подколенная_перфорантная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `ППВ_подзапись`(`id`);

ALTER TABLE `ППВ_структура` ADD CONSTRAINT `ППВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика`(`id`);

ALTER TABLE `ППВ_подзапись` ADD CONSTRAINT `ППВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `ППВ_структура`(`id`);

ALTER TABLE `ППВ_комбо` ADD CONSTRAINT `ППВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `ППВ_комбо` ADD CONSTRAINT `ППВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `ПДСВ_структура`(`id`);

ALTER TABLE `С` ADD CONSTRAINT `С_fk0` FOREIGN KEY (`буква`) REFERENCES `С_клинический_класс_заболевания`(`id`);

ALTER TABLE `С` ADD CONSTRAINT `С_fk1` FOREIGN KEY (`индекс`) REFERENCES `C_субъективные_симптомы`(`id`);

ALTER TABLE `Е` ADD CONSTRAINT `Е_fk0` FOREIGN KEY (`буквы`) REFERENCES `этиология_заболевания`(`id`);

ALTER TABLE `А` ADD CONSTRAINT `А_fk0` FOREIGN KEY (`буквы`) REFERENCES `анатомическая_локализация_заболевания`(`id`);

ALTER TABLE `P` ADD CONSTRAINT `P_fk0` FOREIGN KEY (`буквы`) REFERENCES `тип_расстройства`(`id`);

ALTER TABLE `обследование` ADD CONSTRAINT `обследование_fk0` FOREIGN KEY (`id_пациента`) REFERENCES `пациент`(`id`);

ALTER TABLE `обследование` ADD CONSTRAINT `обследование_fk1` FOREIGN KEY (`id_обследования_правой_ноги`) REFERENCES `обследование_ноги`(`id_обследования`);

ALTER TABLE `обследование` ADD CONSTRAINT `обследование_fk2` FOREIGN KEY (`id_обследования_левой_ноги`) REFERENCES `обследование_ноги`(`id_обследования`);

ALTER TABLE `обследование` ADD CONSTRAINT `обследование_fk3` FOREIGN KEY (`вид_операции`) REFERENCES `виды_операции`(`id`);

ALTER TABLE `рекомендации` ADD CONSTRAINT `рекомендации_fk0` FOREIGN KEY (`id_рекомендации`) REFERENCES `виды_рекомендаций`(`id`);

ALTER TABLE `рекомендации` ADD CONSTRAINT `рекомендации_fk1` FOREIGN KEY (`id_обследования`) REFERENCES `обследование`(`id`);

ALTER TABLE `жалобы` ADD CONSTRAINT `жалобы_fk0` FOREIGN KEY (`id_обследования`) REFERENCES `обследование`(`id`);

ALTER TABLE `жалобы` ADD CONSTRAINT `жалобы_fk1` FOREIGN KEY (`id_жалобы`) REFERENCES `виды_жалоб`(`id`);

ALTER TABLE `патологии` ADD CONSTRAINT `патологии_fk0` FOREIGN KEY (`id_патологии`) REFERENCES `виды_патологий`(`id`);

ALTER TABLE `патологии` ADD CONSTRAINT `патологии_fk1` FOREIGN KEY (`id_пациента`) REFERENCES `пациент`(`id`);

ALTER TABLE `анализы` ADD CONSTRAINT `анализы_fk0` FOREIGN KEY (`тип_анализа`) REFERENCES `виды_анализа`(`id`);

ALTER TABLE `анализы` ADD CONSTRAINT `анализы_fk1` FOREIGN KEY (`id_пациента`) REFERENCES `пациент`(`id`);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk0` FOREIGN KEY (`id_пациента`) REFERENCES `пациент`(`id`);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk1` FOREIGN KEY (`id_вида_операции`) REFERENCES `виды_операции`(`id`);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk2` FOREIGN KEY (`id_вида_анестетика`) REFERENCES `виды_анестезика`(`id`);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk3` FOREIGN KEY (`перенос_операции`) REFERENCES `перенос_операции`(`id`);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk4` FOREIGN KEY (`итоги_операции`) REFERENCES `итоги_операции`(`id`);

ALTER TABLE `перенос_операции` ADD CONSTRAINT `перенос_операции_fk0` FOREIGN KEY (`причина`) REFERENCES `причины_переноса`(`id`);

ALTER TABLE `итоги_операции` ADD CONSTRAINT `итоги_операции_fk0` FOREIGN KEY (`id_следущей_операции`) REFERENCES `операции`(`id`);

ALTER TABLE `аккаунты` ADD CONSTRAINT `аккаунты_fk0` FOREIGN KEY (`роль`) REFERENCES `виды_ролей`(`id`);

ALTER TABLE `аккаунты` ADD CONSTRAINT `аккаунты_fk1` FOREIGN KEY (`врач`) REFERENCES `врачи`(`id`);

ALTER TABLE `история_изменений` ADD CONSTRAINT `история_изменений_fk0` FOREIGN KEY (`id_аккаунта`) REFERENCES `аккаунты`(`id`);

ALTER TABLE `история_изменений` ADD CONSTRAINT `история_изменений_fk1` FOREIGN KEY (`тип_изменения`) REFERENCES `виды_изменений`(`id`);
