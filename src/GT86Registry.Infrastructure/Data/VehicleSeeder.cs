using GT86Registry.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Data
{
    /// <summary>
    ///
    /// </summary>
    public class VehicleSeeder
    {
        public static async Task SeedAsync(VehicleDbContext vehicleContext, ILoggerFactory loggerFactory)
        {
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

            if (!vehicleContext.Transmissions.Any())
            {
                vehicleContext.Transmissions.AddRange(GetTransmissions());

                await vehicleContext.SaveChangesAsync();
            }

            if (!vehicleContext.ModelTransmissions.Any())
            {
                vehicleContext.ModelTransmissions.AddRange(GetModelYearTransmissions(vehicleContext));

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
            for (int year = 2013; year <= 2017; year++)
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
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Asphalt
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Argento
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                // Firestorm
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                // Halo
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Hot Lava
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H8R").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Lunar Storm
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "H6Q").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                // Oceanic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K3X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K3X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K3X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Raven
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Silver Ignition
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "J8A").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                // Steel
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Ultramarine
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                // Whiteout
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 2).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 2).FirstOrDefault()
                    },
                // Yuzu
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C2Z").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 2).FirstOrDefault()
                    },
                // TOYOTA 86
                // Supernova Orange
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "NBB").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 3).FirstOrDefault()
                    },
                // Thunder
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "PBA").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2018 && y.ModelId == 3).FirstOrDefault()
                    },
                // SUBARU
                // Charlesite Yellow
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "NAD").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Crystal Black Silica
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D4S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Crystal Pearl White
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K1X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Dark Gray Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "61K").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Galaxy Blue Silica
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "E8H").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                // Hyper Blue
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M3Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                // Ice Silver Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "G1U").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Lightning Red
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "C7P").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                // Pure Red
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "M7Y").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
                    },
                // Satin white pearl
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "37J").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                // Sterling Silver Metallic
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "D6S").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                // World rally blue (02C)
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "02C").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2013 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "02C").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2014 && y.ModelId == 1).FirstOrDefault()
                    },
                // World rally blue (K7X)
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2015 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2016 && y.ModelId == 1).FirstOrDefault()
                    },
                new ColorsModelYears() {
                    Color = vehicleContext.Colors.Where(c => c.Code == "K7X").FirstOrDefault(),
                    ModelYear = vehicleContext.Years.Where(y => y.Year == 2017 && y.ModelId == 1).FirstOrDefault()
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
    }
}