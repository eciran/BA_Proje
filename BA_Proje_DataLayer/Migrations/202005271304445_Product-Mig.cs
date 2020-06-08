using System.ComponentModel.DataAnnotations;
namespace BA_Proje_DataLayer.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class ProductMig : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Product", "tbl_Deneme", c => c.String(nullable: false, defaultValue: ""));
		}

		public override void Down()
		{
		
		}
	}
}

