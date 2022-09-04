CREATE TABLE dbo.Departments
(
DepartmentID int IDENTITY(1,1) NOT NULL,
DepartmentName nvarchar(1000)
)

select * from dbo.Departments

insert into dbo.Departments VALUES ('Software')