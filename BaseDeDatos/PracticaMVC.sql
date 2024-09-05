
CREATE TABLE Datos(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100),
	Salario DECIMAL(10, 2),
	FechaNacimiento VARCHAR(100)
)
go 

create procedure p_Listar
as
begin
	select * from Datos
end
go

create procedure p_Obtener(
@Id int
)
as
begin
	select * from Datos where  Id = @Id
end
go

create procedure p_Insertar(
@Nombre varchar(100),
@Salario DECIMAL(10, 2),
@FechaNacimiento varchar(100) 
)
as
begin
	insert into Datos(
		Nombre,
		Salario,
		FechaNacimiento) 
	values (@Nombre,@Salario,@FechaNacimiento)
end
go

create procedure p_Actualizar(
@Id int,
@Nombre varchar(100),
@Salario DECIMAL(10, 2),
@FechaNacimiento varchar(100) 
)
as
begin
	update Datos set Nombre = @Nombre, Salario = @Salario , FechaNacimiento = @FechaNacimiento where Id = @Id
end
go

create procedure p_Eliminar(
@Id int
)
as
begin
	delete from Datos where Id = @Id
end

INSERT INTO Datos (Nombre, Salario, FechaNacimiento)
VALUES ('Juan Pérez', 30000.50, '1990-05-15'),
       ('María García', 45000.00, '1985-08-23'),
       ('Luis López', 52000.75, '1992-12-11'),
       ('Ana Martínez', 38000.25, '1988-03-30'),
       ('Carlos Díaz', 47000.10, '1991-09-18');

EXEC p_Listar;
EXEC p_Insertar 'Norlan Gonzalez', 20000, '2003-05-20';
EXEC p_Obtener 1;
EXEC sp_Eliminar 6;
EXEC sp_Actualizar 1, 'Juan Pérez Actualizado', 35000.75, '1990-05-15';


