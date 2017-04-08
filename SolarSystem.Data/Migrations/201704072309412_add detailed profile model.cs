namespace SolarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddetailedprofilemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailedProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LargeImage = c.String(),
                        Introduction = c.String(),
                        Content = c.String(),
                        EffectiveTemperature = c.String(),
                        Diameter = c.String(),
                        FirstRecorded = c.String(),
                        RecordedBy = c.String(),
                        Mass = c.String(),
                        DayLength = c.String(),
                        YearLength = c.String(),
                        OrbitalDistance = c.String(),
                        HasRings = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DetailedProfiles");
        }
    }
}
