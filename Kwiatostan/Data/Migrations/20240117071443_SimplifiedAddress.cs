using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kwiatostan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SimplifiedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imię",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "NumerBudynku",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumerMieszkania",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumerBudynku",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "NumerMieszkania",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Imię",
                table: "Address",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Address",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
