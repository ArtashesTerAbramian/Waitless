using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Waitless.DAL.Seeders;

public class UserSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        string passwordHash = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=";

        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            UserName = "admin",
            PasswordHash = passwordHash,
            Email = "admin@mail.com",
            Phone = "32423",
            ActivationToken = default,
            IsActive = false
        });
    }
}