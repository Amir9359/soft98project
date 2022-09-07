using Microsoft.EntityFrameworkCore.Migrations;

namespace soft98.DataAccessLayer.Migrations
{
    public partial class dateBannerMigrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RentDate",
                table: "BannerFactors",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpireDate",
                table: "BannerFactors",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RentDate",
                table: "BannerFactors",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpireDate",
                table: "BannerFactors",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
