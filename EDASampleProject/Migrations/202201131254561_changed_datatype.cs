namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_datatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.staff01office_info", "staff01image_path", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.staff01office_info", "staff01image_path", c => c.Int(nullable: false));
        }
    }
}
