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
