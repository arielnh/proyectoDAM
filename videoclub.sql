DROP DATABASE IF EXISTS videoclub;
-- crear base de datos videclub y usarla
CREATE DATABASE videoclub;
USE videoclub;

-- CREAR TABLAS

-- ACTORES

CREATE TABLE actor(
id_actor int NOT NULL PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(30),
apellido_1 VARCHAR(30),
apellido_2 VARCHAR(30),
oscar INT(2)
);

-- PELICULAS 

CREATE TABLE pelicula (
id_pelicula INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
titulo_original varchar(50),
pais varchar (30),
duracion int,
sinopsis varchar (500),
director varchar (50),
formato varchar(30),
tipo_alquiler varchar (30)

);

-- ACTUAN

CREATE TABLE actuan (
id_actor int not null,
id_pelicula int not null,

primary key(id_actor, id_pelicula),

foreign key (id_actor) references actor (id_actor),
foreign key (id_pelicula) references pelicula (id_pelicula)
);

-- GENEROS

CREATE TABLE genero (
id_genero int NOT NULL PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(30) UNIQUE);

-- GENEROS TIENE

CREATE TABLE generos_pelicula (
id_genero int not null,
id_pelicula int not null,

primary key(id_genero, id_pelicula),

foreign key (id_genero) references genero (id_genero),
foreign key (id_pelicula) references pelicula (id_pelicula)
);

-- JUEGOS

CREATE TABLE juego (id_juego int not null primary key AUTO_INCREMENT,
plataforma varchar(30),
doblado boolean,
genero varchar (30),
distribuidora varchar (30),
desarolladora varchar (30),
multijugador boolean,
tipo_alquiler varchar (30)

);

-- PRODUCTOS

CREATE TABLE producto (id_producto int not null primary key AUTO_INCREMENT,
id_pelicula int,
FOREIGN KEY (id_pelicula) REFERENCES pelicula (id_pelicula),
id_juego int,
FOREIGN KEY (id_juego) REFERENCES juego (id_juego),
titulo VARCHAR(50),
estado varchar (30),
portada varchar (300),
año date,
idioma varchar (30)
);


-- TIPO ALQUILER

CREATE TABLE tipo_alquiler (id_tipo int not null primary key AUTO_INCREMENT,
precio double,
duracion int,
recargo double,
nombre varchar (30)

);
-- ROLES

CREATE TABLE rol (
id_rol int not null primary key AUTO_INCREMENT,
rol varchar (30) UNIQUE not null
);

-- USUARIOS

CREATE TABLE usuario (id_usuario int not null primary key AUTO_INCREMENT,
nombre varchar (30),
apellido_1 varchar (30),
apellido_2 varchar (30),
direccion varchar (100),
mail varchar (60),
telefono varchar (30),
fecha_nacimiento date,
usuario varchar (30) UNIQUE,
contraseña varchar (30),
id_rol int not null,
FOREIGN KEY (id_rol) REFERENCES rol (id_rol) 

);


-- INCIDENCIA
create table tipo_incidencia (id_tipo_inc int not null primary key auto_increment,
incidencia varchar (30)
);

create table incidencia (id_incidencia int not null primary key auto_increment,
id_usuario int,
foreign key (id_usuario) references usuario (id_usuario),
asunto varchar (30),
descripcion varchar (300),
id_tipo_inc int,
foreign key (id_tipo_inc) references tipo_incidencia (id_tipo_inc)
);

-- ITEMS
CREATE TABLE item (
id_item int not null primary key AUTO_INCREMENT,
id_producto int,
FOREIGN KEY (id_producto) REFERENCES producto (id_producto) ON DELETE CASCADE,
disponibilidad varchar(30),
ubicacion varchar (100),
numero int,
id_incidencia int,
FOREIGN KEY (id_incidencia) REFERENCES incidencia (id_incidencia)

);

-- ALQUILERES

CREATE TABLE alquiler (id_alquiler int not null primary key AUTO_INCREMENT,
id_item int,
FOREIGN KEY (id_item) REFERENCES item (id_item) ON DELETE CASCADE,
id_usuario int,
FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario) ON DELETE CASCADE,
fecha_alquiler date,
fecha_prev_devolucion date,
fecha_devolucion date,
recargo int,
devuelto boolean,
id_tipo int,
FOREIGN KEY (id_tipo) REFERENCES tipo_alquiler (id_tipo)
);

