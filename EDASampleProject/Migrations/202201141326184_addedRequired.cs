namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.staff01office_info", "staff01name", c => c.String(nullable: false));
            AlterColumn("dbo.staff01office_info", "staff01position", c => c.String(nullable: false));
            AlterColumn("dbo.staff01office_info", "staff01depart", c => c.String(nullable: false));
            AlterColumn("dbo.staff01office_info", "staff01image_path", c => c.String(nullable: false));
            AlterColumn("dbo.staff02personal_info", "staff02num", c => c.String(nullable: false));
            AlterColumn("dbo.staff02personal_info", "staff02email", c => c.String(nullable: false));
            AlterColumn("dbo.staff02personal_info", "staff02address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.staff02personal_info", "staff02address", c => c.String());
            AlterColumn("dbo.staff02personal_info", "staff02email", c => c.String());
            AlterColumn("dbo.staff02personal_info", "staff02num", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01image_path", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01depart", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01position", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01name", c => c.String());
        }
    }
}
