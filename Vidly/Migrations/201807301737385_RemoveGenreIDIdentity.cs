namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenreIDIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false, identity: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
