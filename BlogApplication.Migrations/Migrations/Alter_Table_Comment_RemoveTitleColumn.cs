using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BlogApplication.Migrations.Migrations
{
    [Migration(2019050301)]
    public class AlterTableCommentRemoveTitleColumn : Migration
    {
        public override void Up()
        {
            Delete.Column("Title").FromTable("Comment");
        }

        public override void Down()
        {
            Alter.Table("Comment").AddColumn("Title")
                .AsString(100).NotNullable().SetExistingRowsTo(" ");
        }
    }
}
