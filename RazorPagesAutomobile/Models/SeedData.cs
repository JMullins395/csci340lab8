using Microsoft.EntityFrameworkCore;
using RazorPagesAutomobile.Data;

namespace RazorPagesAutomobile.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesAutomobileContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesAutomobileContext>>()))
        {
            if (context == null || context.Automobile == null)
            {
                throw new ArgumentNullException("Null RazorPagesAutomobileContext");
            }

            // Look for any automobiles.
            if (context.Automobile.Any())
            {
                return;   // DB has been seeded
            }

            context.Automobile.AddRange(
                new Automobile
                {
                    Make = "Ford",
                    Model = "Mustang",
                    ReleaseDate = DateTime.Parse("1964-3-9"),
                    MSRP = 2368
                },

                new Automobile
                {
                    Make = "Toyota",
                    Model = "Corolla",
                    ReleaseDate = DateTime.Parse("1966-11-3"),
                    MSRP = 1250
                },

                new Automobile
                {
                    Make = "Honda",
                    Model = "Civic",
                    ReleaseDate = DateTime.Parse("1972-7-11"),
                    MSRP = 2073
                },

                new Automobile
                {
                    Make = "Subaru",
                    Model = "Impreza",
                    ReleaseDate = DateTime.Parse("1992-11-8"),
                    MSRP = 14000
                }
            );
            context.SaveChanges();
        }
    }
}