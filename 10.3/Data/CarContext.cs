using Assignment10_3.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment10_3.Data {
    public class CarContext : DbContext {

        public DbSet<Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Car>().Property(car => car.Price).HasPrecision(10, 2).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.Year).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.Mileage).IsRequired();
            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, VIN = "1HGCV1F34LA012345", Make = "Honda", Model = "Accord", Year = 2020, Mileage = 41200, Price = 21500m },
                new Car { CarId = 2, VIN = "4T1B11HK5KU678901", Make = "Toyota", Model = "Camry", Year = 2019, Mileage = 55800, Price = 19250m },
                new Car { CarId = 3, VIN = "1FTFW1E50MFA23456", Make = "Ford", Model = "F-150", Year = 2021, Mileage = 30400, Price = 34900m },
                new Car { CarId = 4, VIN = "5YJ3E1EA7NF789012", Make = "Tesla", Model = "Model 3", Year = 2022, Mileage = 18700, Price = 29800m },
                new Car { CarId = 5, VIN = "3VWC57BU2KM345678", Make = "Volkswagen", Model = "Jetta", Year = 2019, Mileage = 62100, Price = 14600m }
            );

        }
    }
}
