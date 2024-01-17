using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kwiatostan.Data.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ulica",
                table: "Address",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "NumerMieszkania",
                table: "Address",
                newName: "ApartmentNumber");

            migrationBuilder.RenameColumn(
                name: "NumerBudynku",
                table: "Address",
                newName: "BuildingNumber");

            migrationBuilder.RenameColumn(
                name: "Miasto",
                table: "Address",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "KodPocztowy",
                table: "Address",
                newName: "PostalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "Ulica");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Address",
                newName: "KodPocztowy");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "Miasto");

            migrationBuilder.RenameColumn(
                name: "BuildingNumber",
                table: "Address",
                newName: "NumerBudynku");

            migrationBuilder.RenameColumn(
                name: "ApartmentNumber",
                table: "Address",
                newName: "NumerMieszkania");
        }
    }
}
