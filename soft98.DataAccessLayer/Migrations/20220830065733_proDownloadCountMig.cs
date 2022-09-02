using Microsoft.EntityFrameworkCore.Migrations;

namespace soft98.DataAccessLayer.Migrations
{
    public partial class proDownloadCountMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DownloadCount",
                table: "ProductDownloadFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "ProductDownloadFiles");
        }
    }
}
