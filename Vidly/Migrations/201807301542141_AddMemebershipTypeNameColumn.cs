namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemebershipTypeNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "TypeName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "TypeName");
        }
    }
}
