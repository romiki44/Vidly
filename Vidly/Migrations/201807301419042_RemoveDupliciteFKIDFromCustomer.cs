namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDupliciteFKIDFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MemmbershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemmbershipTypeId", c => c.Byte(nullable: false));
        }
    }
}
