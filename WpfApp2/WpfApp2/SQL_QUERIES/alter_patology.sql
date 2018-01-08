ALTER TABLE `med_db`.`патологии` 
ADD COLUMN `архивирована` TINYINT NULL AFTER `id_пациента`,
ADD COLUMN `месяц_появления` DATE NULL AFTER `архивирована`,
ADD COLUMN `год_появления` DATE NULL AFTER `месяц_появления`,
ADD COLUMN `месяц_исчезнование` DATE NULL AFTER `год_появления`;


ALTER TABLE `med_db`.`патологии` 
ADD COLUMN `год_исчезнование` DATE NULL AFTER `месяц_исчезнование`;
