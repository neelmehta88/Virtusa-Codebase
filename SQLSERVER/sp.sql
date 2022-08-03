create procedure GetEmployees
as
begin
select * from employee
end

exec GetEmployees
create procedure GetEmployeeById(@id int)
as
begin
select * from employee where Eid=@id
end

exec GetEmployeeById 1010
create procedure AddEmployee(@eid int,@ename varchar(20),@salary int,@joindate date,@project varchar(20))
as
begin
insert into employee values(@eid,@ename,@salary,@joindate,@project)
end
exec AddEmployee 4323,'Hemanth',45000,'07.23.2022','SMS'