DROP DATABASE IF EXISTS videoclub;
-- crear base de datos videclub y usarla
CREATE DATABASE videoclub;
USE videoclub;

-- crear tablas

-- ACTORES

CREATE TABLE actor(id_actor int NOT NULL PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(30),
apellido_1 VARCHAR(30),
apellido_2 VARCHAR(30),
oscar INT(2)
);

-- PELICULAS 

CREATE TABLE pelicula (id_pelicula INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
titulo VARCHAR(50),
titulo_original varchar(50),
pais varchar (30),
duracion int,
sinopsis varchar (300),
director varchar (50),
formato varchar(30),
tipo_alquiler varchar (30)

);

-- ACTUAN

CREATE TABLE actuan (id_actor int,
foreign key (id_actor) references actor (id_actor),
id_pelicula int,
foreign key (id_pelicula) references pelicula (id_pelicula)
);

-- GENEROS

CREATE TABLE genero (id_genero int NOT NULL PRIMARY KEY,
nombre VARCHAR(30) UNIQUE);

-- GENEROS TIENE

CREATE TABLE generos_pelicula (id_genero int,
foreign key (id_genero) references genero (id_genero),
id_pelicula int,
foreign key (id_pelicula) references pelicula (id_pelicula)
);

-- JUEGOS

CREATE TABLE juego (id_juego int not null primary key AUTO_INCREMENT,
titulo VARCHAR(50),
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
disponibilidad varchar(30),
estado varchar (30),
portada varchar (100),
año date,
idioma varchar (30),
cantidad int
);

-- TIPO ALQUILER

CREATE TABLE tipo_alquiler (id_tipo int not null primary key,
precio double,
duracion int,
recargo int,
nombre varchar (30)

);
-- ROLES

CREATE TABLE rol (id_rol int not null primary key,
rol varchar (30) UNIQUE
);

-- CLIENTES

CREATE TABLE usuario (id_usuario int not null primary key AUTO_INCREMENT,
nombre varchar (30),
apellido_1 varchar (30),
apellido_2 varchar (30),
direccion varchar (100),
mail varchar (30),
telefono varchar (30),
fecha_nacimiento date,
usuario varchar (30) UNIQUE,
contraseña varchar (30),

id_rol int,
FOREIGN KEY (id_rol) REFERENCES rol (id_rol)

);

-- ALQUILERES

CREATE TABLE alquiler (id_alquiler int not null primary key AUTO_INCREMENT,
id_producto int,
FOREIGN KEY (id_producto) REFERENCES producto (id_producto),
id_usuario int,
FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario),
fecha_alquiler date,
fecha_prev_devolucion date,
fecha_devolucion date,
recargo int,
devuelto boolean,
id_tipo int,
FOREIGN KEY (id_tipo) REFERENCES tipo_alquiler (id_tipo)
);

CREATE TABLE permiso (id_permiso int not null primary key auto_increment,
acciones varchar(30)
);

create table contiene_permiso (id_rol int,
foreign key (id_rol) references rol (id_rol),
id_permiso int,
foreign key (id_permiso) references permiso (id_permiso)
);

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



