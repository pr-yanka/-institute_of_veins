CREATE TABLE `med_db`.`глубокие_вены` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` INT(11) NOT NULL,
  `подзапись2` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`));
  
  
CREATE TABLE `med_db`.`гв_комбо` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `структура1` INT(11) NOT NULL,
  `структура2` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`));


CREATE TABLE `med_db`.`гв_подзапись` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` INT(11) NOT NULL,
  `комментарий` VARCHAR(50) NULL DEFAULT NULL,
  `метрика` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`id`));
  
  
CREATE TABLE `med_db`.`гв_структура` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `название1` VARCHAR(150) NULL DEFAULT NULL,
  `название2` VARCHAR(100) NULL DEFAULT NULL,
  `id_метрики` INT(11) NULL DEFAULT NULL,
  `есть_метрика` TINYINT(1) NOT NULL,
  `уровень_вложенности` INT(11) NOT NULL,
  PRIMARY KEY (`id`));
  
  
SET FOREIGN_KEY_CHECKS=0; 
ALTER TABLE `med_db`.`гв_комбо` 
ADD INDEX `ГВ_комбо_fk0_idx` (`структура1` ASC),
ADD INDEX `ГВ_комбо_fk1_idx` (`структура2` ASC);
ALTER TABLE `med_db`.`гв_комбо` 
ADD CONSTRAINT `ГВ_комбо_fk0`
  FOREIGN KEY (`структура1`)
  REFERENCES `med_db`.`гв_структура` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `ГВ_комбо_fk1`
  FOREIGN KEY (`структура2`)
  REFERENCES `med_db`.`гв_структура` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
SET FOREIGN_KEY_CHECKS=1; 
  
  
  SET FOREIGN_KEY_CHECKS=0; 
ALTER TABLE `med_db`.`гв_подзапись` 
ADD INDEX `ГВ_подзапись_fk0_idx` (`id_структуры` ASC);
ALTER TABLE `med_db`.`гв_подзапись` 
ADD CONSTRAINT `ГВ_подзапись_fk0`
  FOREIGN KEY (`id_структуры`)
  REFERENCES `med_db`.`гв_структура` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
SET FOREIGN_KEY_CHECKS=1; 

  SET FOREIGN_KEY_CHECKS=0; 

ALTER TABLE `med_db`.`гв_структура` 
ADD INDEX `ГВ_структура_fk0_idx` (`id_метрики` ASC);
ALTER TABLE `med_db`.`гв_структура` 
ADD CONSTRAINT `ГВ_структура_fk0`
  FOREIGN KEY (`id_метрики`)
  REFERENCES `med_db`.`метрика` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
SET FOREIGN_KEY_CHECKS=1; 



  SET FOREIGN_KEY_CHECKS=0; 

ALTER TABLE `med_db`.`глубокие_вены` 
ADD INDEX `Глубокие_вены_fk0_idx` (`подзапись1` ASC),
ADD INDEX `Глубокие_вены_fk1_idx` (`подзапись2` ASC);
ALTER TABLE `med_db`.`глубокие_вены` 
ADD CONSTRAINT `Глубокие_вены_fk0`
  FOREIGN KEY (`подзапись1`)
  REFERENCES `med_db`.`гв_подзапись` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `Глубокие_вены_fk1`
  FOREIGN KEY (`подзапись2`)
  REFERENCES `med_db`.`гв_подзапись` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
SET FOREIGN_KEY_CHECKS=1; 