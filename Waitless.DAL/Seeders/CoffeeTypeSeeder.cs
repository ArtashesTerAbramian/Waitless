using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class CoffeeTypeSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        #region Affogato

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 1,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 1,
            BeverageTypeId = 1,
            LanguageId = 1,
            Name = "Affogato",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 2,
            BeverageTypeId = 1,
            LanguageId = 2,
            Name = "Аффогато",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 3,
            BeverageTypeId = 1,
            LanguageId = 3,
            Name = "Աֆֆոքատո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Americano

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 2,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 4,
            BeverageTypeId = 2,
            LanguageId = 1,
            Name = "Americano",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 5,
            BeverageTypeId = 2,
            LanguageId = 2,
            Name = "Американо",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 6,
            BeverageTypeId = 2,
            LanguageId = 3,
            Name = "Ամերիկանո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Latte

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 3,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 7,
            BeverageTypeId = 3,
            LanguageId = 1,
            Name = "Latte",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 8,
            BeverageTypeId = 3,
            LanguageId = 2,
            Name = "Латте",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 9,
            BeverageTypeId = 3,
            LanguageId = 3,
            Name = "Լատե",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Cappuccino

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 4,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 10,
            BeverageTypeId = 4,
            LanguageId = 1,
            Name = "Cappuccino",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 11,
            BeverageTypeId = 4,
            LanguageId = 2,
            Name = "Капучино",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 12,
            BeverageTypeId = 4,
            LanguageId = 3,
            Name = "Կապուչինո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Mocha

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 5,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 13,
            BeverageTypeId = 5,
            LanguageId = 1,
            Name = "Mocha",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 14,
            BeverageTypeId = 5,
            LanguageId = 2,
            Name = "Моча",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 15,
            BeverageTypeId = 5,
            LanguageId = 3,
            Name = "Մոչա",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Macchiato

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 6,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 16,
            BeverageTypeId = 6,
            LanguageId = 1,
            Name = "Macchiato",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 17,
            BeverageTypeId = 6,
            LanguageId = 2,
            Name = "Мачиато",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 18,
            BeverageTypeId = 6,
            LanguageId = 3,
            Name = "Մաչիատո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Espresso

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 7,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 19,
            BeverageTypeId = 7,
            LanguageId = 1,
            Name = "Espresso",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 20,
            BeverageTypeId = 7,
            LanguageId = 2,
            Name = "Еспресо",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 21,
            BeverageTypeId = 7,
            LanguageId = 3,
            Name = "Եսպրեսօ",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Decaf

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 8,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 22,
            BeverageTypeId = 8,
            LanguageId = 1,
            Name = "Decaf",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 23,
            BeverageTypeId = 8,
            LanguageId = 2,
            Name = "Декаф",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 24,
            BeverageTypeId = 8,
            LanguageId = 3,
            Name = "Դեկաֆ",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Frappuccino

        modelBuilder.Entity<Models.BeverageType>().HasData(new Models.BeverageType
        {
            Id = 9,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 25,
            BeverageTypeId = 9,
            LanguageId = 1,
            Name = "Frappuccino",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 26,
            BeverageTypeId = 9,
            LanguageId = 2,
            Name = "Фрапучино",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<BeverageTypeTranslation>().HasData(new BeverageTypeTranslation
        {
            Id = 27,
            BeverageTypeId = 9,
            LanguageId = 3,
            Name = "Ֆրապուփչինո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion
    }
}
