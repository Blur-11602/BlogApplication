using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlogApplication.Models;
using ServiceStack.OrmLite;

namespace BlogApplication.Database.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public Task<List<Comment>> GetAllCommentsForBlog(int blogId)
        {
            var query = Db.From<Comment>()
                .Where(x => x.BlogPostId == blogId);

            return Db.SelectAsync(query);
        }
    }
}