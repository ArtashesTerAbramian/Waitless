using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Waitless.DAL.Enums;

namespace Waitless.DAL.Seeders
{
    public class ProductTypeSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var productTypeNamesEnglish = Enum.GetValues(typeof(ProductTypeEnum));

            List<string> productTypeNamesRussian = new List<string>
            {
                "Кофе", "Чай", "Смузи", "Лимонад", "Сок"
            };

            List<string> productTypeNamesArmenian = new List<string>
            {
                "Սուրճ", "Թեյ", "Սմուզի", "Լիմոնադ", "Ջուս"
            };

            int translationId = 0;
            for (int i = 0; i < productTypeNamesEnglish.Length; i++)
            {
                modelBuilder.Entity<ProductType>().HasData(new ProductType
                {
                    Id = i + 1,
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<ProductTypeTranslation>().HasData(new ProductTypeTranslation
                {
                    Id = ++translationId,
                    ProductTypeId = i + 1,
                    LanguageId = 1,
                    Name = productTypeNamesEnglish.GetValue(i).ToString(),
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<ProductTypeTranslation>().HasData(new ProductTypeTranslation
                {
                    Id = ++translationId,
                    ProductTypeId = i + 1,
                    LanguageId = 2,
                    Name = productTypeNamesRussian[i],
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<ProductTypeTranslation>().HasData(new ProductTypeTranslation
                {
                    Id = ++translationId,
                    ProductTypeId = i + 1,
                    LanguageId = 3,
                    Name = productTypeNamesArmenian[i],
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });
            }
        }
    }
}
