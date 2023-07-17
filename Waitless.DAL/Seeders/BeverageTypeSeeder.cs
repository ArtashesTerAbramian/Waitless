using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Waitless.DAL.Enums;

namespace Waitless.DAL.Seeders
{
    public class BeverageTypeSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var beverageTypeNamesEnglish = Enum.GetValues(typeof(BeverageTypeEnum));

            List<string> beverageTypeNamesRussian = new List<string>
            {
                "Кофе", "Чай", "Смузи", "Лимонад", "Сок"
            };

            List<string> beverageTypeNamesArmenian = new List<string>
            {
                "Սուրճ", "Թեյ", "Սմուզի", "Լիմոնադ", "Ջուս"
            };

            int translationId = 0;
            for (int i = 0; i < beverageTypeNamesEnglish.Length; i++)
            {
                modelBuilder.Entity<BeverageType>().HasData(new BeverageType
                {
                    Id = i + 1,
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
                {
                    Id = ++translationId,
                    BeverageTypeId = i + 1,
                    LanguageId = 1,
                    Name = beverageTypeNamesEnglish.GetValue(i).ToString(),
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
                {
                    Id = ++translationId,
                    BeverageTypeId = i + 1,
                    LanguageId = 2,
                    Name = beverageTypeNamesRussian[i],
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });

                modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
                {
                    Id = ++translationId,
                    BeverageTypeId = i + 1,
                    LanguageId = 3,
                    Name = beverageTypeNamesArmenian[i],
                    CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false,
                });
            }
        }
    }
}
