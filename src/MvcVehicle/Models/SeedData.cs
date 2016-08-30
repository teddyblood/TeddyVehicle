using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcVehicle.Data;


namespace MvcVehicle.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Vehicle.Any())
                {
                    return;   // DB has been seeded
                }

                context.Vehicle.AddRange(
                     new Vehicle
                     {
                         CarModel = "Freed",
                         EGsize = 1500,
                         Maker = "Honda",
                         SOP = DateTime.Parse("2011-05"),
                         Transmission = "Automatic",
                         Hybrid = "No"
                     },
                     new Vehicle
                     {
                         CarModel = "Grace",
                         EGsize = 1800,
                         Maker = "Honda",
                         SOP = DateTime.Parse("2008-09"),
                         Transmission = "Manual",
                         Hybrid = "No"

                     },
                     new Vehicle
                     {
                         CarModel = "Insight",
                         EGsize = 2200,
                         Maker = "Honda",
                         SOP = DateTime.Parse("2015-01"),
                         Transmission = "Automatic",
                         Hybrid = "FHEV"

                     }
                );
                context.SaveChanges();
            }
        }
    }
}