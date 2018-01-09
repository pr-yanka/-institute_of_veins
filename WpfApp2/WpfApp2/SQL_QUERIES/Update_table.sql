SET  FOREIGN_KEY_CHECKS=0; 
Drop table виды_ролей;



ALTER TABLE `med_db`.`аккаунты` 
DROP FOREIGN KEY `аккаунты_fk0`,
DROP FOREIGN KEY `аккаунты_fk1`;
ALTER TABLE `med_db`.`аккаунты` 
CHANGE COLUMN `роль` `роль` INT(11) NULL ,
CHANGE COLUMN `врач` `врач` TINYINT NULL ,
ADD COLUMN `админ` TINYINT NULL AFTER `врач`,
ADD COLUMN `медперсонал` TINYINT NULL AFTER `админ`,
ADD COLUMN `секретарь` TINYINT NULL AFTER `медперсонал`;
ALTER TABLE `med_db`.`аккаунты` 
ADD CONSTRAINT `аккаунты_fk0`
  FOREIGN KEY (`роль`)
  REFERENCES `med_db`.`виды_ролей` (`id`),
ADD CONSTRAINT `аккаунты_fk1`
  FOREIGN KEY (`врач`)
  REFERENCES `med_db`.`врачи` (`id`);



ALTER TABLE `med_db`.`аккаунты` 
DROP COLUMN `роль`,
DROP INDEX `аккаунты_fk0` ;





ALTER TABLE `med_db`.`аккаунты` 
ADD COLUMN `пароль` VARCHAR(100) NULL DEFAULT NULL AFTER `секретарь`;


INSERT INTO `med_db`.`аккаунты` (`id`, `админ`, `пароль`) VALUES ('1', '1', 'C3FCD3D76192E4007DFB496CCA67E13B');

ALTER TABLE `med_db`.`врачи` 
CHANGE COLUMN `дополнительно` `дополнительная_информация` VARCHAR(100) NULL DEFAULT NULL ;



ALTER TABLE `med_db`.`врачи` 
ADD COLUMN `enabled/disabled` TINYINT NULL AFTER `дополнительная_информация`;



ALTER TABLE `med_db`.`аккаунты` 
ADD COLUMN `enabled/disabled` TINYINT NULL AFTER `пароль`;


CREATE TABLE `med_db`.`медперсонал` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `имя` VARCHAR(45) NULL,
  `фамилия` VARCHAR(45) NULL,
  `отчество` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));


ALTER TABLE `med_db`.`аккаунты` 
ADD COLUMN `имя` VARCHAR(45) NULL AFTER `enabled/disabled`;

UPDATE `med_db`.`аккаунты` SET `имя`='Админ' WHERE `id`='1';

INSERT INTO `med_db`.`медперсонал` (`id`, `имя`, `фамилия`, `отчество`) VALUES ('1', 'Андрей', 'Лозыченко', 'Петрович');
INSERT INTO `med_db`.`медперсонал` (`id`, `имя`, `фамилия`, `отчество`) VALUES ('2', 'Влад', 'Иванов', 'Петрович');
INSERT INTO `med_db`.`медперсонал` (`id`, `имя`, `фамилия`, `отчество`) VALUES ('3', 'Алмаши', 'Янош', 'Петрович');



SET  FOREIGN_KEY_CHECKS=1; 