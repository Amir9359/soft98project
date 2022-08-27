using Microsoft.EntityFrameworkCore.Migrations;

namespace soft98.DataAccessLayer.Migrations
{
    public partial class MatlabMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matlabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    NumberSeen = table.Column<int>(type: "int", nullable: true),
                    IsSoft = table.Column<bool>(type: "bit", nullable: false),
                    IsMobile = table.Column<bool>(type: "bit", nullable: false),
                    IsTech = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matlabs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matlabs");
        }
    }
}
