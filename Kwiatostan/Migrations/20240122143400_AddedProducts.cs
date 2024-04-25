using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kwiatostan.Migrations
{
    /// <inheritdoc />
    public partial class AddedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ImageFilename", "Price" },
                values: new object[,]
                {
                    { 1, "roza.jpg", 19.99m },
                    { 2, "tulipan.jpg", 14.99m },
                    { 3, null, 12.50m },
                    { 4, "storczyk.jpg", 29.99m },
                    { 5, "nawoz.jpg", 8.99m },
                    { 6, null, 24.99m },
                    { 7, "wstazka.jpg", 4.99m },
                    { 8, "papier.jpg", 1.99m },
                    { 9, "gozdzik_czerwony.jpg", 9.99m },
                    { 10, "gozdzik_rozowy.jpg", 9.99m },
                    { 11, "lilia.jpg", 15.99m },
                    { 12, "margaretka.jpg", 5.99m },
                    { 13, "slonecznik.jpg", 6.99m },
                    { 14, "galazki.jpg", 3.99m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Piękna czerwona róża, idealna na różne okazje.", "Róża czerwona", 112 },
                    { 2, 1, "Kolorowy tulipan, dodający świeżości i radości.", "Tulipan", 12 },
                    { 3, 2, null, "Fiołek doniczkowy", 44 },
                    { 4, 2, "Elegancki storczyk, który doda uroku każdemu pomieszczeniu.", "Storczyk", 0 },
                    { 5, 3, "Skuteczny nawóz do roślin, aby utrzymać je zdrowe i piękne.", "Nawóz do roślin", 150 },
                    { 6, 3, null, "Narzędzia ogrodnicze", 15 },
                    { 7, 4, "Urocza wstążka, idealna do ozdobienia bukietu.", "=Różowa Wstążka", 10 },
                    { 8, 4, "Klasyczny papier, idealny do ozdobienia bukietu.", "Papier ozdobny", 20 },
                    { 9, 1, "Czerwony goździk, dodający świeżości i radości.", "Goździk czerwony", 25 },
                    { 10, 1, "Różowy goździk, dodający świeżości i radości.", "Goździk różowy", 25 },
                    { 11, 1, "Dostojny, elegancki kwiat.", "Lilia", 5 },
                    { 12, 1, "Urocza margaretka, dodająca radości.", "Margaretka", 30 },
                    { 13, 1, "Urocza margaretka, dodająca radości.", "Słonecznik", 30 },
                    { 14, 4, "Zielone gałązki, idealnie otulają splecione w bukiet kwiaty.", "Ozdobne zielone gałązki", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
