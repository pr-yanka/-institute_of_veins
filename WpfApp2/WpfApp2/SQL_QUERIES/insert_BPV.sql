INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, уровень_вложенности)
    VALUES ("Без рефлюкса", false, 1);

select * from БПВ_на_бедре_структура;

INSERT INTO метрика(название) VALUES ('мм');

select * from метрика;

INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("На всём протяжении бедра, диаметром", true, 1, 2);


INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, уровень_вложенности)
    VALUES ("Притоки БПВ без рефлюкса.", false, 3);

INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("На всём протяжении бедра, диаметром", true, 1, 3);
    
INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки БПВ с рефлюксом и остаточными явлениями перенесённого тромбоза, диаметром", true, 1, 3);
    
INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки БПВ с признаками окклюзирующего тромбоза, диаметром", true, 1, 3);
    
INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки БПВ с признаками неокклюзирующего тромбоза, диаметром", true, 1, 3);
    
INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки БПВ с признаками частично реканализированного тромбоза, диаметром", true, 1, 3);

INSERT INTO БПВ_на_бедре_структура
	(название1, есть_метрика, id_метрики, уровень_вложенности)
    VALUES ("Притоки БПВ с признаками склерооблитерации, диаметром", true, 1, 3);