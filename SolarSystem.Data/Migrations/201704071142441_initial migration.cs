namespace SolarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlanetId = c.Int(nullable: false),
                        Name = c.String(),
                        SmallImage = c.String(),
                        Ordinal = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.PlanetId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StarId = c.Int(nullable: false),
                        Name = c.String(),
                        SmallImage = c.String(),
                        Ordinal = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stars", t => t.StarId, cascadeDelete: true)
                .Index(t => t.StarId);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SmallImage = c.String(),
                        Ordinal = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planets", "StarId", "dbo.Stars");
            DropForeignKey("dbo.Moons", "PlanetId", "dbo.Planets");
            DropIndex("dbo.Planets", new[] { "StarId" });
            DropIndex("dbo.Moons", new[] { "PlanetId" });
            DropTable("dbo.Stars");
            DropTable("dbo.Planets");
            DropTable("dbo.Moons");
        }
    }
}
