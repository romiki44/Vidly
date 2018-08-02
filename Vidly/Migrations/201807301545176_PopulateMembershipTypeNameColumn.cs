namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNameColumn : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET TypeName='Pay as You Go' WHERE Id=1");
            Sql("Update MembershipTypes SET TypeName='Monthly' WHERE Id=2");
            Sql("Update MembershipTypes SET TypeName='Quarterly' WHERE Id=3");
            Sql("Update MembershipTypes SET TypeName='Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
