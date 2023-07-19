using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waitless.DAL.Models;

namespace Waitless.DAL.Seeders;

internal class AddressSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().HasData(new Address()
        {
            Id = 1,
            CityId = 1, // Yerevan
            PostalCode = "0002",
            CreatedDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false
        });

        modelBuilder.Entity<AddressTranslation>().HasData(new AddressTranslation()
        {
            Id = 1,
            LanguageId = 1, // English
            AddressId = 1,
            Street = "21 Mesrop Mashtots Ave",
            CreatedDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false
        });

        modelBuilder.Entity<AddressTranslation>().HasData(new AddressTranslation()
        {
            Id = 2,
            LanguageId = 2, // Russian
            AddressId = 1,
            Street = "пр. Месропа Маштоца 21",
            CreatedDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false
        });

        modelBuilder.Entity<AddressTranslation>().HasData(new AddressTranslation()
        {
            Id = 3,
            LanguageId = 3, // Armenian
            AddressId = 1,
            Street = "21 Մեսրոպ Մաշտոց պողոտա",
            CreatedDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ModifyDate = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            IsDeleted = false
        });

    }
}
