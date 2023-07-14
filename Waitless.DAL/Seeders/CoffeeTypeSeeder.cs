using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class CoffeeTypeSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        #region Affogato

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 1,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 1,
            CoffeeTypeId = 1,
            LanguageId = 1,
            Name = "Affogato",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 2,
            CoffeeTypeId = 1,
            LanguageId = 2,
            Name = "Аффогато",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 3,
            CoffeeTypeId = 1,
            LanguageId = 3,
            Name = "Աֆֆոքատո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Americano

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 2,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 4,
            CoffeeTypeId = 2,
            LanguageId = 1,
            Name = "Americano",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 5,
            CoffeeTypeId = 2,
            LanguageId = 2,
            Name = "Американо",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 6,
            CoffeeTypeId = 2,
            LanguageId = 3,
            Name = "Ամերիկանո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Latte

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 3,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 7,
            CoffeeTypeId = 3,
            LanguageId = 1,
            Name = "Latte",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 8,
            CoffeeTypeId = 3,
            LanguageId = 2,
            Name = "Латте",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 9,
            CoffeeTypeId = 3,
            LanguageId = 3,
            Name = "Լատե",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Cappuccino

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 4,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 10,
            CoffeeTypeId = 4,
            LanguageId = 1,
            Name = "Cappuccino",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 11,
            CoffeeTypeId = 4,
            LanguageId = 2,
            Name = "Капучино",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 12,
            CoffeeTypeId = 4,
            LanguageId = 3,
            Name = "Կապուչինո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Mocha

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 5,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 13,
            CoffeeTypeId = 5,
            LanguageId = 1,
            Name = "Mocha",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 14,
            CoffeeTypeId = 5,
            LanguageId = 2,
            Name = "Моча",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 15,
            CoffeeTypeId = 5,
            LanguageId = 3,
            Name = "Մոչա",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Macchiato

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 6,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 16,
            CoffeeTypeId = 6,
            LanguageId = 1,
            Name = "Macchiato",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 17,
            CoffeeTypeId = 6,
            LanguageId = 2,
            Name = "Мачиато",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 18,
            CoffeeTypeId = 6,
            LanguageId = 3,
            Name = "Մաչիատո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Espresso

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 7,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 19,
            CoffeeTypeId = 7,
            LanguageId = 1,
            Name = "Espresso",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 20,
            CoffeeTypeId = 7,
            LanguageId = 2,
            Name = "Еспресо",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 21,
            CoffeeTypeId = 7,
            LanguageId = 3,
            Name = "Եսպրեսօ",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Decaf

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 8,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 22,
            CoffeeTypeId = 8,
            LanguageId = 1,
            Name = "Decaf",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 23,
            CoffeeTypeId = 8,
            LanguageId = 2,
            Name = "Декаф",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 24,
            CoffeeTypeId = 8,
            LanguageId = 3,
            Name = "Դեկաֆ",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Frappuccino

        modelBuilder.Entity<Models.CoffeeType>().HasData(new Models.CoffeeType
        {
            Id = 9,
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 25,
            CoffeeTypeId = 9,
            LanguageId = 1,
            Name = "Frappuccino",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 26,
            CoffeeTypeId = 9,
            LanguageId = 2,
            Name = "Фрапучино",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });
        modelBuilder.Entity<CoffeeTypeTranslation>().HasData(new CoffeeTypeTranslation
        {
            Id = 27,
            CoffeeTypeId = 9,
            LanguageId = 3,
            Name = "Ֆրապուփչինո",
            CreatedDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion
    }
}
