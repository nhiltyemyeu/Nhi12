create database HRR
go
create table Areas(
id int,
name nvarchar(255))

create table customer(
id int,
name nvarchar(255),
id_area int
)

go

insert into Areas values (1,'Trung')
insert into Areas values (2,'Nam')
insert into Areas values (3,'Bac')

insert into customer values (1,'Nhi',1)
insert into customer values (2,'Thanh',2)
insert into customer values (3,'Linh',2)

Create Proc GetAr
as
begin
     select * from customer
	select * from Areas
end
go

EXEC GetAr

Create Proc GetCustomer
as
begin
     select * from customer

end
go

EXEC GetCustomer

Create Proc GetArea
as
begin
     select * from Areas
end
go

EXEC GetArea

create proc InserCustomer
@id int,
@name nvarchar(255),
@id_area int
as
begin
    insert customer(id,name,id_area) values(@id,@name,@id_area)
end
go


create proc UpdateCustomer
@id int,
@name nvarchar(255),
@id_area int
as
begin
    update customer
    set
       name = @name,
		id_area = @id_area
    where id = @id
end
go



create proc DeleteCustomer
@id int
as
begin
    delete customer where id = @id
end
go
select * from Areas
select * from customer
drop database Areas
drop table customer
drop table Areas
drop proc GetAr
drop proc DeleteCustomer
drop proc UpdateCustomer
drop proc InserCustomer
drop proc GetArea
drop proc GetCustomer