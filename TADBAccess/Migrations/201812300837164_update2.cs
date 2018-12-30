namespace TADBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TA_Employee", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TA_Employee", "Email", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
