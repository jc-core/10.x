using System.ComponentModel.DataAnnotations;
namespace Assignment10_3.Models {
    public class Car {

        [Key]
        public int CarId { get; set; }
        public string VIN { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }

    }
}
