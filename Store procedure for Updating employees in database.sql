Create PROCEDURE sp_UpdateCustomer

@Name NVARCHAR(50),
@Address NVARCHAR(50),
@ZipCode NVARCHAR(50),
@Phone NVARCHAR(50),
@City NVARCHAR(50),
@Country NVARCHAR(50),
@Id int
AS
BEGIN
UPDATE customer_list
SET
[name] = @Name
      ,[address] =  @Address
      ,[zip_code] = @ZipCode
      ,[phone] = @Phone
      ,[city] = @City
      ,[country] = @Country
WHERE id = @Id
END