namespace CustomerTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, Email) VALUES('Caleb Kristoff', 'someemail@gmail.com')");
        }
        
        public override void Down()
        {
        }
    }
}