-- PERMISOS
CREATE TABLE permiso (
id_permiso int not null primary key auto_increment,
acciones varchar(30)
);

create table contiene_permiso (
id_rol int,
foreign key (id_rol) references rol (id_rol),
id_permiso int,
foreign key (id_permiso) references permiso (id_permiso),
primary key (id_rol, id_permiso)
);








-- INSERTAR DATOS

-- ROL 
INSERT INTO `videoclub`.`rol` (`rol`) VALUES ('Administrador');
INSERT INTO `videoclub`.`rol` (`rol`) VALUES ('Dependiente');
INSERT INTO `videoclub`.`rol` (`rol`) VALUES ('Cliente');
INSERT INTO `videoclub`.`rol` (`rol`) VALUES ('Usuario Público');

-- PERMISOS
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Gestionar Productos');
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Alquileres y Devoluciones');
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Consultar Disponibilidad');
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Reservar');
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Añadir Clientes');
INSERT INTO `videoclub`.`permiso` (`acciones`) VALUES ('Añadir Dependientes');

-- PERMISOS ADMINISTRADOR
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,1);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,2);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,3);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,4);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,5);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (1,6);

-- PERMISOS DEPENDIENTE
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (2,1);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (2,2);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (2,3);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (2,4);

-- PERMISO CLIENTE
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (3,3);
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (3,4);

-- PERMISO USUARIO PÚBLICO
INSERT INTO videoclub.contiene_permiso (id_rol, id_permiso) VALUES (4,3);

-- ADMIN Y USERS

INSERT INTO `videoclub`.`usuario` (nombre,`usuario`, `contraseña`, id_rol) VALUES ('Ariel','admin', 'admin', 1);
INSERT INTO `videoclub`.`usuario` (nombre, apellido_1,`usuario`, `contraseña`, id_rol) VALUES ('Pepe','Perez', 'pepe', 'pepe', 2);
INSERT INTO `videoclub`.`usuario` (nombre, apellido_1,`usuario`, `contraseña`, id_rol) VALUES ('Marta','Perez', 'marta', 'marta', 3);
INSERT INTO `videoclub`.`usuario` (nombre,`usuario`, `contraseña`, id_rol) VALUES ('Publico','public', '0000', 4);

-- USUARIOS GENERADOS AUTO

INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Cinthia','Moniz','Race', '8593 Eastleigh Circle , Whitehill, Suffolk, EH4 7NE','elainalew330@yahoo.com','+32-7488-802-424','1991-08-22','ZUEKQ','hotmail',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Dorthey','Dempsey','Noland', '6196 Back Avenue , Beltchingley, Dundee City, ST6 0LR','lashawnaburke09692@yahoo.com','+354-6122-146-135','1997-06-29','OOWKZ','jamaica',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Florrie','Parra','Whaley', '7741 Violet Avenue , Birchwood, Oxfordshire, CT1 8WK','shona.billiot@yahoo.com','+94-6819-627-270','1989-06-16','QSHIQ','boston',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Twanda','Segal','Barth', '7572 Joan Avenue , Grassington, Monmouthshire, NW63 8MS','clelia73488@broken.com','+57-2344-637-438','2015-05-23','TGBBY','fireball',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Graham','Hatley','Mcnamee', '6196 Cornbrook Street , Stanhope, Greater Manchester, ME62 4NX','renato_mcconnell@yahoo.com','+41-1390-349-758','1972-02-03','NLCTQ','111111',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Tanna','Dexter','Mejia', '6300 Capital Avenue , Wareham, Renfrewshire, DE1 7JO','era_negron@yahoo.com','+679-0060-601-657','1988-01-13','MNYKZ','business',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Ayako','Clem','Barr', '1681 Findlay , Bollington, East Sussex, NP7 2CN','major28799@yahoo.com','+234-3624-307-167','1977-08-29','IIYYN','loveme',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Tasia','Quinonez','Upchurch', '4895 Daventry Circle , West Malling, Aberdeen City, HU9 9PP','marisha6998@hotmail.com','+40-5339-134-350','1970-03-20','NPORO','zxcvbn',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Laine','Durr','Condon', '0821 Lindop Circle , Beccles, Aberdeen City, HU93 6GM','dwain.brock222@seasons.com','+237-0766-662-025','2007-02-14','FGGPL','tomcat',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Twana','Baron','Billingsley', '8196 Conran , Bromyard, Aberdeen City, LD2 7EU','carolinaclark@nervous.com','+31-0652-103-211','1974-09-07','SOIHY','poohbear',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Sarah','Dias','Reno', '1598 Law , Penryn, Highland, TW31 0BO','gabriel40@hotmail.com','+43-5719-206-464','2022-01-22','VKALN','butter',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Sabine','Weston','Buckingham', '3697 Rushside Circle , Faversham, West Dunbartonshire, SR58 4AO','kimi491@night.com','+509-5260-308-584','2013-06-22','SLGIH','friends',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Shavonda','Taber','Ruff', '8374 Whit Avenue , Lutterworth, Aberdeenshire, HG9 7VR','hank-herring@hotmail.com','+66-6194-179-315','1977-12-25','EHMTD','martin',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Damien','Mclain','Gunter', '2230 Shropshire Street , Newark on Trent, West Midlands, SY23 4KI','noma9@hotmail.com','+852-3796-781-004','1973-12-05','ELVTS','bond007',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Rae','Bello','Bourgeois', '4936 Rounthorn , Frinton on Sea, Armagh, CM8 5FT','jacquie274@gmail.com','+61-2603-728-949','1981-06-22','YINJN','chicken',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Eulalia','Wirth-Danielson','Leach', '4061 Old Circle , Deganwy, Falkirk, AB79 1UG','princess-krebs@hotmail.com','+684-6707-682-396','1994-05-31','AHWLN','juventus',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Nella','Henke','Horvath-Bean', '3696 Albermarle , Bridge of Tilt, Cornwall, TQ16 7YB','werner-lohr4779@hotmail.com','+221-8878-690-834','1998-02-09','JGOHZ','terminator',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Prudence','Cockrell','Bechtel', '1332 Rushfield Lane , Bridge of Tilt, Gloucestershire, BH88 8BL','aileen.higgins49@hotmail.com','+689-3376-995-466','1970-01-07','FESKH','victor',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Luvenia','Weldon','Thomas-Chaffin', '1074 Cowlishaw Lane , Wood Green, North Yorkshire, NN2 2EY','teisha-keller@yahoo.com','+61-7526-796-150','2007-11-21','KYDQL','camille',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Camille','Covert','Dietrich', '8328 Southsea Avenue , Brandon, Leicestershire, HX58 3JN','leandra-ernst@yahoo.com','+251-3701-997-576','2016-05-11','NBRLC','ireland',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Angel','Begay','Trujillo', '1544 Kilmory Road , Eckington, Devon, RG52 4PE','claudine868@yahoo.com','+48-4221-051-617','1996-12-21','GNXVP','pakistan',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Kalyn','Downey','Sewell', '3344 Eve Circle , Midhurst, Merionethshire, LD6 4FO','antionewilliam@gmail.com','+225-9787-575-110','1987-08-11','XBCKF','mike',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Jeff','Grisham','Thompson', '6266 New Circle , Kirkwall, West Sussex, WC70 7RD','adaline1251@ea.com','+41-5762-152-889','2001-10-06','HLOTI','donkey',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Sheryll','Wicks','Larose', '3411 Brancaster Road , Llanrwst, Wiltshire, BD18 5WR','gertie224@yahoo.com','+213-9008-262-564','2022-11-02','IYEXX','snoopy',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Katharina','Hatton','Bedard', '4907 Hallwood Street , Crieff, Armagh, BD8 8YR','sharilyn_mulligan@water.net.za','+260-5730-749-760','1986-03-21','WLKGU','mother',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Lucinda','Voigt','Esquivel', '8987 Zulu Street , Brackley, Clackmannanshire, TW77 7UB','jacquelinkey953@yahoo.com','+596-1395-754-079','1975-03-20','ZOTBW','147258',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Vernita','Spriggs','Haller', '8642 Rathmel , Porthleven, Leicestershire, WF1 5JG','katia.stallings@hotmail.com','+47-7633-119-130','1983-12-21','HABYD','galaxy',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Salina','Bush','Connor', '8992 Sheath , Howdon, Buckinghamshire, HD93 1MY','cherishwalton@yahoo.com','+509-2119-976-517','1972-10-14','DKXCO','blahblah',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Mindy','Flood','Brogan', '4450 Back Road , Kirkham, Surrey, NN81 3XS','shawna191@gmail.com','+47-7337-301-293','1972-05-20','YUOGR','shelby',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Emile','Landry','Rosas', '0192 Sportsmans , Poulton le Fylde, Highland, HP7 1HI','enda9@the.com','+57-2321-338-440','2000-04-16','BSREX','kawasaki',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Exie','Lowell','Lyles', '2958 Menai , Kettering, Flintshire, IG8 7LN','renitatracey04@vhs.com','+44-2404-214-428','1985-07-13','RNVYJ','drowssap',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Hermila','Oneal','Hester', '7667 Coldalhurst , North Walsham, Perth and Kinross, SM18 7DB','leanora17329@chi.com','+358-5823-115-296','2020-10-29','GTBBX','black',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Tyisha','High','Hutton', '3240 Bowler Street , Wilton, Kent, SE51 6KV','nellie1680@gmail.com','+506-1138-162-021','1981-04-28','EZPTB','potter',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Frederica','Thorn','Krauss', '9521 Back Lane , Lechlade, Midlothian, OX8 8BU','lyle_smart@hotmail.com','+39-7909-327-352','2001-08-02','MXINM','julian',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Jody','Swartz','Monson', '3168 Lees Lane , Peebles, Cleveland, SA38 1FY','jacqulyn_salgado6318@gmail.com','+965-3257-157-806','1987-10-12','QMPOF','hammer',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Romana','Ayres','Turner', '7874 Elmhurst Street , Sandwich, North Yorkshire, TR6 2GR','akilah.damico@copying.com','+33-0242-347-340','1997-03-16','QBDUR','marcus',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Pearlie','Spurgeon','Neville', '6446 Farndon Street , Laugharne, Cardiganshire, HA3 4IX','tyrelloswald@drawn.marnardal.no','+509-3874-887-374','2019-03-21','TDLVE','123qwe',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Isaura','Gustafson','Conner', '6703 Erica Street , Westbury, Flintshire, B7 2UB','camie486@yahoo.com','+38-2665-833-161','1977-07-05','VFRRJ','thomas',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Melissia','Collier','Mattox', '3457 Minshull Lane , Buxton, Fermanagh, KW04 9BD','fleta4@approximately.com','+501-7307-979-962','1992-07-08','MXFRB','happy',3);
INSERT INTO videoclub.usuario (nombre, apellido_1, apellido_2, direccion, mail, telefono, fecha_nacimiento, usuario,contraseña,id_rol)
VALUES ('Julianne','Needham','Coffey', '9182 Dacre Road , Donaghadee, Falkirk, PL43 1GQ','therese.slade23323@looks.com','+82-8395-270-531','1989-07-05','CQIHH','willow',3);

