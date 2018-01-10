ALTER TABLE `med_db`.`врачи_специализации` 
DROP FOREIGN KEY `врачи_специализации_fk1`;

ALTER TABLE `med_db`.`врачи_специализации` 
ADD CONSTRAINT `врачи_специализации_fk1`
  FOREIGN KEY (`id_специлизации`)
  REFERENCES `med_db`.`виды_специализаций` (`id`);
  
ALTER TABLE `med_db`.`медперсонал` 
ADD COLUMN `enabled/disabled` TINYINT NULL AFTER `отчество`;



CREATE TABLE `бригада_медперсонал` (
	`id_медперсонал` INT NOT NULL,
	`id_операции` INT NOT NULL,
	PRIMARY KEY (`id_медперсонал`,`id_операции`)
);



ALTER TABLE `бригада_медперсонал` ADD CONSTRAINT `бригада_медперсонал_fk0` FOREIGN KEY (`id_медперсонал`) REFERENCES `медперсонал`(`id`);

ALTER TABLE `бригада_медперсонал` ADD CONSTRAINT `бригада_медперсонал_fk1` FOREIGN KEY (`id_операции`) REFERENCES `операции`(`id`);
