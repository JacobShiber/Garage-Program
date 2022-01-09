namespace Garage_Program.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCarsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                        CarNumber = c.Int(nullable: false),
                        RepairStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
