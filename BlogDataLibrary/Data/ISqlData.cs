using BlogDataLibrary.Models;

namespace BlogDataLibrary.Data
{
    public interface ISqlData
    {
        Task AddPost(int userId, string title, string body);
        Task<UserModel?> Authenticate(string username, string password);
        Task<IEnumerable<ListPostModel>> ListPosts();
        Task Register(string username, string password, string firstName, string lastName);
        Task<PostModel?> ShowPostDetails(int postId);
    }
}