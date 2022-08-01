namespace Elearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCatergorytoplaylist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lectures", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Lectures", new[] { "CategoryId" });
            AddColumn("dbo.Playlists", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Playlists", "CategoryId");
            AddForeignKey("dbo.Playlists", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Lectures", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lectures", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Playlists", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Playlists", new[] { "CategoryId" });
            DropColumn("dbo.Playlists", "CategoryId");
            CreateIndex("dbo.Lectures", "CategoryId");
            AddForeignKey("dbo.Lectures", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
