using Microsoft.EntityFrameworkCore.Migrations;

namespace soft98.DataAccessLayer.Migrations
{
    public partial class banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Matlabs",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<string>(type: "nvarchar(23)", maxLength: 23, nullable: true),
                    ExpireDate = table.Column<string>(type: "nvarchar(23)", maxLength: 23, nullable: true),
                    PayPrice = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FollowNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsExpire = table.Column<bool>(type: "bit", nullable: false),
                    SeenNumber = table.Column<int>(type: "int", nullable: true),
                    PicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PicLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerFactors_Banners_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BannerFactors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerFactors_BannerId",
                table: "BannerFactors",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerFactors_UserId",
                table: "BannerFactors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerFactors");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Matlabs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23,
                oldNullable: true);
        }
    }
}
