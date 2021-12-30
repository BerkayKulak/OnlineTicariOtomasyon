namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Faturalar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturalars", "Urun_UrunId", c => c.Int());
            CreateIndex("dbo.Faturalars", "Urun_UrunId");
            AddForeignKey("dbo.Faturalars", "Urun_UrunId", "dbo.Uruns", "UrunId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faturalars", "Urun_UrunId", "dbo.Uruns");
            DropIndex("dbo.Faturalars", new[] { "Urun_UrunId" });
            DropColumn("dbo.Faturalars", "Urun_UrunId");
        }
    }
}
