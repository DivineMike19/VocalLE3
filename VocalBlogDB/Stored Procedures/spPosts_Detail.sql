CREATE PROCEDURE [dbo].[spPosts_Detail]
    @PostId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id,
        p.Title,
        p.Content AS Body,
        u.Username AS Username, 
        p.DateCreated
    FROM dbo.Posts AS p
    INNER JOIN dbo.Users AS u ON p.UserId = u.Id
    WHERE p.Id = @PostId;
END
