using Microsoft.EntityFrameworkCore;
using Waitless.DAL.Models;

namespace Waitless.DAL.Seeders
{
    internal static class ErrorSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 1,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Oops! Something wen't wrong"
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 2,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Not Authorized."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 3,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Error while authorizing."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 4,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "User Not Found."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 5,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "User with provided username already exists."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 6,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Entered data is not correct."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 7,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Item Not Found."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 8,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "The entered item already exists."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 9,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Error. This component cannot be deleted."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 10,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "The specified email address is already taken."
            });

            modelBuilder.Entity<Error>().HasData(new Error
            {
                Id = 11,
                CreatedDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifyDate = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false,
                Name = "Total error."
            });
        }
    }
}