-- //////////////////// --
-- DATOS PELICULAS Y JUEGOS
-- //////////////////// --

-- ACTOR
	
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Ryan', 'Gosling', '', 0);
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Emma', 'Stone', '', 0);
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Russell', 'Crowe', '', 1); 
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Rachel', 'McAdams', '', 0);
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Harrison', 'Ford', '', 0);
INSERT INTO videoclub.actor (nombre, apellido_1, apellido_2, oscar) VALUES ('Claire', 'Foy', '', 0);

-- Generos
INSERT INTO videoclub.genero (nombre) VALUES ('Neo-noir');
INSERT INTO videoclub.genero (nombre) VALUES ('Ciencia-ficción');
INSERT INTO videoclub.genero (nombre) VALUES ('Musical');
INSERT INTO videoclub.genero (nombre) VALUES ('Comedia');
INSERT INTO videoclub.genero (nombre) VALUES ('Drama');
INSERT INTO videoclub.genero (nombre) VALUES ('Crimen');
INSERT INTO videoclub.genero (nombre) VALUES ('Acción');
INSERT INTO videoclub.genero (nombre) VALUES ('Romance');
INSERT INTO videoclub.genero (nombre) VALUES ('Historia');

-- PELICULAS Y PRODUCTO
INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
'Blade Runner 2049', 'Estados Unidos', '163', 'Ubicada treinta años después de la película original. La historia describe a un blade runner replicante llamado K descubriendo los restos de una mujer replicante que en algún momento del pasado estuvo embarazada, lo cual es aparentemente imposible. Para evitar una posible guerra entre humanos y replicantes, K se encarga secretamente de encontrar al niño y destruir toda evidencia relacionada con él.', 'Denis Villeneuve', 'Blu-Ray');
 
 INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
