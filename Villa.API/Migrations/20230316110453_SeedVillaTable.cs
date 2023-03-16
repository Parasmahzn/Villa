using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This 6-storey townhouse is located in Nanshan District, Shenzhen, surrounded by lakes and dense forests. It enables owners to take a journey to Shenzhen Bay and the South China Sea right from their front door.\r\n\r\nDrawing on various artworks of both Chinese and foreign masters of art, the designers mix Eastern elegance or Western aesthetics, Chinese charm or French classics, colourful ink or black and white minimalism, to infuse the space with different artistic spirits, making the space not only skillfully crafted but also rhythmical.The butterfly art installation is motivated by artist Zhou Li's \"Metamorphosis,\" which uses traditional weaving techniques to produce flexible wire in a form that is light and dynamic, like a butterfly escaping from its cocoon and illustrating the tension of rebirth.", "https://amazingarchitecture.com/storage/3816/responsive-images/1-shenzhen_lakeside_villa_ace_design___media_library_original_1344_756.jpg", "Shenzhen Lakeside Villa", 30, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep Villa speaks of modernity and globalization, demonstrating the absorption of modern influences from the West ,the more recent processes of globalization but also their sensitivity to the physical environment, the social context and the aspirations of the urban classes.", "https://amazingarchitecture.com/storage/711/responsive-images/Deep-Villa-Atrey-and-Associates-New-Delhi-ndia-Amazing-Architecture-House___media_library_original_1386_924.jpg", "Deep Villa", 60, 800.0, 464, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The main idea for this beautiful villa project was to create a peaceful, luxury, modern and bright environment, where each space is cozy and tranquil. The rooms are very airy and full of light all day long, while once the sun goes down, each area gets its relaxing and romantic feel.", "https://amazingarchitecture.com/storage/3411/responsive-images/1-dubai_hills_villa_shawa_architecture___media_library_original_1344_756.jpg", "Iconic Dubai Hills Villa", 30, 500.0, 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Various elements from architecture through the ages and cultures have been an inspiration for the design of this villa. The entrance is an inspiration from the “GATES OF HEAVEN “ in Bali and the foyer is an influence from Geoffrey Bawa’s houses in Sri Lanka with a green space creating a completely natural setting by bringing natural light into the foyer through a semi-covered shade above the green pocket. The pitched roof pavilion gives the user an experience of Balinese architecture. This home is an attempt to explore the blend of traditional and contemporary interiors.", "https://amazingarchitecture.com/storage/2989/responsive-images/villa_79_ace_associates_karamsad_india___media_library_original_1344_756.jpg", "Villa 79", 79, 1200.0, 1011, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
