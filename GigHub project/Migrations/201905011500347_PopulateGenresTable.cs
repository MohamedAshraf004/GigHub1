namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id,Name) VALUES (1,'Jazz')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (2,'Mohamed')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (3,'Ashraf')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (4,'Ahmed')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM GENRES WHERE Id IN (1,2,3,4)");
        }
    }
}
