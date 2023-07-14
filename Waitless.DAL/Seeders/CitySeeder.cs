using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class CitySeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        List<string> cityNamesEnglish = new List<string>
        {
            "Yerevan", "Aparan", "Artashat", "Vanaadzor", "Gyumri", "Goris", "Hrazdan", "Kapan", "Masis", "Sebastia", "Stepanavan",
            "Abovyan", "Agharak", "Alaverdi", "Ashtarak", "Aparan", "Ararat", "Arats", "Armavir", "Arevmat", "Gavar", "Gyumri",
            "Dilijan", "Yeghegnadzor", "Yegvard", "Yeghegnik", "Yeveran", "Ejmiatsin", "Talin", "Tumanyan", "Tijvat", "Zhambarak", "Ijevan",
            "Lernamut", "Lori", "Khanakerd", "Tsaghkadzor", "Kapan", "Sisian", "Kanachar", "Kapanavan", "Kotayk", "Hrazdan", "Hrayravan",
            "Jamburak", "Masis", "Maralik", "Martakert", "Martuni", "Meghri", "United Armenia", "Moscow", "November", "New Jdeidah",
            "Shahumyan", "Shavarshen", "Shirak", "Shushi", "Sutis", "Sisian", "Syunik", "Stepanavan", "Stepanakert", "Stepanavan",
            "Sevan", "Tashir", "Tavush", "Kasakh", "Kaghakanysh"
        };

        List<string> cityNamesRussian = new List<string>
        {
            "Ереван", "Апаран", "Арташат", "Ванадзор", "Гюмри", "Горис", "Граздан", "Капан", "Масис", "Себастия", "Степанаван",
            "Абовян", "Агарак", "Алаверди", "Аштарак", "Апаран", "Арарат", "Аратс", "Армавир", "Аревмат", "Гавар", "Гюмри",
            "Дилижан", "Егегнадзор", "Егвард", "Егегник", "Еверан", "Эчмиадзин", "Талин", "Туманян", "Тийват", "Жамбарак", "Иджеван",
            "Лернамут", "Лори", "Ханакерт", "Цахкадзор", "Капан", "Сисиан", "Каначар", "Капанаван", "Котайк", "Граздан", "Грайраван",
            "Джамбурак", "Масис", "Маралик", "Мартакерт", "Мартуни", "Мегри", "Объединенная Армения", "Москва", "Ноябрь", "Новый Джейда",
            "Шахумян", "Шаваршен", "Ширак", "Шуши", "Сутис", "Сисиан", "Сюник", "Степанаван", "Степанакерт", "Степанаван",
            "Севан", "Ташир", "Тавуш", "Касах", "Кагаканиш"
        };

        List<string> cityNamesArm = new List<string>
        {
            "Երևան", "Ապարան", "Արթաշատ", "Վանաձոր", "Գյումրի", "Գորիս", "Հրազդան", "Քանաքեռավան", "Մարալիկ", "Սեբաստիա", "Ստեփանավան",
            "Աբովյան", "Ագարակ", "Ալավերդի", "Աշտարակ", "Ապարան", "Արարատ", "Արարած", "Արմավիր", "Արևամուտ", "Գավառ", "Գյումրի",
            "Դիլիջան", "Եղեգնաձոր", "Եղվարդ", "Եգեղեցիկ", "Եվերեան", "Էջմիածին", "Թալին", "Թումանյան", "Թիջուատ", "Ժամբարակ", "Իջևան",
            "Լեռնամուտ", "Լոռի", "Խանաքեռավան", "Ծաղկաձոր", "Կապան", "Կասախաղ", "Կանանցառ", "Կապանավան", "Կոտայք", "Հրազդան", "Հարավային Մարտունի",
            "Ճամբարակ", "Մասիս", "Մարալիկ", "Մարտակերտ", "Մարտունի", "Մեծամոր", "Միացյալ Հայաստան", "Մոսկվա", "Նոյեմբերյան", "Նոր Հաճըն",
            "Շահումյան", "Շավարշեն", "Շիրակ", "Շուշի", "Շուտիս", "Սիսիան", "Սյունիք", "Ստեփանավան", "Ստեփանակերտ", "Ստեփանավունի",
            "Սևան", "Տաշիր", "Տավուշ", "Քասախ", "Քաղաքանիշ"
        };
        int translationId = 0;
        for (int i = 0; i < cityNamesEnglish.Count; i++)
        {
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = i + 1,
                ProvinceId = (int)ProvinceEnum.Yerevan, // Replace with the appropriate province ID for each city
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
            });

            modelBuilder.Entity<CityTranslation>().HasData(new CityTranslation
            {
                Id = ++translationId,
                CityId = i + 1,
                LanguageId = 1,
                Name = cityNamesEnglish[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });

            modelBuilder.Entity<CityTranslation>().HasData(new CityTranslation
            {
                Id = ++translationId,
                CityId = i + 1,
                LanguageId = 2,
                Name = cityNamesRussian[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
            modelBuilder.Entity<CityTranslation>().HasData(new CityTranslation
            {
                Id = ++translationId,
                CityId = i + 1,
                LanguageId = 3,
                Name = cityNamesArm[i],
                CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
        }
    }
}
