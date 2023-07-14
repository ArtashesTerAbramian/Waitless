using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

internal static class ProvinceSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        #region Aragatsotn

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 1,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 1,
            LanguageId = 1,
            ProvinceId = 1,
            Name = "Aragatsotn region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 2,
            LanguageId = 2,
            ProvinceId = 1,
            Name = "Арагацотнская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 3,
            LanguageId = 3,
            ProvinceId = 1,
            Name = "Արագածոտնի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Ararat

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 2,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 4,
            LanguageId = 1,
            ProvinceId = 2,
            Name = "Ararat region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 5,
            LanguageId = 2,
            ProvinceId = 2,
            Name = "Араратская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 6,
            LanguageId = 3,
            ProvinceId = 2,
            Name = "Արարատյան մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Armavir

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 3,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 7,
            LanguageId = 1,
            ProvinceId = 3,
            Name = "Armavir region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 8,
            LanguageId = 2,
            ProvinceId = 3,
            Name = "Армавирская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 9,
            LanguageId = 3,
            ProvinceId = 3,
            Name = "Արմավիրի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Yerevan

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 4,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 10,
            LanguageId = 1,
            ProvinceId = 4,
            Name = "Yerevan",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 11,
            LanguageId = 2,
            ProvinceId = 4,
            Name = "Ереван",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 12,
            LanguageId = 3,
            ProvinceId = 4,
            Name = "Երեվան",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Vayots Dzor

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 5,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 13,
            LanguageId = 1,
            ProvinceId = 5,
            Name = "Vayots Dzor region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 14,
            LanguageId = 2,
            ProvinceId = 5,
            Name = "Вайоцдзорская бласть",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 15,
            LanguageId = 3,
            ProvinceId = 5,
            Name = "Վայոց Ձորի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Gegharkunik

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 6,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 16,
            LanguageId = 1,
            ProvinceId = 6,
            Name = "Gegharkunik region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 17,
            LanguageId = 2,
            ProvinceId = 6,
            Name = "Гехаркуникская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 18,
            LanguageId = 3,
            ProvinceId = 6,
            Name = "Գեղարքունիքի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Kotayk

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 7,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 19,
            LanguageId = 1,
            ProvinceId = 7,
            Name = "Kotayk region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 20,
            LanguageId = 2,
            ProvinceId = 7,
            Name = "Котайкская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 21,
            LanguageId = 3,
            ProvinceId = 7,
            Name = "Կոտայքի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Lori

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 8,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 22,
            LanguageId = 1,
            ProvinceId = 8,
            Name = "Lori region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 23,
            LanguageId = 2,
            ProvinceId = 8,
            Name = "Лорийская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 24,
            LanguageId = 3,
            ProvinceId = 8,
            Name = "Լոռու մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Shirak

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 9,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 25,
            LanguageId = 1,
            ProvinceId = 9,
            Name = "Shirak region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 26,
            LanguageId = 2,
            ProvinceId = 9,
            Name = "Ширакская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 27,
            LanguageId = 3,
            ProvinceId = 9,
            Name = "Շիրակի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Tavush

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 10,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 28,
            LanguageId = 1,
            ProvinceId = 10,
            Name = "Tavush region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 29,
            LanguageId = 2,
            ProvinceId = 10,
            Name = "Тавушская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 30,
            LanguageId = 3,
            ProvinceId = 10,
            Name = "Տավուշի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion

        #region Syunik

        modelBuilder.Entity<Province>().HasData(new Province()
        {
            Id = 11,
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 31,
            LanguageId = 1,
            ProvinceId = 11,
            Name = "Syunik region",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 32,
            LanguageId = 2,
            ProvinceId = 11,
            Name = "Сюникская область",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        modelBuilder.Entity<ProvinceTranslation>().HasData(new ProvinceTranslation()
        {
            Id = 33,
            LanguageId = 3,
            ProvinceId = 11,
            Name = "Սյունիքի մարզ",
            CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false,
        });

        #endregion
    }
}
