namespace TADBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TA_Header", "TAPurposePkId", "dbo.TA_Purpose");
            DropForeignKey("dbo.TA_Header", "TATravelTypePkId", "dbo.TA_TravelType");
            DropPrimaryKey("dbo.TA_Purpose");
            DropPrimaryKey("dbo.TA_TravelType");
            AlterColumn("dbo.TA_Purpose", "TravelPurposePkId", c => c.Long(nullable: false));
            AlterColumn("dbo.TA_TravelType", "TravelTypePkId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.TA_Purpose", "TravelPurposePkId");
            AddPrimaryKey("dbo.TA_TravelType", "TravelTypePkId");
            AddForeignKey("dbo.TA_Header", "TAPurposePkId", "dbo.TA_Purpose", "TravelPurposePkId", cascadeDelete: true);
            AddForeignKey("dbo.TA_Header", "TATravelTypePkId", "dbo.TA_TravelType", "TravelTypePkId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TA_Header", "TATravelTypePkId", "dbo.TA_TravelType");
            DropForeignKey("dbo.TA_Header", "TAPurposePkId", "dbo.TA_Purpose");
            DropPrimaryKey("dbo.TA_TravelType");
            DropPrimaryKey("dbo.TA_Purpose");
            AlterColumn("dbo.TA_TravelType", "TravelTypePkId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.TA_Purpose", "TravelPurposePkId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.TA_TravelType", "TravelTypePkId");
            AddPrimaryKey("dbo.TA_Purpose", "TravelPurposePkId");
            AddForeignKey("dbo.TA_Header", "TATravelTypePkId", "dbo.TA_TravelType", "TravelTypePkId", cascadeDelete: true);
            AddForeignKey("dbo.TA_Header", "TAPurposePkId", "dbo.TA_Purpose", "TravelPurposePkId", cascadeDelete: true);
        }
    }
}
