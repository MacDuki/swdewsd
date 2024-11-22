-- DQL
-----------------------------------------------------
use ObligatorioBD1

Set dateformat ymd;

--1. Listar el o los nombres de los pasajeros 
--con la mayor cantidad de pasajes comprados a su nombre.


SELECT 
        Turista.nombreTurista as 'Nombre del turista', 
    COUNT(Pasaje.idTurista) AS 'Cantidad de pasajes'
FROM Pasaje
JOIN Turista ON Turista.idTurista = Pasaje.idTurista
GROUP BY Turista.idTurista, Turista.nombreTurista
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
WHERE Bus.CapacidadBus > 35 
AND CAST(Destino.fechaYHoraSalida AS DATE) != CAST(DATEADD(DAY, 1, GETDATE()) AS DATE)

------------------

--3. Listar todos los datos de los pasajeros para los cuales
-- haya registrados en el sistema más de 5 pasajes comprados.

SELECT Turista.idTurista, Turista.nombreTurista, Turista.apellidoPaterno, Turista.ApellidoMaterno, Turista.NroDocumento, Turista.CorreoElectronico, Turista.IdCategoria, Registrado.Contrasenia, Count(Pasaje.idPasaje) as 'Cantidad pasajes' FROM TURISTA 
JOIN Pasaje ON (Pasaje.idTurista = Turista.IdTurista)
JOIN Registrado ON (Registrado.idTurista = Pasaje.idTurista)
GROUP BY Turista.idTurista, Turista.nombreTurista, Turista.apellidoPaterno, Turista.ApellidoMaterno, Turista.NroDocumento, Turista.CorreoElectronico, Turista.IdCategoria, Registrado.Contrasenia
HAVING COUNT (Pasaje.idPasaje) > 5

---------------------------------------------------------------------------------------

--4. Listar idpasajero, nombre, apellidos y asiento (idasiento y fila) que
-- correspondan a pasajes comprados para el destino cuyo idviaje es 255, como no tenemos id 255 se sustituye por idViaje 1.

SELECT Turista.idTurista, Turista.NombreTurista, Turista.ApellidoPaterno, Turista.Apellidomaterno, Asiento.idAsiento, Asiento.filaAsiento, Asiento.letraAsiento from Turista
JOIN Pasaje ON (Pasaje.idTurista = Turista.IdTurista)
JOIN Destino ON (Destino.idDestino = Pasaje.idTerminalDestino)
JOIN Bus ON (Bus.idBus = Destino.idBus)
JOIN Asiento ON (Asiento.idBus = Bus.idBus)
WHERE Destino.idDestino = 1 


---------------------------------------------------------------------------------------

-- 5. Listar todos los idviaje y cantidad de pasajes para c/u de los destinos del
-- pasajero cuyo correo es soyturista@gmail.com.
-- comprados en Setiembre del 2017
-- La lista debe estar ordenada por idviaje
-- ascendente.

SELECT Destino.idDestino, count(Pasaje.idPasaje) as 'Cantidad de pasajes' FROM Destino 
JOIN PASAJE ON (Pasaje.idTerminalDestino = Destino.idDestino)
JOIN Turista ON (Turista.idTurista = Pasaje.idTurista)
WHERE Turista.CorreoElectronico = 'soyturista@gmail.com' AND Pasaje.fechaCompra BETWEEN '2017/09/01' AND '2017/09/30' 
GROUP BY Destino.idDestino 
ORDER BY 'Cantidad de pasajes' ASC  


----------------------------------------------------------------------



