namespace TinySoccerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OffenceStoppedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameResult", "OffenceStopped", c => c.Int());
            AlterColumn("dbo.GameResult", "Goals", c => c.Int());
            AlterColumn("dbo.GameResult", "Yellow", c => c.Int());
            AlterColumn("dbo.GameResult", "Red", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameResult", "Red", c => c.Int(nullable: false));
            AlterColumn("dbo.GameResult", "Yellow", c => c.Int(nullable: false));
            AlterColumn("dbo.GameResult", "Goals", c => c.Int(nullable: false));
            DropColumn("dbo.GameResult", "OffenceStopped");
        }
    }
}
