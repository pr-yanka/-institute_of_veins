select * from сфс_структура;

INSERT сфс_структура
	(название1, есть_метрика, двойная_метрика, уровень_вложенности)
    VALUES ("Сафено-феморальное соустье стандартное.", false, false, 1);
    
INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("Терминальный клапан состоятельный, диаметром", true, false, 2, 2);

INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("Претерминальный клапан состоятельный, диаметром", true, false, 1, 3);
    
INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, уровень_вложенности)
    VALUES ("Приустьевой отдел БПВ имеет извитой ход.", false, false, 4);
    
INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, уровень_вложенности)
    VALUES ("Приустьевой отдел БПВ имеет извитой ход, лоцируется отдельное соустье.", false, false, 4);

INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("ПДСВ с ОБВ, состоятельное, диаметром", true, false, 1, 5);

INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("ПДСВ с ОБВ, несостоятельное, диаметром", true, false, 1, 5);

INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("ЗДСВ с ОБВ, состоятельное, диаметром", true, false, 1, 5);
    
INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("ЗДСВ с ОБВ, несостоятельное, диаметром", true, false, 1, 5);

INSERT INTO сфс_структура
	(название1, есть_метрика, двойная_метрика, id_метрики, уровень_вложенности)
    VALUES ("Претерминальный клапан несостоятельный, диаметром", true, false, 1, 3);