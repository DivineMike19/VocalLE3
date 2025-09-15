CREATE PROCEDURE [dbo].[spUsers_Register]
    @Username NVARCHAR(50),
    @Password NVARCHAR(200),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Users (Username, Password, FirstName, LastName)
    VALUES (@Username, @Password, @FirstName, @LastName);
END
