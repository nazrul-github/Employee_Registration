SELECT * FROM customer_list GROUP BY notes

DELETE FROM customer_list WHERE zip_code = 1218

ALTER PROCEDURE sp_CreateCustomer
@Id int,
@Name NVARCHAR(50),
@Address NVARCHAR(50),
@ZipCode NVARCHAR(50),
@Phone NVARCHAR(50),
@City NVARCHAR(50),
@Country NVARCHAR(50)
AS
BEGIN
INSERT INTO customer_list([id],
[name]
      ,[address]
      ,[zip_code]
      ,[phone]
      ,[city]
      ,[country]) VALUES(@Id,@Name,@Address,@ZipCode,@Phone,@City,@Country)
END