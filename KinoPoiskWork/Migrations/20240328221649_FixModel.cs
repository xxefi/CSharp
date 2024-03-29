using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoiskWork.Migrations
{
    /// <inheritdoc />
    public partial class FixModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "termsOfService",
                table: "Info");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "Info",
                newName: "actors");

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "Info");

            migrationBuilder.RenameColumn(
                name: "actors",
                table: "Info",
                newName: "version");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "termsOfService",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
