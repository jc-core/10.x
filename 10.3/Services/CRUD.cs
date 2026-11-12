using Assignment10_3.Data;
using Assignment10_3.Models;
namespace Assignment10_3.Services {
    public class CRUD : ICRUD {

        private CarContext _carContext;

        public CRUD(CarContext carContext) {
            _carContext = carContext;
        }

        public List<Car> GetCars() {
            return _carContext.Cars.OrderBy(car => car.CarId).ToList();
        }

        public Car? GetCarById(int id) {
            return _carContext.Cars.Find(id);
        }

        public void AddCar(Car car) {
            _carContext.Cars.Add(car);
            _carContext.SaveChanges();
        }

        public void UpdateCar(Car changes) {

            Car? stored = _carContext.Cars.Find(changes.CarId);
            if (stored == null)
                return;

            stored.VIN = changes.VIN;
            stored.Make = changes.Make;
            stored.Model = changes.Model;
            stored.Year = changes.Year;
            stored.Mileage = changes.Mileage;
            stored.Price = changes.Price;
            _carContext.SaveChanges();

        }

        public void DeleteCar(Car car) {
            _carContext.Cars.Remove(car);
            _carContext.SaveChanges();
        }
    }
}
