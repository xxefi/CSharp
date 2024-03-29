using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoiskWork.Migrations
{
    /// <inheritdoc />
    public partial class Fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "language",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ratings",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "runtime",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "language",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "ratings",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "runtime",
                table: "Info");
        }
    }
}
