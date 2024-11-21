-- DQL
-----------------------------------------------------
use ObligatorioBD
Set dateformat ymd;

--1. Listar el o los nombres de los pasajeros 
--con la mayor cantidad de pasajes comprados a su nombre.

SELECT 
    Registrado.nombre, 
    COUNT(Pasaje.idTurista) AS 'Cantidad de pasajes'
FROM Pasaje
JOIN Registrado ON Registrado.idTurista = Pasaje.idTurista
GROUP BY Registrado.idTurista, Registrado.nombre
HAVING COUNT(Pasaje.idTurista) = (
    SELECT MAX(TotalPasajes)
    FROM (
        SELECT COUNT(*) AS TotalPasajes
        FROM Pasaje
        GROUP BY Pasaje.idTurista
    ) AS Subconsulta
)

---------------------------------------------------------------------------------------

--2. Listar todos los datos de los buses con más de 35 asientos
-- que no tengan asignado ningún destino que parta el día de mañana.

SELECT * 
FROM Bus
JOIN Destino ON Destino.idBus = Bus.idBus
WHERE Bus.Capacidad > 35 
AND CAST(Destino.fechaYHoraSalida AS DATE) != CAST(DATEADD(DAY, 1, GETDATE()) AS DATE)


------------------

--3. Listar todos los datos de los pasajeros para los cuales
-- haya registrados en el sistema más de 5 pasajes comprados.

SELECT Registrado.idTurista, Registrado.Nombre, Registrado.apellidoPaterno, Registrado.ApellidoMaterno, Registrado.NroDocumento, Registrado.CorreoElectronico, Registrado.IdCategoria, Registrado.Contrasenia, Count(Pasaje.idPasaje) as 'Cantidad pasajes' FROM REGISTRADO 
JOIN Pasaje ON (Pasaje.idTurista = Registrado.IdTurista)
GROUP BY Registrado.idTurista, Registrado.Nombre, Registrado.apellidoPaterno, Registrado.ApellidoMaterno, Registrado.NroDocumento, Registrado.CorreoElectronico, Registrado.IdCategoria, Registrado.Contrasenia
HAVING COUNT (Pasaje.idPasaje) > 5







---------------------------------------------------------------------------------------

--4. Listar idpasajero, nombre, apellidos y asiento (idasiento y fila) que
-- correspondan a pasajes comprados para el destino cuyo idviaje es 255.

SELECT Registrado.idPasajero Registrado.Nombre Registrado.ApellidoPaterno Registrado.Apellidomaterno, Asiento.IdAsiento Asiento.IdFila from REGISTRO








---------------------------------------------------------------------------------------

-- 5. Listar todos los idviaje y cantidad de pasajes para c/u de los destinos del
-- pasajero cuyo correo es soyturista@gmail.com.
-- comprados en Setiembre del 2017
-- La lista debe estar ordenada por idviaje
-- ascendente.










----------------------------------------------------------------------



