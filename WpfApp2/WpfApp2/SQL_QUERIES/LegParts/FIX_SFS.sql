ALTER TABLE `med_db`.`сфс_подзапись` 
CHANGE COLUMN `комментарий` `комментарий` VARCHAR(100) NULL ;

ALTER TABLE `med_db`.`передняя_добавочная_сафенная_вена` 
ADD COLUMN `id_хода` INT(11) NULL AFTER `подзапись3`;

CREATE TABLE `med_db`.`вид_пдсв_хода` (
  `id_вида` INT(11) NOT NULL,
  `описание` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`id_вида`));


INSERT INTO `med_db`.`вид_пдсв_хода` (`id_вида`, `описание`) VALUES ('1', 'обычный');
INSERT INTO `med_db`.`вид_пдсв_хода` (`id_вида`, `описание`) VALUES ('2', 'извитой');