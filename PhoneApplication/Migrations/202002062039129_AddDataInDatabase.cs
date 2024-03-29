﻿namespace PhoneApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataInDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                        Founded = c.DateTime(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneID = c.Int(nullable: false, identity: true),
                        ManufacturerID = c.Int(nullable: false),
                        PhoneName = c.String(),
                        MSRP = c.Double(nullable: false),
                        ScreenSize = c.Int(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerID, cascadeDelete: true)
                .Index(t => t.ManufacturerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "ManufacturerID", "dbo.Manufacturers");
            DropIndex("dbo.Phones", new[] { "ManufacturerID" });
            DropTable("dbo.Phones");
            DropTable("dbo.Manufacturers");
        }
    }
}
