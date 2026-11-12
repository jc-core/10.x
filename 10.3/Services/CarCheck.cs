using Assignment10_3.Models;
namespace Assignment10_3.Services {
    public static class CarCheck {

        public static string Problem(Car car, List<Car> stock) {

            if (car.VIN.Trim().Length != 17)
                return "VIN has to be 17 characters.";
            if (stock.Any(other => other.CarId != car.CarId && other.VIN.Equals(car.VIN.Trim(), StringComparison.OrdinalIgnoreCase)))
                return "Another car already has that VIN.";
            if (car.Make.Trim() == "" || car.Model.Trim() == "")
                return "Make and model can't be blank.";
            if (car.Year < 1900 || car.Year > DateTime.Now.Year + 1)
                return $"Year has to be from 1900 to {DateTime.Now.Year + 1}.";
            if (car.Mileage < 0)
                return "Mileage can't be negative.";
            if (car.Price <= 0)
                return "Price has to be more than 0.";

            return "";

        }

        public static void Tidy(Car car) {
            car.VIN = car.VIN.Trim().ToUpper();
            car.Make = car.Make.Trim();
            car.Model = car.Model.Trim();
        }
    }
}
