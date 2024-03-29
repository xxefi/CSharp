using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoiskWork.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "Info");

            migrationBuilder.AddColumn<string>(
                name: "released",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "released",
                table: "Info");

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
