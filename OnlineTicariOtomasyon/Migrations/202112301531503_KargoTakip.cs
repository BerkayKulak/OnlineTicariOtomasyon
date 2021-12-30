namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KargoTakip : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KargoTakips");
            AlterColumn("dbo.KargoTakips", "KargoTakipId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.KargoTakips", "KargoTakipId");
            CreateIndex("dbo.KargoTakips", "KargoTakipId");
            AddForeignKey("dbo.KargoTakips", "KargoTakipId", "dbo.Uruns", "UrunId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KargoTakips", "KargoTakipId", "dbo.Uruns");
            DropIndex("dbo.KargoTakips", new[] { "KargoTakipId" });
            DropPrimaryKey("dbo.KargoTakips");
            AlterColumn("dbo.KargoTakips", "KargoTakipId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.KargoTakips", "KargoTakipId");
        }
    }
}
