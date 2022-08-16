--create database tienda;
use tienda;
--Tabla categoría
create table Category(
       id int primary key identity(1,1),
       name varchar(50) not null unique,
       description varchar(256) null,
       status bit default(1)
);
--insert into categoria (nombre,descripcion) values ('Cereales','');
--select * from categoria;

--Tabla artículo
create table Product(
       id int primary key identity(1,1),
       categoryId int not null,
       code varchar(50) null,
       nameProd varchar(100) not null,
       priceSale decimal(11,2) not null,
       stock int not null,
       description varchar(256) null,
       status bit default(1),
	   isDelete bit not NULL default(0)
       CONSTRAINT FK_IDCATEGORY FOREIGN KEY (categoryId) REFERENCES Category(id)
);

--Tabla TipoDucumento
create table TypeDocument(
	id int primary key identity(1,1),
	code varchar(3),
	description varchar(50)
);

--Tabla Cliente
create table Client(
       id int primary key identity(1, 1),       
       name varchar(100) not null,
	   firstSurname varchar(100) not null,
	   secondSurname varchar(100) null,
       type_document varchar(3) not null,
       num_document varchar(20) null,
       address varchar(70) null,
       telephone varchar(20) null,
       email varchar(50) null
);



--Tabla venta
create table Sale(
       id int primary key identity(1,1),
       idClient int not null,
       dateSale datetime not null,
       taxSale decimal (4,2) not null,
       total decimal (11,2) not null,
       status varchar(20) not null,
       CONSTRAINT FK_IDCLIENT  FOREIGN KEY (idClient) REFERENCES Client (id),
       --idUser int not null,       
       --FOREIGN KEY (idUser) REFERENCES Users (id)
);

--Tabla DetailSale
create table DetailSale(
       id int primary key identity,
       idSale int not null,
       idProduct int not null,
       amount int not null,
       price decimal(11,2) not null,
       discount decimal(11,2) not null,
       CONSTRAINT FK_IDSALE FOREIGN KEY (idSale) REFERENCES Sale (id) ON DELETE CASCADE,
       CONSTRAINT FK_IDPRODUCT FOREIGN KEY (idProduct) REFERENCES Product (id)
);



----Tabla rol
--create table Rol(
--       idrol int primary key identity(1,1),
--       name varchar(30) not null,
--       description varchar(100) null,
--       status bit default(1)
--);

----Tabla usuario
--create table Users(
--       id int primary key identity(1,1),
--       idrol int not null,
--       nombre varchar(100) not null,
--       tipo_documento varchar(20) null,
--       num_documento varchar(20) null,
--       direccion varchar(70) null,
--       telefono varchar(20) null,
--       email varchar(50) not null,
--       password varbinary not null,
--       status bit default(1),
--       FOREIGN KEY (idrol) REFERENCES rol (idrol)
--);


--Tabla ingreso
--create table Entry_product(
--       id int primary key identity(1,1),
--       idProvider integer not null,
--       idUser integer not null,
--       dateAt datetime not null,
--       tax decimal (4,2) not null,
--       amount decimal (11,2) not null,
--       status varchar(20) not null,
--       FOREIGN KEY (idProvider) REFERENCES Client (id),
--       FOREIGN KEY (idUser) REFERENCES Users (id)
--);

----Tabla detalle_ingreso
--create table detalle_ingreso(
--       id int primary key identity(1,1),
--       idEntryProduc int not null,
--       idProduct int not null,
--       cantidad int not null,
--       precio decimal(11,2) not null,
--       FOREIGN KEY (idEntryProduc) REFERENCES Entry_product (id) ON DELETE CASCADE,
--       FOREIGN KEY (idProduct) REFERENCES Product (id)
--);
