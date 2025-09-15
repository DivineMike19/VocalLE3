CREATE PROCEDURE [dbo].[spUsers_Authenticate]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Username, FirstName, LastName
    FROM dbo.Users
    WHERE Username = @Username AND [Password] = @Password;
END
