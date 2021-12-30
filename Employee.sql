CREATE DATABASE HR
CREATE TABLE Department
(
id int,
name nvarchar(255)
)
CREATE TABLE Employee
(
idemploy nvarchar(255),
name nvarchar(255),
datebirth nvarchar(255),
gender bit,
playbirth nvarchar(255),
iddepart int)

INSERT INTO Department VALUES (1, N'Nhan su')
INSERT INTO Department VALUES (2, N'Ke toan')
INSERT INTO Department VALUES (3, N'Kinh doanh')

INSERT INTO Employee VALUES (N'C53418', 'Tran Tien','11/10/2000', 1, 'Ha Noi',2)
INSERT INTO Employee VALUES (N'X53416', 'Nguyen Cuong', '21/07/1999',	0,	'Dak Lak',3)
INSERT INTO Employee VALUES (N'M53417', 'Nguyen Hao ', '25/12/2001',	1,	'TP Ho Chi Minh',1)

Create Proc GetHR
as
begin
     select * from Department
	select * from Employee
end
go

EXEC GetHR
/*Department*/
Create Proc GetDepartment
as
begin
     select * from Department
end
go

EXEC GetDepartment



/*Employee*/
Create Proc GetEmployee
as
begin
     select * from Employee
end
go

EXEC GetEmployee

create proc InsertEmployee
@idemploy nvarchar(255),
@name nvarchar(255),
@datebirth datetime,
@gender int,
@playbirth nvarchar(255),
@iddepart nvarchar(255)
as
begin
    insert Employee(idemploy,name,datebirth,gender,playbirth,iddepart) values(@idemploy,@name,@datebirth,@gender,@playbirth,@iddepart)
end
go


create proc UpdateEmployee
@idemploy nvarchar(255),
@name nvarchar(255),
@datebirth datetime,
@gender int,
@playbirth nvarchar(255),
@iddepart nvarchar(255)
as
begin
    update Employee
    set
       name= @name,
	   datebirth=@datebirth,
	   gender = @gender,
	   playbirth=@playbirth,
	   iddepart = @iddepart
    where idemploy = @idemploy
end
go



create proc DeleteEmployee
@idemploy nvarchar(255)
as
begin
    delete Employee where idemploy = @idemploy
end
go

drop table Department
drop table Employee
drop proc GetDepartment
drop proc GetEmployee
drop proc InsertEmployee
drop proc UpdateEmployee
drop proc DeleteEmployee
drop proc GetHR
delete from Employee