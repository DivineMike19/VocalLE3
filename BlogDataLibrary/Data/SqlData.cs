using BlogDataLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDataLibrary.Data
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        //  Authenticate user
        public async Task<UserModel?> Authenticate(string username, string password)
        {
            var results = await _db.LoadData<UserModel, dynamic>(
                "dbo.spUsers_Authenticate",
                new { Username = username, Password = password },
                connectionStringName);

            return results.FirstOrDefault();
        }

        //  Register user
        public async Task Register(string username, string password, string firstName, string lastName)
        {
            await _db.SaveData(
                "dbo.spUsers_Register",
                new { Username = username, Password = password, FirstName = firstName, LastName = lastName },
                connectionStringName);
        }

        //  Add post
        public async Task AddPost(int userId, string title, string body)
        {
            await _db.SaveData(
                "dbo.spPosts_Insert",
                new { UserId = userId, Title = title, Content = body },
                connectionStringName);
        }

        //  List posts
        public async Task<IEnumerable<ListPostModel>> ListPosts()
        {
            return await _db.LoadData<ListPostModel, dynamic>(
                "dbo.spPosts_List",
                new { },
                connectionStringName);
        }

        //  Show post details
        public async Task<PostModel?> ShowPostDetails(int postId)
        {
            var results = await _db.LoadData<PostModel, dynamic>(
                "dbo.spPosts_Detail",
                new { PostId = postId },
                connectionStringName);

            return results.FirstOrDefault();
        }
    }
}
