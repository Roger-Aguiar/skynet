using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skynet2.Migrations
{
    /// <inheritdoc />
    public partial class AddsFatherAndMotherFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mae",
                table: "Persons",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pai",
                table: "Persons",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mae",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Pai",
                table: "Persons");
        }
    }
}
