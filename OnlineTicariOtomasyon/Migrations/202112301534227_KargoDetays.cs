namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KargoDetays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KargoDetays", "Urun_UrunId", c => c.Int());
            CreateIndex("dbo.KargoDetays", "Urun_UrunId");
            AddForeignKey("dbo.KargoDetays", "Urun_UrunId", "dbo.Uruns", "UrunId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KargoDetays", "Urun_UrunId", "dbo.Uruns");
            DropIndex("dbo.KargoDetays", new[] { "Urun_UrunId" });
            DropColumn("dbo.KargoDetays", "Urun_UrunId");
        }
    }
}
