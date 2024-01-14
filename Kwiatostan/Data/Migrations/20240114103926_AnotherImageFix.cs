using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kwiatostan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnotherImageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "ImageFilename");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageFilename",
                value: "roza.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageFilename",
                value: "tulipan.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageFilename",
                value: "storczyk.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageFilename",
                value: "nawoz.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFilename",
                table: "Products",
                newName: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "C:\\Users\\tomek\\repos\\dotnet-mvc-flower-shop\\Kwiatostan\\wwwroot\\images\\roza.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "C:\\Users\\tomek\\repos\\dotnet-mvc-flower-shop\\Kwiatostan\\wwwroot\\images\\tulipan.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "C:\\Users\\tomek\\repos\\dotnet-mvc-flower-shop\\Kwiatostan\\wwwroot\\images\\storczyk.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "C:\\Users\\tomek\\repos\\dotnet-mvc-flower-shop\\Kwiatostan\\wwwroot\\images\\nawoz.jpg");
        }
    }
}
