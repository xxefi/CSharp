using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoPoiskWork.Migrations
{
    /// <inheritdoc />
    public partial class Fix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ratings",
                table: "Info");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ratings",
                table: "Info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
