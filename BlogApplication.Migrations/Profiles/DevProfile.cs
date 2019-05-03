using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Data.Models;
using BlogApplication.Data.Repositories;
using BlogApplication.Models;
using FluentMigrator;
using Faker;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using BlogPost = BlogApplication.Models.BlogPost;
using Comment = BlogApplication.Models.Comment;
using User = BlogApplication.Models.User;

namespace BlogApplication.Migrations.Profiles
{
    [Profile("Development")]
    public class DevProfile : Migration
    {
        private const int NumOfUsers = 30;
        private const int NumOfPosts = 5;
        private const int NumOfComments = 3;
 
        private OrmLiteConnectionFactory _dbFactory;

        public override void Up()
        {
            _dbFactory = new OrmLiteConnectionFactory(ConnectionString, 
                new SqlServerOrmLiteDialectProvider());

            using (var db = _dbFactory.Open())
            {
                DeleteDevData(db);
                CreateUsersAndPosts(db);
            }
        }

        private void DeleteDevData(IDbConnection db)
        {
            db.DeleteAll<Comment>();
            db.DeleteAll<BlogPost>();
            db.DeleteAll<User>();
        }

        private void CreateUsersAndPosts(IDbConnection db)
        {
            for (var i = 0; i < NumOfUsers; i++)
            {
                var user = new User
                {
                    Username = Faker.Internet.UserName(),
                    EmailAddress = Faker.Internet.Email(),
                    Password = "123456Aa",
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    DateOfBirth = DateTime.Now,
                    CreatedDate = DateTime.Now
                };

                var userId = (int) db.Insert(user, true);

                for (var j = 0; j < NumOfPosts; j++)
                {
                    var post = new BlogPost
                    {
                        UserId = userId,
                        Title = Faker.Lorem.Sentence(5),
                        Body = string.Join(" ", Faker.Lorem.Paragraphs(2)),
                        PublishDate = DateTime.Now
                    };

                    var blogId = (int) db.Insert(post, true);

                    for (var k = 0; k < NumOfComments; k++)
                    {
                        var comment = new Comment
                        {
                            BlogPostId = blogId,
                            UserId = userId,
                            Title = Faker.Lorem.Sentence(),
                            Body = Faker.Lorem.Sentence(),
                            PostedDate = DateTime.Now,
                        };

                        var commentId = db.Insert(comment, true);
                    }
                }
            }
        }

        public override void Down()
        {

        }
    }
}
