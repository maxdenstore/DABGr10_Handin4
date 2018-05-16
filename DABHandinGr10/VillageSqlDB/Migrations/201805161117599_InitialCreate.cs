namespace VillageSqlDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        VillageID = c.Int(nullable: false, identity: true),
                        VillageMeter = c.Int(nullable: false),
                        CookerAmount = c.Int(nullable: false),
                        CookerCapacity = c.Int(nullable: false),
                        CookerConsumption = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VillageID);
            
            CreateTable(
                "dbo.Prosumers",
                c => new
                    {
                        CopperID = c.Int(nullable: false, identity: true),
                        smartmeter = c.Int(nullable: false),
                        wallet = c.Int(nullable: false),
                        prosumerType = c.String(),
                        Village_VillageID = c.Int(),
                    })
                .PrimaryKey(t => t.CopperID)
                .ForeignKey("dbo.Villages", t => t.Village_VillageID)
                .Index(t => t.Village_VillageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prosumers", "Village_VillageID", "dbo.Villages");
            DropIndex("dbo.Prosumers", new[] { "Village_VillageID" });
            DropTable("dbo.Prosumers");
            DropTable("dbo.Villages");
        }
    }
}
