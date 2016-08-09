namespace BAChallengeWebServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "Location", c => c.String());
        }
    }
}
