using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Migrations.Extensions;
using FluentMigrator;

namespace BlogApplication.Migrations.Migrations
{
    [Migration(2019050101)]
    public class Baseline : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithId()
                .WithColumn("Username").AsString(255).Unique().NotNullable()
                .WithColumn("EmailAddress").AsString(255).Unique().NotNullable()
                .WithColumn("Password").AsMaxString().NotNullable()
                .WithColumn("FirstName").AsString(255).Nullable()
                .WithColumn("LastName").AsString(255).Nullable()
                .WithColumn("DateOfBirth").AsDateTime().Nullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("DateInactive").AsDateTime().Nullable();

            Create.Table("BlogPost")
                .WithId()
                .WithColumn("UserId").AsInt32().ForeignKey("User", "Id")
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Body").AsMaxString().NotNullable()
                .WithColumn("PublishDate").AsDateTime().NotNullable();

            Create.Table("Comment")
                .WithId()
                .WithColumn("UserId").AsInt32().ForeignKey("User", "Id")
                .WithColumn("BlogPostId").AsInt32().ForeignKey("BlogPost", "Id")
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Body").AsString(255).NotNullable()
                .WithColumn("PostedDate").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Comment");
            Delete.Table("BlogPost");
            Delete.Table("User");
        }
    }
}
