using Assignment10_3.Models;
namespace Assignment10_3.Services {
    public interface ICRUD {

        List<Car> GetCars();
        Car? GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car changes);
        void DeleteCar(Car car);

    }
}
