ALTER TABLE `med_db`.`врачи` 
ADD COLUMN `категория` INT NULL AFTER `enabled/disabled`;

ALTER TABLE `med_db`.`аккаунты` 
ADD COLUMN `idврач` INT(11) NULL AFTER `имя`,
ADD COLUMN `idмедперсонал` INT(11) NULL AFTER `idврач`;
