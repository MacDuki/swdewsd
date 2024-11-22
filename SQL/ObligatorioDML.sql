--DML 

use ObligatorioBD1

--Inserción de datos en la tabla CATEGORÍA. 

INSERT INTO Categoria (nombreCategoria) VALUES 
('Niño'), 
('Estudiante'), 
('Corporativo'), 
('Mercosur'), 
('UE'), 
('EEUU'), 
('Mascotas');


--Inserción de datos en la tabla BeneficiosCategoría

-- Tabla BeneficiosCategoria
INSERT INTO BeneficiosCategoria (idCategoria, detalleBeneficio) VALUES 
(1, 'Acceso a WiFi gratis'),
(2, 'Bebidas de cortesía'),
(3, 'Salón VIP en terminales'),
(4, 'Descuento en compra'),
(5, 'Guía en idiomas varios'),
(6, 'Comida incluida'),
(7, 'Áreas especiales para mascotas');



--Inserción de datos en la tabla TURISTA. 

-- Tabla Turista
INSERT INTO Turista (nombreTurista, apellidoPaterno, apellidoMaterno, fechaNacimiento, tipoDocumento, nroDocumento, correoElectronico, idCategoria) VALUES 
('Juan', 'Pérez', 'Gómez', '1985-03-15', 'CI', 12345678, 'juan.perez@example.com', 1),
('Ana', 'López', 'Martínez', '1990-07-21', 'DNI', 87654321, 'ana.lopez@example.com', 2),
('Carlos', 'Sánchez', 'Hernández', '1982-11-30', 'CI', 11223344, 'carlos.sanchez@example.com', 3),
('María', 'García', 'Ramírez', '1993-02-14', 'CI', 12312312, 'maria.garcia@example.com', 4),
('Pedro', 'Fernández', 'López', '1988-06-09', 'DNI', 45645645, 'pedro.fernandez@example.com', 5),
('Lucía', 'Hernández', 'Díaz', '1995-08-22', 'PAS', 78978978, 'lucia.hernandez@example.com', 6),
('Miguel', 'González', 'Soto', '1987-05-30', 'DNI', 10101010, 'miguel.gonzalez@example.com', 2),
('Carla', 'Jiménez', 'Mora', '1992-12-18', 'CI', 20202020, 'carla.jimenez@example.com', 3),
('Andrés', 'Ruiz', 'Castillo', '1986-10-04', 'DNI', 30303030, 'andres.ruiz@example.com', 1),
('Sofía', 'Martínez', 'Peña', '1994-01-11', 'PAS', 40404040, 'sofia.martinez@example.com', 7),
('Carlos', 'Gómez', 'Martínez', '1981-09-29', 'DNI', 67283940, 'carlos.gomez@example.com', 1),
('Lucía', 'Fernández', 'Pérez', '1996-04-16', 'CI', 38492048, 'lucia.fernandez@example.com', 2),
('Juan', 'Hernández', 'Ramírez', '1990-07-04', 'PAS', 94028394, 'juan.hernandez@example.com', 3),
('Sofía', 'Sánchez', 'González', '1992-02-20', 'CI', 28374628, 'sofia.sanchez@example.com', 4),
('Pedro', 'Martínez', 'López', '1989-12-05', 'DNI', 55728391, 'pedro.martinez@example.com', 5),
('Ana', 'Ruiz', 'Castillo', '1994-03-27', 'PAS', 17263947, 'ana.ruiz@example.com', 6),
('Miguel', 'Jiménez', 'Mora', '1983-09-10', 'DNI', 61837462, 'miguel.jimenez@example.com', 7),
('Gervasio', 'Suarez', 'Ramirez', '1993-09-10', 'DNI', 50708853, 'soyturista@gmail.com' , 7);




--Inserción de datos en la tabla TELÉFONO. 

-- Tabla Telefono
INSERT INTO Telefono (idTurista, numeroTelefono) VALUES 
(1, '555-1234'),
(2, '555-5678'),
(3, '555-9876'),
(4, '555-1122'),
(4, '555-3345'),
(5, '555-5567'),
(6, '555-7789'),
(7, '555-9901'),
(8, '555-1236'),
(8, '555-1237'),
(9, '555-1123'),
(10, '555-3346'),
(11, '555-5568'),
(12, '555-7790'),
(13, '555-9902'),
(14, '555-1238'),
(14, '555-1124'),
(14, '555-3347'),
(15, '555-5569'),
(16, '555-7791'),
(17, '555-9903'),
(17, '555-5680');


