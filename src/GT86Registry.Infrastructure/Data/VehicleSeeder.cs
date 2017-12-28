using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Data
{
    /// <summary>
    /// Seeds the database with factual vehicle manufacturer, model, colors, etc.
    /// </summary>
    public class VehicleSeeder
    {
        private static int BRZ_MODEL_ID = 1;
        private static int FRS_MODEL_ID = 2;
        private static int GT86_MODEL_ID = 3;

        public static async Task SeedAsync(VehicleDbContext vehicleContext,
                UserManager<ApplicationUser> userManager,
                ILoggerFactory loggerFactory)
        {
            // Uncomment these two lines to delete and recreate the database
            //vehicleContext.Database.EnsureDeleted();
            //vehicleContext.Database.Migrate();
            // Create Manufacturers
            if (!vehicleContext.Manufacturers.Any())
            {
                vehicleContext.Manufacturers.AddRange(GetDefaultManufacturers());

                await vehicleContext.SaveChangesAsync();
            }

            // Create Vehicle Models
            if (!vehicleContext.VehicleModels.Any())
            {
                vehicleContext.VehicleModels.AddRange(GetDefaultVehicleModels());

                await vehicleContext.SaveChangesAsync();
            }

            // Create Model Years
            if (!vehicleContext.Years.Any())
            {
                vehicleContext.Years.AddRange(GetDefaultModelYears());

                await vehicleContext.SaveChangesAsync();
            }

            // Create Colors
            if (!vehicleContext.Colors.Any())
            {
                vehicleContext.Colors.AddRange(GetDefaultColors());

                await vehicleContext.SaveChangesAsync();
            }

            // Create ModelColor junction table records
            if (!vehicleContext.ColorYears.Any())
            {
                vehicleContext.ColorYears.AddRange(GetModelColorYears(vehicleContext));

                await vehicleContext.SaveChangesAsync();
            }

            // Create default transmissions
            if (!vehicleContext.Transmissions.Any())
            {
                vehicleContext.Transmissions.AddRange(GetTransmissions());

                await vehicleContext.SaveChangesAsync();
            }

            // Create Model_Transmission junction table records
            if (!vehicleContext.ModelTransmissions.Any())
            {
                vehicleContext.ModelTransmissions.AddRange(GetModelYearTransmissions(vehicleContext));

                await vehicleContext.SaveChangesAsync();
            }

            if (!vehicleContext.VehicleLocations.Any())
            {
                vehicleContext.VehicleLocations.AddRange(GetDefaultLocations());
                await vehicleContext.SaveChangesAsync();
            }

            if (!vehicleContext.Images.Any())
            {
                vehicleContext.Images.AddRange(GetDefaultProfilePhotoUri(userManager));
                await vehicleContext.SaveChangesAsync();
            }

            // Combine everything to create some test vehicles
            if (!vehicleContext.Vehicles.Any())
            {
                vehicleContext.Vehicles.AddRange(GetDefaultVehicles(vehicleContext, userManager));

                await vehicleContext.SaveChangesAsync();

            }
        }

        private static IEnumerable<Manufacturer> GetDefaultManufacturers()
        {
            var subaruStartDate = new DateTime(1953, 7, 15);
            var scionStartDate = new DateTime(2003, 6, 9);
            var scionEndDate = new DateTime(2016, 8, 5);
            var toyotaStartDate = new DateTime(1937, 8, 28);
            var nissanStartDate = new DateTime(1933, 12, 26);

            return new List<Manufacturer>()
            {
                new Manufacturer("Subaru", subaruStartDate, null),
                new Manufacturer("Scion", scionEndDate, scionEndDate),
                new Manufacturer("Toyota", toyotaStartDate, null),
                new Manufacturer("Nissan", nissanStartDate, null)
            };
        }

        private static IEnumerable<Model> GetDefaultVehicleModels()
        {
            return new List<Model>()
            {
                new Model("BRZ", 1),
                new Model("FR-S", 2),
                new Model("GT86", 3),
                new Model("240SX", 4)
            };
        }

        private static IEnumerable<ModelYear> GetDefaultModelYears()
        {
            var modelYears = new List<ModelYear>();

            // Subaru BRZ and Toyota GT86
            for (int year = 2013; year <= 2018; year++)
            {
                var brz = new ModelYear(year, 1);
                var gt86 = new ModelYear(year, 3);
                modelYears.Add(brz);
                modelYears.Add(gt86);
            }

            // Scion FR-S
            for (int year = 2013; year < 2017; year++)
            {
                var frs = new ModelYear(year, 2);
                modelYears.Add(frs);
            }

            return modelYears;
        }

        private static IEnumerable<Color> GetDefaultColors()
        {
            return new List<Color>()
            {
                // Scion / Toyota
                new Color("Ablaze", "M7Y"),
                new Color("Asphalt", "61K"),
                new Color("Argento", "D6S"),
                new Color("Firestorm", "C7P"),
                new Color("Halo", "K1X"),
                new Color("Hot Lava", "H8R"),
                new Color("Lunar Storm", "H6Q"),
                new Color("Oceanic", "K3X"),
                new Color("Raven", "D4S"),
                new Color("Silver Ignition", "J8A"),
                new Color("Steel", "G1U"),
                new Color("Ultramarine", "E8H"),
                new Color("Whiteout", "37J"),
                new Color("Yuzu", "C2Z"),
                new Color("Supernova", "NBB"),
                new Color("Thunder", "PBA"),
                // Subaru
                new Color("Charlesite Yellow", "NAD"),
                new Color("Crystal Black Silica", "D4S"),
                new Color("Crystal White Pearl", "K1X"),
                new Color("Dark Gray Metallic", "61K"),
                new Color("Galaxy Blue Silica", "E8H"),
                new Color("Hyper Blue", "M3Y"),
                new Color("Ice Silver Metallic", "G1U"),
                new Color("Lightning Red", "C7P"),
                new Color("Pure Red", "M7Y"),
                new Color("Satin White Pearl", "37J"),
                new Color("Sterling Silver Metallic", "D7S"),
                new Color("World Rally Blue Pearl", "02C"),
                new Color("World Rally Blue Pearl", "K7X")
            };
        }

        private static IEnumerable<ColorsModelYears> GetModelColorYears(VehicleDbContext vehicleContext)
        {
            return new List<ColorsModelYears>()
            {
                // Ablaze
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Asphalt
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Argento
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Firestorm
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Halo
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Hot Lava
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Lunar Storm
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H6Q").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Oceanic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K3X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K3X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Raven
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Silver Ignition
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "J8A").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Steel
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Ultramarine
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Whiteout
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // Yuzu
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C2Z").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == FRS_MODEL_ID).FirstOrDefault()
                    },
                // TOYOTA 86
                // Supernova Orange
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "NBB").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // Thunder
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "PBA").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2018 && y.ModelId == GT86_MODEL_ID).FirstOrDefault()
                    },
                // SUBARU
                // Charlesite Yellow
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "NAD").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Crystal Black Silica
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal Black Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal Black Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal Black Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal Black Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal Black Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Crystal Pearl White
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal White Pearl").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal White Pearl").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Crystal White Pearl").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Dark Gray Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Dark Gray Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Dark Gray Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Dark Gray Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Dark Gray Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Dark Gray Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Galaxy Blue Silica
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Galaxy Blue Silica").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Hyper Blue
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M3Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Ice Silver Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Ice Silver Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Ice Silver Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Ice Silver Metallic").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Lightning Red
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Lightning Red").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Lightning Red").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Lightning Red").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Pure Red
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Pure Red").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Pure Red").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Satin white pearl
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Satin White Pearl").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Name == "Satin White Pearl").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // Sterling Silver Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // World rally blue (02C)
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "02C").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "02C").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                // World rally blue (K7X)
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == BRZ_MODEL_ID).FirstOrDefault()
                    }
            };
        }

        private static IEnumerable<Transmission> GetTransmissions()
        {
            return new List<Transmission>()
            {
                new Transmission("6-Spd Manual"),
                new Transmission("6-Spd Automatic")
            };
        }

        private static IEnumerable<ModelTransmissions> GetModelYearTransmissions(VehicleDbContext vehicleContext)
        {
            List<ModelTransmissions> modelYearAndTransmissions = new List<ModelTransmissions>();

            // Fetch all the ModelYears
            var allModelYears = vehicleContext.Years.ToList();

            foreach (var year in allModelYears)
            {
                modelYearAndTransmissions.Add(new ModelTransmissions() { TransmissionId = 1, ModelYearId = year.Id });
                modelYearAndTransmissions.Add(new ModelTransmissions() { TransmissionId = 2, ModelYearId = year.Id });
            }

            return modelYearAndTransmissions;
        }

        private static IEnumerable<VehicleLocation> GetDefaultLocations()
        {
            return new List<VehicleLocation>()
            {
                new VehicleLocation(35.813453, -78.819194),
                new VehicleLocation(40.52, -111.87),
                new VehicleLocation(38.97, -76.50)
            };
        }

        private static IEnumerable<Image> GetDefaultProfilePhotoUri(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = userManager.FindByEmailAsync("testuser@gt86registry.com").Result;
            var defaultProfilePhoto = new Image
            {
                Uri = "https://i.imgur.com/8RuGLC6.jpg",
                UserIdentityGuid = defaultUser.Id
            };

            var frsUser = userManager.FindByEmailAsync("testfrs@gt86registry.com").Result;
            var frsProfilePhoto = new Image
            {
                Uri = "http://i.imgur.com/cHZgF.jpg",
                UserIdentityGuid = frsUser.Id
            };

            var gt86User = userManager.FindByEmailAsync("testgt86@gt86registry.com").Result;
            var gt86ProfilePhoto = new Image
            {
                Uri = "https://listings.tcimg.net/listings/5316/72/36/JF1ZNAA10H8703672/MIYAOIULAV4Z62Q4N2XOYFLS64-600.jpg",
                UserIdentityGuid = gt86User.Id
            };

            return new List<Image>()
            {
                defaultProfilePhoto,
                frsProfilePhoto,
                gt86ProfilePhoto
            };
        }

        private static IEnumerable<Vehicle> GetDefaultVehicles(VehicleDbContext vehicleContext, UserManager<ApplicationUser> userManager)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            var defaultUser = userManager.FindByEmailAsync("testuser@gt86registry.com").Result;
            var sampleBrz = new Vehicle("JF1ZCAC11E9603184")
            {
                ModelYearId = 3, // 2014 BRZ
                TransmissionId = 1, // 6-Spd Manual
                ColorId = 14, // World Rally Blue
                ProfilePhotoId = 1,
                VehicleLocationId = 1,
                UserIdentityGuid = defaultUser.Id,
                Description = "This is my first Subaru! I've always wanted a World Rally Blue vehicle and found a great deal on my BRZ. So far, I have a few mods, including Tein Coilovers, Perrin wheel spacers, Greddy axle-back exhaust and Phase2 Motortrend suspension arms.",
                Mileage = 57341
            };

            vehicles.Add(sampleBrz);

            var frsUser = userManager.FindByEmailAsync("testfrs@gt86registry.com").Result;
            var sampleFrs = new Vehicle("JF1ZNAA13E9709794")
            {
                ModelYearId = 14, // 2013 FRS
                TransmissionId = 1, // 6-Spd Manual
                ColorId = 3, // White
                VehicleLocationId = 2,
                ProfilePhotoId = 2,
                UserIdentityGuid = frsUser.Id,
                Description = "The FRS is such a fun car. I've been driving mine for 4 years now and still really love it. They're great cars.",
                Mileage = 21024
            };
            vehicles.Add(sampleFrs);

            var gt86User = userManager.FindByEmailAsync("testgt86@gt86registry.com").Result;
            var samplegt86 = new Vehicle("JF1ZNAA10H8703672")
            {
                ModelYearId = 10, // 2017 GT86
                TransmissionId = 1, // 6-Spd Manual
                ColorId = 1, // Ablaze
                VehicleLocationId = 3,
                ProfilePhotoId = 3,
                UserIdentityGuid = gt86User.Id,
                Description = "My GT86 is my first RWD vehicle. I've been taking it to drift events pretty often. My favorite thing about the 86 is the aftermarket selection. There are parts for days!",
                Mileage = 3765
            };
            vehicles.Add(samplegt86);

            return vehicles;
        }
    }
}