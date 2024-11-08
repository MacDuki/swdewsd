USE OBLIGATORIO; 


CREATE TABLE Categoria (
	idCategoria INT PRIMARY KEY IDENTITY(1,1), -- Autoincremental
    categoriaName VARCHAR(50)
);


CREATE TABLE Beneficio (
    idBeneficio INT, 
    idCategoria INT,
    beneficio VARCHAR(255),
    PRIMARY KEY (idBeneficio, idCategoria), -- Clave primaria compuesta
    FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
);

CREATE TABLE Turista (
    idTurista INT PRIMARY KEY IDENTITY(1,1), --Autoincremental
    apellidoMaterno VARCHAR(50),
    apellidoPaterno VARCHAR(50),
    nombre VARCHAR(50),
    correoElectronico VARCHAR(100) UNIQUE,
    tipoDocumento VARCHAR(50),
    nroDocumento VARCHAR(20),
    fechaNacimiento DATE,
	idCategoria INT,
	FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
);

CREATE TABLE Registrado (
    idRegistrado INT PRIMARY KEY IDENTITY(1,1), -- Autoincremental
    idTurista INT, -- Clave foránea a Turista
	contrasenia VARCHAR(255) NOT NULL CHECK (LEN(contrasenia) >= 8), -- Contraseña para los turistas registrados
    FOREIGN KEY (idTurista) REFERENCES Turista(idTurista)
);



CREATE TABLE Acompañante (
    idTurista INT PRIMARY KEY, -- Clave foránea a Registrado
    FOREIGN KEY (idTurista) REFERENCES Turista(idTurista)
);

CREATE TABLE Telefono (
    idTelefono INT, -- Autoincremental
    idTurista INT,
    telefono VARCHAR(20),
	PRIMARY KEY (idTelefono, idTurista), -- Clave primaria compuesta
	FOREIGN KEY (idTurista) REFERENCES Turista(idTurista) -- Clave foránea a Turista
);