--Inserción de datos en la tabla REGISTRADO 
-- Tabla Registrado
INSERT INTO Registrado (idTurista, contrasenia) VALUES 
(1, 'password123'),
(2, 'securePass1'),
(3, 'lucia2023'),
(4, 'miguelSecure'),
(5, 'carlaP@ss'),
(6, 'ruiz!234'),
(7,'sofiaPeña'),
(8, 'mariaG123'),
(9, 'password123'),
(10, 'securePass1'),
(11, 'lucia2023'),
(12, 'miguelSecure'),
(13, 'carlaP@ss');




--Inserción de datos en la tabla ACOMPAÑANTE. 
---- Tabla Acompañante
INSERT INTO Acompañante (idTurista, idRegistrado) VALUES 
(14, 1),
(15, 4),
(16, 6),
(17, 13);


--Inserción de datos en la tabla Departamento 

-- Tabla Departamento
INSERT INTO Departamento (nombreDepartamento) VALUES 
('Tacuarembó'), 
('Maldonado'), 
('Punta del Este'), 
('Montevideo'), 
('Colonia'), 
('Paysandu'), 
('Cerro largo');


--Inserción de datos en la tabla TERMINAL 

-- Tabla Terminal
INSERT INTO Terminal (nombreTerminal, idDepartamento) VALUES 
('Carlos Gardel', 4),
('Cerro Enemigo', 5),
('Capitalina', 6),
('Valle Grande', 7),
('Colonial', 1),
('Punta Gorda', 2),
('Cerro Amigo', 3);



-- Tabla Bus
INSERT INTO Bus (capacidadBus, marcaBus, tipoBus) VALUES 
(30, 'Mercedes', 'Económico'), 
(40, 'Volvo', 'Premium'), 
(30, 'Scania', 'VIP'),
(20, 'Iveco', 'Económico'), 
(40, 'MAN', 'Premium'), 
(40, 'Setra', 'VIP'), 
(20, 'King Long', 'Corporativo'), 
(20, 'Irizar', 'Turístico'), 
(35, 'Marcopolo', 'Senior'), 
(30, 'Neoplan', 'Niños');



--Inserción de datos dentro de la tabla ASIENTO
-- Bus 1
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(1, 1, 'A'), (1, 1, 'B'), (1, 1, 'C'), (1, 1, 'D'),
(1, 2, 'A'), (1, 2, 'B'), (1, 2, 'C'), (1, 2, 'D'),
(1, 3, 'A'), (1, 3, 'B'), (1, 3, 'C'), (1, 3, 'D'),
(1, 4, 'A'), (1, 4, 'B'), (1, 4, 'C'), (1, 4, 'D'),
(1, 5, 'A'), (1, 5, 'B'), (1, 5, 'C'), (1, 5, 'D'),
(1, 6, 'A'), (1, 6, 'B'), (1, 6, 'C'), (1, 6, 'D'),
(1, 7, 'A'), (1, 7, 'B'), (1, 7, 'C'), (1, 7, 'D'),
(1, 8, 'A'), (1, 8, 'B'), (1, 8, 'C'), (1, 8, 'D');


