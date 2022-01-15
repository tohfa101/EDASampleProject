namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.staff01office_info", "staff01email", c => c.String(nullable: false, defaultValue: "default@mail.com"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.staff01office_info", "staff01email");
        }
    }
}
