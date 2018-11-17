namespace TADBAccessOracle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TAAnywhere.TA_TravelType",
                c => new
                    {
                        TravelTypePkId = c.Decimal(nullable: false, precision: 19, scale: 0),
                        TravelType = c.String(nullable: false, maxLength: 50, unicode: false),
                        TravelTypeDescirption = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TravelTypePkId);
            
        }
        
        public override void Down()
        {
            DropTable("TAAnywhere.TA_TravelType");
        }
    }
}
