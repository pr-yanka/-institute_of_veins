select * from пдсв_структура;

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("ПДСВ без рефлюкса, диаметром", true, 1, 1);
    
INSERT INTO пдсв_структура
	(название1, есть_метрика,  уровень_вложенности)
    VALUES ("Имеет прямолинейный ход.", false, 2);
    
INSERT INTO пдсв_структура
	(название1, есть_метрика, уровень_вложенности)
    VALUES ("Притоки ПДСВ без рефлюкса.", false, 3);

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с рефлюксом, диаметром", true, 1, 3);
    
INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с рефлюксом и остаточными явлениями перенесенного тромбоза, диаметром", true, 1, 3);

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с признаками окклюзирующего тромбоза, диаметром", true, 1, 3);

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с признаками неокклюзирующего тромбоза, диаметром", true, 1, 3);

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с признаками частично реканализированного тромбоза, диаметром", true, 1, 3);
    
INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки ПДСВ с признаками склерооблитерации, диаметром", true, 1, 3);

INSERT INTO пдсв_структура
	(название1, есть_метрика, уровень_вложенности)
    VALUES ("Имеет извитой ход.", false, 2);

INSERT INTO пдсв_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("ПДСВ с рефлюксом, диаметро3м", true, 1, 1);
    
