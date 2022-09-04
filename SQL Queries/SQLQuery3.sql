CREATE TABLE dbo.Employees(
EmployeeID int IDENTITY(1,1) NOT NULL,
EmployeeName varchar(100),
Department varchar(100),
MailID varchar(100),
DOJ DATE
)

SELECT * FROM DBO.Employees

insert into dbo.Employees values('Cenk', 'Finance', 'cenk@gmail.com','4-18-2022')