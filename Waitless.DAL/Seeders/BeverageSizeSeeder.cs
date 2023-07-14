using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class BeverageSizeSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var englishValues = Enum.GetValues(typeof(BeverageSizeEnum));
        var russianValues = new[] { "Маленький", "Средний", "Большой" };
        var armenianValues = new[] { "Փոքր", "Միջին", "Մեծ" };
        
        int translationId = 0;

        for (int i = 0; i < englishValues.Length; i++)
        {
            modelBuilder.Entity<BeverageSize>().HasData(new BeverageSize
            {
                Id = i + 1,
                SizeEnum = (BeverageSizeEnum)englishValues.GetValue(i), // Replace with the appropriate province ID for each city
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
            });

            modelBuilder.Entity<BeverageSizeTranslation>().HasData(new BeverageSizeTranslation
            {
                Id = ++translationId,
                BeverageSizeId = i + 1,
                LanguageId = 1,
                Size = englishValues.GetValue(i).ToString(),
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });

            modelBuilder.Entity<BeverageSizeTranslation>().HasData(new BeverageSizeTranslation
            {
                Id = ++translationId,
                BeverageSizeId = i + 1,
                LanguageId = 2,
                Size = russianValues[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
            modelBuilder.Entity<BeverageSizeTranslation>().HasData(new BeverageSizeTranslation
            {
                Id = ++translationId,
                BeverageSizeId = i + 1,
                LanguageId = 3,
                Size = armenianValues[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
        }
    }
}
