namespace SolarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Moons", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Planets", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stars", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Profiles", "Introduction", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Moons", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Planets", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stars", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stars", "Name", c => c.String());
            AlterColumn("dbo.Planets", "Name", c => c.String());
            AlterColumn("dbo.Moons", "Name", c => c.String());
            AlterColumn("dbo.Profiles", "Content", c => c.String());
            AlterColumn("dbo.Profiles", "Introduction", c => c.String());
            DropColumn("dbo.Stars", "Timestamp");
            DropColumn("dbo.Planets", "Timestamp");
            DropColumn("dbo.Moons", "Timestamp");
            DropColumn("dbo.Profiles", "Timestamp");
        }
    }
}
