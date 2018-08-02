namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("Insert into Genres (Id, GenreName) Values(1, 'Comedy')");
            Sql("Insert into Genres (Id, GenreName) Values(2, 'Action')");
            Sql("Insert into Genres (Id, GenreName) Values(3, 'Family')");
            Sql("Insert into Genres (Id, GenreName) Values(4, 'Romance')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
