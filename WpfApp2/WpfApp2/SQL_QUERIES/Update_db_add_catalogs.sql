CREATE TABLE `med_db`.`справочник_область` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `название` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



CREATE TABLE `med_db`.`справочник_города` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `название` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



CREATE TABLE `med_db`.`справочник_районы` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `название` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



CREATE TABLE `med_db`.`справочник_улицы` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `название` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('1', 'Богдана Хмельницкого ул.');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('2', 'Гурзуфская ул.');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('3', 'Максимилиановская ул.');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('4', 'Есенина ул.');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('5', 'Енисейская');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('6', 'Ереванская');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('7', 'Елочная');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('8', 'Елецкая');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('9', 'Емицкая');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('10', 'Емельницкая');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('11', 'Евская');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('12', 'Ервианская');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('13', 'Еленинградская');
INSERT INTO `med_db`.`справочник_улицы` (`id`, `название`) VALUES ('14', 'Ельцкая');


INSERT INTO `med_db`.`справочник_районы` (`id`, `название`) VALUES ('1', 'Киевский');
INSERT INTO `med_db`.`справочник_районы` (`id`, `название`) VALUES ('2', 'Холодногорский');
INSERT INTO `med_db`.`справочник_районы` (`id`, `название`) VALUES ('3', 'Индустриальный');


INSERT INTO `med_db`.`справочник_область` (`id`, `название`) VALUES ('1', 'Харьковская ');
INSERT INTO `med_db`.`справочник_область` (`id`, `название`) VALUES ('2', 'Вінницька');

INSERT INTO `med_db`.`справочник_города` (`id`, `название`) VALUES ('1', 'Харьков');
INSERT INTO `med_db`.`справочник_города` (`id`, `название`) VALUES ('2', 'Ялта ');
INSERT INTO `med_db`.`справочник_города` (`id`, `название`) VALUES ('3', 'Гай ');
INSERT INTO `med_db`.`справочник_города` (`id`, `название`) VALUES ('4', 'Огриммар');



UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='1';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='2';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='3';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='4';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='5';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='6';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='8';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='7';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='9';
UPDATE `med_db`.`пациент` SET `город_проживания`='1', `улица_проживания`='1' WHERE `id`='10';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='10';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='9';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='8';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='7';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='6';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='5';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='4';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='3';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='2';
UPDATE `med_db`.`пациент` SET `область_проживания`='1' WHERE `id`='1';


ALTER TABLE `med_db`.`пациент` 
CHANGE COLUMN `город_проживания` `город_проживания` INT(11) NOT NULL ,
CHANGE COLUMN `улица_проживания` `улица_проживания` INT(11) NOT NULL ,
ADD COLUMN `район_проживания` INT(11) NULL AFTER `электронная_почта`,
ADD COLUMN `область_проживания` INT(11) NOT NULL AFTER `район_проживания`,
ADD COLUMN `место_работы` VARCHAR(45) NULL AFTER `область_проживания`;




