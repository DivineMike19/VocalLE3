CREATE PROCEDURE [dbo].[spPosts_List]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id,
        p.Title,
        u.Username AS Username,               
        p.DateCreated,
        LEFT(p.Content, 20) AS BodyPreview     
    FROM dbo.Posts AS p
    INNER JOIN dbo.Users AS u ON p.UserId = u.Id
    ORDER BY p.DateCreated DESC;
END
