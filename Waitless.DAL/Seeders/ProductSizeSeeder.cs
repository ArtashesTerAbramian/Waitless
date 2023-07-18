using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class ProductSizeSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var englishValues = Enum.GetValues(typeof(ProductSizeEnum));
        var russianValues = new[] { "Маленький", "Средний", "Большой" };
        var armenianValues = new[] { "Փոքր", "Միջին", "Մեծ" };
        
        int translationId = 0;

        for (int i = 0; i < englishValues.Length; i++)
        {
            modelBuilder.Entity<ProductSize>().HasData(new ProductSize
            {
                Id = i + 1,
                SizeEnum = (ProductSizeEnum)englishValues.GetValue(i), // Replace with the appropriate province ID for each city
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
            });

            modelBuilder.Entity<ProductSizeTranslation>().HasData(new ProductSizeTranslation
            {
                Id = ++translationId,
                ProductSizeId = i + 1,
                LanguageId = 1,
                Size = englishValues.GetValue(i).ToString(),
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });

            modelBuilder.Entity<ProductSizeTranslation>().HasData(new ProductSizeTranslation
            {
                Id = ++translationId,
                ProductSizeId = i + 1,
                LanguageId = 2,
                Size = russianValues[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
            modelBuilder.Entity<ProductSizeTranslation>().HasData(new ProductSizeTranslation
            {
                Id = ++translationId,
                ProductSizeId = i + 1,
                LanguageId = 3,
                Size = armenianValues[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
        }
    }
}
