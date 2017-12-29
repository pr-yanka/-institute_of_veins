ALTER TABLE перенос_операции ADD операция_отменена BOOLEAN NOT NULL ;  

RENAME TABLE перенос_операции TO отмена_операции;

SET FOREIGN_KEY_CHECKS=0; DROP TABLE `операции`; SET FOREIGN_KEY_CHECKS=1;

CREATE TABLE `операции` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`id_пациента` INT NOT NULL,
	`дата_операции` DATE NOT NULL,
	`время_операции` TIME NOT NULL,
	`id_вида_операции` INT NOT NULL,
	`id_вида_анестетика` INT NOT NULL,
	`NB!` varchar(100),
	`отмена_операции` INT UNIQUE,
	`итоги_операции` INT UNIQUE,
	PRIMARY KEY (`id`)
);

ALTER TABLE `операции` ADD CONSTRAINT `операции_fk0` FOREIGN KEY (`отмена_операции`) REFERENCES `отмена_операции`(`id`);
