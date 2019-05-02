using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlogApplication.Models;
using ServiceStack.OrmLite;

namespace BlogApplication.Database.Repositories
{
    public class BlogRepository : BaseRepository<BlogPost>
    {
        public async Task<List<BlogPost>> GetRecentPosts()
        {
            var query = Db.From<BlogPost>();
            var posts = await Db.SelectAsync(query);
            return posts.OrderByDescending(x => x.PublishDate).Take(10).ToList();
        }
    }
}