CREATE PROCEDURE [dbo].[spPosts_Insert]
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX),
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Posts (Title, Content, UserId, DateCreated)
    VALUES (@Title, @Content, @UserId, GETDATE());
END
