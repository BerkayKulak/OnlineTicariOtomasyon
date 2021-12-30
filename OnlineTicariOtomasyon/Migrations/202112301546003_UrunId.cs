namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrunId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yapilacaks", "Urun_UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Faturalars", "Urun_UrunId", "dbo.Uruns");
            DropForeignKey("dbo.KargoDetays", "Urun_UrunId", "dbo.Uruns");
            DropIndex("dbo.Yapilacaks", new[] { "Urun_UrunId" });
            DropIndex("dbo.Faturalars", new[] { "Urun_UrunId" });
            DropIndex("dbo.KargoDetays", new[] { "Urun_UrunId" });
            RenameColumn(table: "dbo.Yapilacaks", name: "Urun_UrunId", newName: "UrunId");
            RenameColumn(table: "dbo.Faturalars", name: "Urun_UrunId", newName: "UrunId");
            RenameColumn(table: "dbo.KargoDetays", name: "Urun_UrunId", newName: "UrunId");
            AddColumn("dbo.KargoTakips", "UrunId", c => c.Int(nullable: false));
            AlterColumn("dbo.Yapilacaks", "UrunId", c => c.Int(nullable: false));
            AlterColumn("dbo.Faturalars", "UrunId", c => c.Int(nullable: false));
            AlterColumn("dbo.KargoDetays", "UrunId", c => c.Int(nullable: false));
            CreateIndex("dbo.Yapilacaks", "UrunId");
            CreateIndex("dbo.Faturalars", "UrunId");
            CreateIndex("dbo.KargoDetays", "UrunId");
            AddForeignKey("dbo.Yapilacaks", "UrunId", "dbo.Uruns", "UrunId", cascadeDelete: true);
            AddForeignKey("dbo.Faturalars", "UrunId", "dbo.Uruns", "UrunId", cascadeDelete: true);
            AddForeignKey("dbo.KargoDetays", "UrunId", "dbo.Uruns", "UrunId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KargoDetays", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Faturalars", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Yapilacaks", "UrunId", "dbo.Uruns");
            DropIndex("dbo.KargoDetays", new[] { "UrunId" });
            DropIndex("dbo.Faturalars", new[] { "UrunId" });
            DropIndex("dbo.Yapilacaks", new[] { "UrunId" });
            AlterColumn("dbo.KargoDetays", "UrunId", c => c.Int());
            AlterColumn("dbo.Faturalars", "UrunId", c => c.Int());
            AlterColumn("dbo.Yapilacaks", "UrunId", c => c.Int());
            DropColumn("dbo.KargoTakips", "UrunId");
            RenameColumn(table: "dbo.KargoDetays", name: "UrunId", newName: "Urun_UrunId");
            RenameColumn(table: "dbo.Faturalars", name: "UrunId", newName: "Urun_UrunId");
            RenameColumn(table: "dbo.Yapilacaks", name: "UrunId", newName: "Urun_UrunId");
            CreateIndex("dbo.KargoDetays", "Urun_UrunId");
            CreateIndex("dbo.Faturalars", "Urun_UrunId");
            CreateIndex("dbo.Yapilacaks", "Urun_UrunId");
            AddForeignKey("dbo.KargoDetays", "Urun_UrunId", "dbo.Uruns", "UrunId");
            AddForeignKey("dbo.Faturalars", "Urun_UrunId", "dbo.Uruns", "UrunId");
            AddForeignKey("dbo.Yapilacaks", "Urun_UrunId", "dbo.Uruns", "UrunId");
        }
    }
}
