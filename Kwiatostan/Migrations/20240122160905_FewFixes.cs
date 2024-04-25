using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kwiatostan.Migrations
{
    /// <inheritdoc />
    public partial class FewFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Różowa Wstążka");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "=Różowa Wstążka");
        }
    }
}