'La La Land', 'Estados Unidos', '128', 'La película cuenta la historia de Mia, una empleada de un bar que aspira a ser actriz y Sebastian, un pianista de jazz desempleado con grandes ambiciones. A pesar de sus diferencias y sus distintas personalidades, gracias a una serie de acontecimientos harán que sus caminos acaben cruzándose.', 'Damien Chazelle', 'Blu-Ray');
 
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '1', 'Blade Runner 2049', 'Disponible', '2017-10-03 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w188_and_h282_bestv2/cOt8SQwrxpoTv9Bc3kyce3etkZX.jpg');
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '2', 'La ciudad de las estrellas:
La La Land', 'Disponible', '2016-09-02 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w188_and_h282_bestv2/7pFsAaJmiOppVHcldBzg8JKBHwe.jpg');
 
 INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
 'Drive', 'Estados Unidos', '100', 'Durante el día, Driver es conductor especialista de cine, pero de noche se convierte en chófer para delincuentes. El mundo de Driver cambia el día en que conoce a Irene, una vecina que tiene un hijo pequeño y a su marido en la cárcel.', 'Nicolas Winding Refn','Blue-Ray'
 );
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '3', 'Drive','Disponible', '2011-09-01 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/uC6ykM4OcOaxS7mLMdF7eebdk1Z.jpg'
 );
 
  INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
 'The Nice Guys', 'Estados Unidos', '116', 'Ambientada en Los Ángeles durante los años 70. El detective Holland March y el matón a sueldo Jackson Healy se ven obligados a colaborar para resolver varios casos: la desaparición de una joven, la muerte de una estrella porno y una conspiración criminal que llega hasta las altas esferas.',
 'Shane Black','Blue-Ray'
 );
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '4', 'Dos Buenos Tipos','Disponible', '2016-06-10 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w1280/kgMpKQMKyS7oYmPffKyyOv0VqyT.jpg'
 );
 
 INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
 'The Notebook', 'Estados Unidos', '124', 'Cuenta la vida en los años 40 de dos jóvenes adolescentes de Carolina del Norte que, a pesar de vivir en dos ambientes sociales muy diferentes, pasaron un verano idílico juntos y profundamente enamorados, antes de ser separados, primero por sus padres, y más tarde por la Segunda Guerra Mundial.',
 'Nick Cassavetes','Blue-Ray'
 );
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '5', 'El diario de Noa','Disponible', '2004-06-25 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w1280/tpYGO4BC1EGy5strj15xy1vB3jP.jpg'
 );
 
 INSERT INTO `videoclub`.`pelicula` (`titulo_original`, `pais`, `duracion`, `sinopsis`, `director`, `formato`) VALUES (
 'First Man', 'Estados Unidos', '141', 'Cuenta la historia de la misión de la NASA que llevó al primer hombre a la luna, centrada en Neil Armstrong y el periodo comprendido entre los años 1961 y 1969. Un relato en primera persona, basado en la novela de James R. Hansen',
 'Damien Chazelle','Blue-Ray'
 );
 INSERT INTO `videoclub`.`producto` (`id_pelicula`, `titulo`, `estado`, `año`, `idioma`, portada) VALUES (
 '6', 'First Man','Disponible', '2018-10-11 12:00:00', 'Español', 'https://www.themoviedb.org/t/p/w1280/hLXDrsgBqdO0xJHoRlBBMMortWL.jpg'
 );
 
-- Añadir genero a la película
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (1,1);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (1,2);

INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (2,3);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (2,4);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (2,5);

INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (3,1);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (3,5);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (3,6);

INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (4,4);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (4,6);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (4,7);

INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (5,5);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (5,8);

INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (6,1);
INSERT INTO videoclub.generos_pelicula (id_pelicula, id_genero) VALUES (6,5);
 
-- Añadir ACTOR a la PELÍCULA
 
insert into videoclub.actuan(id_actor, id_pelicula) values (1,1);
insert into videoclub.actuan(id_actor, id_pelicula) values (5,1);

insert into videoclub.actuan(id_actor, id_pelicula) values (1,2);
insert into videoclub.actuan(id_actor, id_pelicula) values (2,2);

insert into videoclub.actuan(id_actor, id_pelicula) values (1,3);

insert into videoclub.actuan(id_actor, id_pelicula) values (1,4);
insert into videoclub.actuan(id_actor, id_pelicula) values (3,4);

insert into videoclub.actuan(id_actor, id_pelicula) values (1,5);
insert into videoclub.actuan(id_actor, id_pelicula) values (4,5);

insert into videoclub.actuan(id_actor, id_pelicula) values (1,6);
insert into videoclub.actuan(id_actor, id_pelicula) values (6,6);
 
 -- ////////////////////--
		-- JUEGO
-- ////////////////////--
 INSERT INTO videoclub.juego (plataforma, doblado, genero, distribuidora, desarolladora, multijugador) 
 VALUES ('Play Station 5', true, 'rol', 'Neowiz', 'Round 8 Studio', false); 
    
INSERT INTO videoclub.producto (id_juego, titulo, portada,año)
VALUES (1,'Lies of P', 'https://i.ibb.co/3vCtnbf/l.png', '2024-01-01');

 INSERT INTO videoclub.juego (plataforma, doblado, genero, distribuidora, desarolladora, multijugador) 
 VALUES ('Play Station 5', true, 'rol', 'Larian Studios NV', 'Larian Studios NV', true); 
    
INSERT INTO videoclub.producto (id_juego, titulo, portada, año)
VALUES (2,'Baldurs Gate III', 'https://slug.vercel.app/s/j', '2024-02-02');

 -- Alquiler de productos MUESTRA
 
 -- ITEM
  -- reservados / alquilados
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (1, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (1, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (1, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (1, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (2, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (2, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (3, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (4, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (5, 'Estantería', 1, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (6, 'Estantería', 1, 'Alquilado');
	
    -- disponibles
    
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (1, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (2, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (3, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (4, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (5, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero, disponibilidad) values (6, 'Estantería', 2, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (7, 'Estantería', 3, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (7, 'Estantería', 3, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (7, 'Estantería', 3, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (8, 'Estantería', 3, 'Disponible');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (8, 'Estantería', 3, 'Alquilado');
 insert into videoclub.item (id_producto, ubicacion, numero,disponibilidad) values (8, 'Estantería', 3, 'Alquilado');
 
 
 -- ALQUILER
 -- tipo alquiler
 insert into videoclub.tipo_alquiler (precio, duracion, recargo,nombre) values (3,3,1,'Alquiler ordinario');
 
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (1,4,1, '2024-01-10', '2024-01-13','2024-01-13',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (2,5,1, '2024-01-11', '2024-01-14','2024-01-14',1);
insert into videoclub.alquiler (id_item, id_usuario,devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (3,6,1, '2024-01-12', '2024-01-15','2024-01-15',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (4,7,1, '2024-01-13', '2024-01-16','2024-01-16',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (5,8,1, '2024-01-14', '2024-01-17','2024-01-17',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (6,9,1, '2024-01-15', '2024-01-18','2024-01-18',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (7,10,1, '2024-01-16', '2024-01-19','2024-01-19',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, fecha_devolucion, id_tipo) values (8,11,1, '2024-01-17', '2024-01-20','2024-01-20',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, id_tipo) values (9,12,0, '2024-02-06', '2024-02-09',1);
insert into videoclub.alquiler (id_item, id_usuario, devuelto, fecha_alquiler, fecha_prev_devolucion, id_tipo) values (10,13,0, '2024-03-08', '2024-03-10',1);

 