-- Bus 2 (40 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(2, 1, 'A'), (2, 1, 'B'), (2, 1, 'C'), (2, 1, 'D'),
(2, 2, 'A'), (2, 2, 'B'), (2, 2, 'C'), (2, 2, 'D'),
(2, 3, 'A'), (2, 3, 'B'), (2, 3, 'C'), (2, 3, 'D'),
(2, 4, 'A'), (2, 4, 'B'), (2, 4, 'C'), (2, 4, 'D'),
(2, 5, 'A'), (2, 5, 'B'), (2, 5, 'C'), (2, 5, 'D'),
(2, 6, 'A'), (2, 6, 'B'), (2, 6, 'C'), (2, 6, 'D'),
(2, 7, 'A'), (2, 7, 'B'), (2, 7, 'C'), (2, 7, 'D'),
(2, 8, 'A'), (2, 8, 'B'), (2, 8, 'C'), (2, 8, 'D'),
(2, 9, 'A'), (2, 9, 'B'), (2, 9, 'C'), (2, 9, 'D'),
(2, 10, 'A'), (2, 10, 'B'), (2, 10, 'C'), (2, 10, 'D');

-- Bus 3 (30 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(3, 1, 'A'), (3, 1, 'B'), (3, 1, 'C'), (3, 1, 'D'),
(3, 2, 'A'), (3, 2, 'B'), (3, 2, 'C'), (3, 2, 'D'),
(3, 3, 'A'), (3, 3, 'B'), (3, 3, 'C'), (3, 3, 'D'),
(3, 4, 'A'), (3, 4, 'B'), (3, 4, 'C'), (3, 4, 'D'),
(3, 5, 'A'), (3, 5, 'B'), (3, 5, 'C'), (3, 5, 'D'),
(3, 6, 'A'), (3, 6, 'B'), (3, 6, 'C'), (3, 6, 'D'),
(3, 7, 'A'), (3, 7, 'B'), (3, 7, 'C'), (3, 7, 'D'),
(3, 8, 'A'), (3, 8, 'B'), (3, 8, 'C'), (3, 8, 'D'),
(3, 9, 'A'), (3, 9, 'B');

-- Bus 4 (20 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(4, 1, 'A'), (4, 1, 'B'), (4, 1, 'C'), (4, 1, 'D'),
(4, 2, 'A'), (4, 2, 'B'), (4, 2, 'C'), (4, 2, 'D'),
(4, 3, 'A'), (4, 3, 'B'), (4, 3, 'C'), (4, 3, 'D'),
(4, 4, 'A'), (4, 4, 'B'), (4, 4, 'C'), (4, 4, 'D'),
(4, 5, 'A'), (4, 5, 'B'), (4, 5, 'C'), (4, 5, 'D');

-- Bus 5 (40 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(5, 1, 'A'), (5, 1, 'B'), (5, 1, 'C'), (5, 1, 'D'),
(5, 2, 'A'), (5, 2, 'B'), (5, 2, 'C'), (5, 2, 'D'),
(5, 3, 'A'), (5, 3, 'B'), (5, 3, 'C'), (5, 3, 'D'),
(5, 4, 'A'), (5, 4, 'B'), (5, 4, 'C'), (5, 4, 'D'),
(5, 5, 'A'), (5, 5, 'B'), (5, 5, 'C'), (5, 5, 'D'),
(5, 6, 'A'), (5, 6, 'B'), (5, 6, 'C'), (5, 6, 'D'),
(5, 7, 'A'), (5, 7, 'B'), (5, 7, 'C'), (5, 7, 'D'),
(5, 8, 'A'), (5, 8, 'B'), (5, 8, 'C'), (5, 8, 'D'),
(5, 9, 'A'), (5, 9, 'B'), (5, 9, 'C'), (5, 9, 'D'),
(5, 10, 'A'), (5, 10, 'B'), (5, 10, 'C'), (5, 10, 'D');

-- Bus 6 (40 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(6, 1, 'A'), (6, 1, 'B'), (6, 1, 'C'), (6, 1, 'D'),
(6, 2, 'A'), (6, 2, 'B'), (6, 2, 'C'), (6, 2, 'D'),
(6, 3, 'A'), (6, 3, 'B'), (6, 3, 'C'), (6, 3, 'D'),
(6, 4, 'A'), (6, 4, 'B'), (6, 4, 'C'), (6, 4, 'D'),
(6, 5, 'A'), (6, 5, 'B'), (6, 5, 'C'), (6, 5, 'D'),
(6, 6, 'A'), (6, 6, 'B'), (6, 6, 'C'), (6, 6, 'D'),
(6, 7, 'A'), (6, 7, 'B'), (6, 7, 'C'), (6, 7, 'D'),
(6, 8, 'A'), (6, 8, 'B'), (6, 8, 'C'), (6, 8, 'D'),
(6, 9, 'A'), (6, 9, 'B'), (6, 9, 'C'), (6, 9, 'D'),
(6, 10, 'A'), (6, 10, 'B'), (6, 10, 'C'), (6, 10, 'D');

-- Bus 7 (20 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(7, 1, 'A'), (7, 1, 'B'), (7, 1, 'C'), (7, 1, 'D'),
(7, 2, 'A'), (7, 2, 'B'), (7, 2, 'C'), (7, 2, 'D'),
(7, 3, 'A'), (7, 3, 'B'), (7, 3, 'C'), (7, 3, 'D'),
(7, 4, 'A'), (7, 4, 'B'), (7, 4, 'C'), (7, 4, 'D'),
(7, 5, 'A'), (7, 5, 'B'), (7, 5, 'C'), (7, 5, 'D');

-- Bus 8 (20 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(8, 1, 'A'), (8, 1, 'B'), (8, 1, 'C'), (8, 1, 'D'),
(8, 2, 'A'), (8, 2, 'B'), (8, 2, 'C'), (8, 2, 'D'),
(8, 3, 'A'), (8, 3, 'B'), (8, 3, 'C'), (8, 3, 'D'),
(8, 4, 'A'), (8, 4, 'B'), (8, 4, 'C'), (8, 4, 'D'),
(8, 5, 'A'), (8, 5, 'B'), (8, 5, 'C'), (8, 5, 'D');

-- Bus 9 (35 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(9, 1, 'A'), (9, 1, 'B'), (9, 1, 'C'), (9, 1, 'D'),
(9, 2, 'A'), (9, 2, 'B'), (9, 2, 'C'), (9, 2, 'D'),
(9, 3, 'A'), (9, 3, 'B'), (9, 3, 'C'), (9, 3, 'D'),
(9, 4, 'A'), (9, 4, 'B'), (9, 4, 'C'), (9, 4, 'D'),
(9, 5, 'A'), (9, 5, 'B'), (9, 5, 'C'), (9, 5, 'D'),
(9, 6, 'A'), (9, 6, 'B'), (9, 6, 'C'), (9, 6, 'D'),
(9, 7, 'A'), (9, 7, 'B'), (9, 7, 'C'), (9, 7, 'D'),
(9, 8, 'A'), (9, 8, 'B'), (9, 8, 'C'), (9, 8, 'D'),
(9, 9, 'A'), (9, 9, 'B'), (9, 9, 'C');

-- Bus 10 (30 asientos)
INSERT INTO Asiento (idBus, filaAsiento, letraAsiento) VALUES
(10, 1, 'A'), (10, 1, 'B'), (10, 1, 'C'), (10, 1, 'D'),
(10, 2, 'A'), (10, 2, 'B'), (10, 2, 'C'), (10, 2, 'D'),
(10, 3, 'A'), (10, 3, 'B'), (10, 3, 'C'), (10, 3, 'D'),
(10, 4, 'A'), (10, 4, 'B'), (10, 4, 'C'), (10, 4, 'D'),
(10, 5, 'A'), (10, 5, 'B'), (10, 5, 'C'), (10, 5, 'D'),
(10, 6, 'A'), (10, 6, 'B'), (10, 6, 'C'), (10, 6, 'D'),
(10, 7, 'A'), (10, 7, 'B'), (10, 7, 'C'), (10, 7, 'D'),
(10, 8, 'A'), (10, 8, 'B'), (10, 8, 'C');



--Inserción de datos en la tabla Destino 
-- Tabla Destino
INSERT INTO Destino (infoGeneralDestino, duracionDestino, fechaYHoraSalida, costoDestino, idTerminalOrigen, idTerminalDestino, idBus) VALUES
('Viaje a la playa', '02:30:00', '2024-12-01 08:00:00', 45.50, 1, 2, 1),
('Viaje a la montaña', '03:45:00', '2024-12-02 09:30:00', 60.00, 2, 3, 2),
('Viaje a la ciudad', '01:15:00', '2024-12-03 07:15:00', 30.75, 3, 1, 3),
('Excursión al campo', '04:00:00', '2024-12-04 10:00:00', 50.00, 4, 5, 4),
('Viaje al puerto', '02:10:00', '2024-12-05 12:30:00', 40.25, 5, 6, 5),
('Ruta a la estación', '01:45:00', '2024-12-06 14:00:00', 35.00, 6, 7, 6),
('Viaje a la isla', '03:00:00', '2024-12-07 15:30:00', 55.50, 7, 1, 7),
('Excursión a la selva', '04:15:00', '2024-12-08 16:45:00', 65.00, 1, 4, 8),
('Ruta hacia el río', '02:25:00', '2024-12-09 18:00:00', 48.00, 2, 5, 9),
('Visita a las ruinas', '03:10:00', '2024-12-10 19:30:00', 58.75, 3, 6, 10);

--Inserción de datos en la tabla PASAJE.

-- Tabla Pasaje
INSERT INTO Pasaje (costoPasaje, idBus, filaAsiento, letraAsiento, fechaCompra, utilizado, idTerminalDestino, idTurista ) VALUES
(45.50, 1, 2, 'A', '2017-05-15', 1, 1, 10), 
(60.00, 3, 2, 'B', '2018-05-15', 0, 2, 5),
(55.25, 5, 3, 'C', '2019-07-10', 1, 4, 3),
(40.00, 4, 1, 'D', '2020-02-20', 0, 3, 14),
(65.75, 2, 4, 'A', '2021-01-25', 1, 5, 2),
(50.50, 7, 1, 'B', '2022-06-12', 0, 6, 12),
(70.00, 6, 5, 'C', '2023-08-30', 1, 7, 17),
(48.90, 9, 2, 'A', '2020-10-15', 1, 3, 4),
(60.75, 8, 3, 'B', '2019-11-05', 0, 1, 8),
(52.25, 10, 1, 'C', '2018-09-19', 1, 2, 6),
(47.30, 2, 5, 'D', '2021-05-21', 0, 4, 13),
(55.00, 4, 4, 'A', '2020-04-14', 1, 5, 7),
(62.50, 3, 1, 'B', '2017-12-09', 0, 6, 9),
(43.40, 5, 2, 'C', '2022-02-20', 1, 7, 15),
(58.30, 6, 3, 'D', '2019-03-10', 1, 1, 1),
(65.20, 7, 4, 'A', '2021-08-22', 0, 2, 16),
(61.75, 9, 5, 'B', '2023-05-30', 1, 3, 11),
(46.90, 8, 1, 'C', '2020-07-11', 1, 4, 5),
(54.00, 4, 3, 'D', '2019-01-17', 0, 5, 14),
(50.00, 1, 2, 'A', '2022-03-25', 0, 6, 3),
(59.00, 3, 4, 'B', '2021-10-12', 1, 7, 9),
(63.30, 5, 5, 'C', '2023-04-28', 1, 1, 16),
(45.75, 6, 2, 'D', '2018-06-07', 0, 2, 12),
(67.00, 7, 3, 'A', '2017-09-18', 1, 3, 7),
(67.00, 7, 3, 'A', '2017-09-18', 1, 3, 18),
(67.00, 7, 3, 'A', '2017-09-25', 1, 4, 18),
(67.00, 7, 3, 'A', '2017-09-27', 1, 2, 18),
(67.00, 7, 3, 'A', '2017-09-29', 1, 1, 18),
(52.40, 8, 4, 'B', '2019-12-14', 0, 4, 4),
(62.80, 2, 5, 'C', '2020-05-05', 1, 5, 10),
(56.00, 9, 1, 'D', '2021-11-22', 0, 6, 13),
(48.20, 10, 2, 'A', '2022-07-16', 1, 7, 6),
(66.00, 1, 3, 'B', '2019-11-01', 1, 1, 2),
(57.90, 3, 4, 'C', '2020-04-07', 0, 2, 11),
(53.50, 4, 1, 'D', '2018-08-30', 1, 3, 8),
(51.20, 5, 2, 'A', '2021-02-10', 0, 4, 1),
(64.60, 6, 3, 'B', '2022-09-21', 1, 5, 14),
(68.75, 7, 4, 'C', '2023-01-19', 0, 6, 10),
(49.80, 8, 5, 'D', '2017-07-02', 1, 7, 17),
(58.50, 2, 1, 'A', '2021-05-17', 0, 1, 5),
(45.90, 3, 2, 'B', '2019-04-23', 1, 2, 13),
(62.10, 4, 3, 'C', '2020-06-14', 0, 3, 16),
(55.00, 5, 4, 'D', '2022-01-18', 1, 4, 12),
(61.40, 6, 5, 'A', '2021-03-03', 0, 5, 4),
(68.00, 7, 1, 'B', '2023-02-06', 1, 6, 9),
(49.70, 8, 2, 'C', '2018-10-09', 0, 7, 6),
(66.50, 9, 3, 'D', '2022-11-15', 1, 1, 15),
(60.20, 10, 4, 'A', '2023-06-13', 0, 2, 8),
(63.60, 1, 5, 'B', '2019-02-08', 1, 3, 17),
(50.40, 3, 1, 'C', '2020-11-25', 0, 4, 2),
(52.70, 4, 2, 'D', '2021-04-30', 1, 5, 12),
(64.20, 5, 3, 'A', '2022-05-16', 1, 6, 7),
(51.90, 6, 4, 'B', '2023-08-14', 0, 7, 14),
(56.40, 7, 5, 'C', '2018-01-11', 1, 1, 10),
(67.50, 8, 1, 'D', '2021-09-17', 0, 2, 16),
(45.50, 1, 2, 'A', '2017-05-15', 1, 1, 9),
(32.00, 3, 4, 'B', '2018-08-21', 0, 3, 5),
(50.25, 6, 1, 'C', '2019-03-12', 1, 7, 14),
(38.00, 2, 5, 'A', '2020-11-04', 0, 5, 8),
(60.75, 10, 3, 'D', '2017-12-25', 1, 4, 16),
(47.00, 5, 2, 'B', '2019-07-15', 0, 2, 3),
(52.50, 9, 1, 'A', '2021-05-10', 1, 6, 12),
(40.00, 7, 4, 'C', '2023-01-20', 1, 3, 7),
(55.25, 4, 3, 'D', '2018-09-30', 0, 1, 11),
(39.00, 8, 5, 'B', '2022-04-08', 1, 7, 15),
(42.75, 2, 1, 'C', '2017-02-14', 0, 5, 6),
(59.50, 10, 2, 'A', '2020-10-05', 1, 4, 13),
(36.00, 6, 3, 'D', '2021-07-19', 0, 2, 9),
(51.25, 1, 4, 'C', '2023-03-01', 1, 6, 4),
(48.00, 3, 5, 'B', '2019-11-25', 1, 3, 17),
(62.00, 7, 2, 'A', '2018-06-18', 0, 7, 1),
(44.50, 9, 1, 'D', '2020-09-12', 1, 1, 2),
(35.75, 5, 4, 'C', '2022-02-10', 0, 4, 8),
(53.00, 4, 5, 'B', '2017-12-15', 1, 3, 10),
(41.25, 2, 3, 'A', '2018-04-05', 1, 2, 11),
(46.00, 6, 1, 'C', '2021-09-07', 0, 7, 12),
(58.75, 8, 2, 'B', '2023-05-15', 1, 5, 13),
(37.00, 10, 4, 'D', '2020-02-18', 0, 1, 15),
(49.50, 1, 5, 'A', '2019-10-11', 1, 4, 16),
(43.00, 3, 3, 'C', '2017-07-22', 0, 6, 14),
(54.25, 9, 2, 'B', '2022-06-20', 1, 7, 17),
(39.75, 7, 4, 'D', '2020-11-13', 0, 3, 6),
(56.00, 5, 1, 'A', '2018-03-19', 1, 2, 9),
(50.50, 2, 5, 'C', '2017-01-08', 1, 4, 3),
(45.25, 8, 3, 'B', '2019-08-21', 0, 5, 10),
(48.75, 10, 4, 'D', '2021-11-29', 1, 1, 15),
(40.50, 4, 5, 'A', '2023-02-15', 1, 3, 13),
(63.00, 6, 1, 'C', '2022-12-31', 0, 7, 2),
(41.75, 1, 2, 'B', '2017-09-25', 1, 6, 14),
(52.00, 3, 3, 'D', '2021-04-17', 1, 5, 8),
(57.50, 7, 4, 'A', '2023-07-20', 0, 2, 4),
(36.25, 9, 5, 'C', '2020-06-05', 1, 4, 16),
(47.75, 2, 1, 'B', '2018-02-12', 1, 1, 11),
(42.00, 5, 2, 'D', '2019-11-30', 0, 7, 12),
(59.25, 10, 3, 'C', '2021-08-22', 1, 3, 7),
(34.50, 8, 4, 'A', '2022-05-10', 0, 6, 1),
(51.00, 4, 5, 'B', '2017-04-18', 1, 5, 9),
(46.25, 6, 2, 'D', '2020-12-25', 1, 2, 10),
(55.50, 1, 3, 'C', '2023-10-09', 0, 4, 14),
(43.75, 3, 4, 'A', '2018-05-19', 1, 7, 15),
(60.00, 7, 5, 'B', '2019-09-27', 0, 1, 8),
(38.50, 9, 2, 'D', '2021-02-13', 1, 3, 16),
(49.75, 2, 1, 'C', '2017-08-11', 1, 6, 10),
(44.00, 5, 4, 'A', '2020-04-06', 0, 2, 13);

--OBTENER TODOS LOS DATOS RELACIONADOS ENTRE SI

SELECT 
    p.*, 
    t.nombreTurista, apellidoPaterno, apellidoMaterno, fechaNacimiento, tipoDocumento, nroDocumento, correoElectronico,  
    c.*,
	b.detalleBeneficio
FROM Pasaje p
JOIN Turista t ON p.idTurista = t.idTurista
JOIN Categoria c ON t.IdCategoria = c.IdCategoria
JOIN BeneficiosCategoria b on c.idCategoria = b.idCategoria;

