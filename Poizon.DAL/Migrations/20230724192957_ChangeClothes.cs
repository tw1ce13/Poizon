using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poizon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeClothes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo1",
                table: "Clothes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo2",
                table: "Clothes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo3",
                table: "Clothes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo4",
                table: "Clothes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo5",
                table: "Clothes",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo1",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Photo3",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Photo4",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Photo5",
                table: "Clothes");
        }
    }
}
