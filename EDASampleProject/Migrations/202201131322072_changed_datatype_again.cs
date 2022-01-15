namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_datatype_again : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.staff01office_info", "staff01name", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01position", c => c.String());
            AlterColumn("dbo.staff01office_info", "staff01depart", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.staff01office_info", "staff01depart", c => c.Int(nullable: false));
            AlterColumn("dbo.staff01office_info", "staff01position", c => c.Int(nullable: false));
            AlterColumn("dbo.staff01office_info", "staff01name", c => c.Int(nullable: false));
        }
    }
}
