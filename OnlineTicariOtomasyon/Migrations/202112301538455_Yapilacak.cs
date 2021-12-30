namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yapilacak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yapilacaks", "Urun_UrunId", c => c.Int());
            AddColumn("dbo.Yapilacaks", "Personel_PersonelId", c => c.Int());
            CreateIndex("dbo.Yapilacaks", "Urun_UrunId");
            CreateIndex("dbo.Yapilacaks", "Personel_PersonelId");
            AddForeignKey("dbo.Yapilacaks", "Urun_UrunId", "dbo.Uruns", "UrunId");
            AddForeignKey("dbo.Yapilacaks", "Personel_PersonelId", "dbo.Personels", "PersonelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yapilacaks", "Personel_PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Yapilacaks", "Urun_UrunId", "dbo.Uruns");
            DropIndex("dbo.Yapilacaks", new[] { "Personel_PersonelId" });
            DropIndex("dbo.Yapilacaks", new[] { "Urun_UrunId" });
            DropColumn("dbo.Yapilacaks", "Personel_PersonelId");
            DropColumn("dbo.Yapilacaks", "Urun_UrunId");
        }
    }
}
