--DDL 

create database ObligatorioBD 
use  ObligatorioBD 
SET DATEFORMAT YMD;

--Creación de la tabla CATEGORÍA. 
Create Table Categoria(
idCategoria int  identity (1,1),
nombreCategoria Varchar(20), 
primary key (idCategoria)
);

--Creación de la tabla BeneficiosCategoria
Create Table BeneficiosCategoria(
idBeneficioCategoria int  identity(1,1), 
idCategoria int ,
detalleBeneficio varchar(255),
primary key (idBeneficioCategoria, idCategoria),
Foreign key (idCategoria) references Categoria(idCategoria)
);


--Creación de la tabla TURISTA. 

Create Table Turista(
idTurista int  identity (1,1),
nombreTurista varchar (20),
apellidoPaterno varchar(30),
apellidoMaterno varchar(30), 
fechaNacimiento DATE, 
tipoDocumento char(3),
nroDocumento int, 
correoElectronico varchar(30)  unique, 
idCategoria int ,
primary key (idTurista),
foreign key (idCategoria) references Categoria (idCategoria),
CONSTRAINT chk_mayorEdad CHECK (DATEDIFF(YEAR, fechaNacimiento, GETDATE()) >= 18)
);

--Creación de la tabla TELÉFONO 

create table Telefono(
idTurista int ,
numeroTelefono varchar(30) ,
primary key(idTurista, numeroTelefono),
foreign key (idTurista) references Turista(idTurista)
);



--Creación de la tabla REGISTRADO.
Create Table Registrado(
idRegistrado int  identity (1,1),
idTurista int , 
contrasenia varchar(30), 
primary key (idRegistrado),
foreign key (idTurista) references Turista(idTurista),
CONSTRAINT chk_contrasenaLength CHECK (LEN(contrasenia) >= 8),
)

--Creación de la tabla ACOMPAÑANTE. 

Create Table Acompañante(
idRegistrado int ,
idTurista int , 
primary key (idTurista, idRegistrado), 
foreign key (idTurista) references Turista(idTurista),
foreign key (idRegistrado) references Registrado(idRegistrado)
);

--Creación de la tabla DEPARTAMENTO
Create Table Departamento(
idDepartamento int  identity(1,1), 
nombreDepartamento varchar(20), 
primary key (idDepartamento)
);

--Creación de la tabla TERMINAL. 
Create Table Terminal(
idTerminal int  identity (1,1),
nombreTerminal varchar(40),
idDepartamento int , 
primary key (idTerminal),
foreign key (idDepartamento) references Departamento(idDepartamento)
);



--Creación de la tabla BUS.

Create Table Bus(
idBus int  identity(1,1),
capacidadBus int,
marcaBus varchar(15),
tipoBus varchar(15),
primary key (idBus),
CONSTRAINT chk_buscapacidadBus check (capacidadBus >= 10 AND capacidadBus <=40)
);

--Creación de la tabla ASIENTO.

Create Table Asiento(
idAsiento int identity(1,1),
idBus int ,
filaAsiento int,
letraAsiento varchar(1),
primary key (idBus, filaAsiento, letraAsiento),
foreign key (idBus) references Bus (idBus)
);

--Creación de la tabla DESTINO
Create Table Destino(
idDestino int  identity(1,1),
infoGeneralDestino varchar(30), 
duracionDestino Time, 
fechaYHoraSalida DateTime, 
costoDestino decimal (10, 2), 
idTerminalOrigen int ,
idTerminalDestino int ,
idBus int , 
primary key (idDestino),
foreign key (idTerminalOrigen) references Terminal(idTerminal),
foreign key (idTerminalDestino) references Terminal(idTerminal),
foreign key (idBus) references Bus(idBus),
CONSTRAINT chk_terminal_diferentes check (idTerminalOrigen != idTerminalDestino)
)



--Creación de la tabla PASAJE. 

Create Table Pasaje(
idPasaje int identity(1,1),
costoPasaje decimal, 
idBus int ,
filaAsiento int,
letraAsiento varchar(1),
fechaCompra Date DEFAULT GETDATE(),
utilizado bit default 0, 
idTerminalDestino int ,
idTurista int ,
primary key(idPasaje),
foreign key (idTerminalDestino) references Destino (idDestino),
foreign key (idTurista) references Turista (idTurista),
foreign key (idBus, filaAsiento, letraAsiento) references Asiento (idBus,filaAsiento, letraAsiento )
);

