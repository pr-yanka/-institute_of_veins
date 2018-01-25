ALTER TABLE `med_db`.`бпв_на_голени_подзапись` 
CHANGE COLUMN `комментарий` `комментарий` VARCHAR(100) NULL ;


ALTER TABLE `med_db`.`здсв_подзапись` 
CHANGE COLUMN `комментарий` `комментарий` VARCHAR(100) NULL ;


INSERT INTO `med_db`.`ход_в_фасциальном_футляре` (`id`, `описание`) VALUES ('1', 'извитой ход в фасциальном футляре');
INSERT INTO `med_db`.`ход_в_фасциальном_футляре` (`id`, `описание`) VALUES ('2', 'прямолинейный ход в фасциальном футляре');



ALTER TABLE `med_db`.`ход_в_фасциальном_футляре` 
CHANGE COLUMN `id` `id_вида` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `med_db`.`вид_мпв_хода` 
CHANGE COLUMN `id` `id_вида` INT(11) NOT NULL AUTO_INCREMENT ;


ALTER TABLE `med_db`.`с` 
CHANGE COLUMN `индекс` `хвостик` VARCHAR(100) NOT NULL ;

ALTER TABLE `med_db`.`с` 
RENAME TO  `med_db`.`буквы` ;


INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('1', 'C', '0');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('2', 'C', '1');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('3', 'E', 'с');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('4', 'E', 'п');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('5', 'A', 's');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('6', 'A', 'п');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('7', 'P', 'r');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('8', 'P', 'o');






INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('9', 'C', '2');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('10', 'C', '3');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('11', 'C', '4a');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('12', 'C', '4b');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('13', 'C', '5');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('14', 'C', '6');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('15', 'E', 's');
UPDATE `med_db`.`буквы` SET `хвостик`='p' WHERE `id`='4';
UPDATE `med_db`.`буквы` SET `хвостик`='c' WHERE `id`='3';
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('16', 'E', 'n');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('17', 'A', 's');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('18', 'A', 'p');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('19', 'A', 'd');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('20', 'A', 'n');
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('21', 'P', 'r,o');
DELETE FROM `med_db`.`буквы` WHERE `id`='5';
DELETE FROM `med_db`.`буквы` WHERE `id`='6';
INSERT INTO `med_db`.`буквы` (`id`, `буква`, `хвостик`) VALUES ('22', 'P', 'n');

