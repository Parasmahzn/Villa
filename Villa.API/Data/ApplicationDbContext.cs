using Microsoft.EntityFrameworkCore;
using Villa.API.Models;

namespace Villa.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<VillaModel> Villas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VillaModel>().HasData
            (
            new VillaModel()
            {
                Id = 1,
                Name = "Shenzhen Lakeside Villa",
                Details = "This 6-storey townhouse is located in Nanshan District, Shenzhen, surrounded by lakes and dense forests. It enables owners to take a journey to Shenzhen Bay and the South China Sea right from their front door.\r\n\r\nDrawing on various artworks of both Chinese and foreign masters of art, the designers mix Eastern elegance or Western aesthetics, Chinese charm or French classics, colourful ink or black and white minimalism, to infuse the space with different artistic spirits, making the space not only skillfully crafted but also rhythmical.The butterfly art installation is motivated by artist Zhou Li's \"Metamorphosis,\" which uses traditional weaving techniques to produce flexible wire in a form that is light and dynamic, like a butterfly escaping from its cocoon and illustrating the tension of rebirth.",
                ImageUrl = "https://amazingarchitecture.com/storage/3816/responsive-images/1-shenzhen_lakeside_villa_ace_design___media_library_original_1344_756.jpg",
                Occupancy = 30,
                Rate = 200,
                Sqft = 550,
                Amenity = string.Empty,
                CreatedDate = DateTime.Now,
            },
            new VillaModel()
            {
                Id = 2,
                Name = "Deep Villa",
                Details = "Deep Villa speaks of modernity and globalization, demonstrating the absorption of modern influences from the West ,the more recent processes of globalization but also their sensitivity to the physical environment, the social context and the aspirations of the urban classes.",
                ImageUrl = "https://amazingarchitecture.com/storage/711/responsive-images/Deep-Villa-Atrey-and-Associates-New-Delhi-ndia-Amazing-Architecture-House___media_library_original_1386_924.jpg",
                Occupancy = 60,
                Rate = 800,
                Sqft = 464,
                Amenity = string.Empty,
                CreatedDate = DateTime.Now,
            },
            new VillaModel()
            {
                Id = 3,
                Name = "Iconic Dubai Hills Villa",
                Details = "The main idea for this beautiful villa project was to create a peaceful, luxury, modern and bright environment, where each space is cozy and tranquil. The rooms are very airy and full of light all day long, while once the sun goes down, each area gets its relaxing and romantic feel.",
                ImageUrl = "https://amazingarchitecture.com/storage/3411/responsive-images/1-dubai_hills_villa_shawa_architecture___media_library_original_1344_756.jpg",
                Occupancy = 30,
                Rate = 500,
                Sqft = 164,
                Amenity = string.Empty,
                CreatedDate = DateTime.Now,
            },
            new VillaModel()
            {
                Id = 4,
                Name = "Villa 79",
                Details = "Various elements from architecture through the ages and cultures have been an inspiration for the design of this villa. The entrance is an inspiration from the “GATES OF HEAVEN “ in Bali and the foyer is an influence from Geoffrey Bawa’s houses in Sri Lanka with a green space creating a completely natural setting by bringing natural light into the foyer through a semi-covered shade above the green pocket. The pitched roof pavilion gives the user an experience of Balinese architecture. This home is an attempt to explore the blend of traditional and contemporary interiors.",
                ImageUrl = "https://amazingarchitecture.com/storage/2989/responsive-images/villa_79_ace_associates_karamsad_india___media_library_original_1344_756.jpg",
                Occupancy = 79,
                Rate = 1200,
                Sqft = 1011,
                Amenity = string.Empty,
                CreatedDate = DateTime.Now,
            }
            );
    }
}
