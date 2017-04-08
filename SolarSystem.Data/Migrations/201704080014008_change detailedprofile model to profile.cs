namespace SolarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedetailedprofilemodeltoprofile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DetailedProfiles", newName: "Profiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Profiles", newName: "DetailedProfiles");
        }
    }
}
