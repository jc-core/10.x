using Assignment10_3.Models;
using Assignment10_3.Services;
using System.Windows;
using System.Windows.Controls;
namespace Assignment10_3 {
    public partial class MainWindow : Window {

        ICRUD crud;
        Car formCar = new Car();

        public MainWindow(ICRUD _crud) {

            InitializeComponent();
            crud = _crud;
            CarGrid.ItemsSource = crud.GetCars();
            ResetForm();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {

            if (!ReadyToSave(formCar))
                return;

            if (formCar.CarId == 0) {
                crud.AddCar(formCar);
                MessageBox.Show($"{formCar.Year} {formCar.Make} {formCar.Model} added.");
            }
            else {
                crud.UpdateCar(formCar);
                MessageBox.Show($"Car #{formCar.CarId} updated.");
            }

            CarGrid.ItemsSource = crud.GetCars();
            ResetForm();

        }

        private void EditCar(object sender, RoutedEventArgs e) {

            if ((sender as FrameworkElement)?.DataContext is not Car picked)
                return;

            formCar = new Car {
                CarId = picked.CarId, VIN = picked.VIN, Make = picked.Make, Model = picked.Model,
                Year = picked.Year, Mileage = picked.Mileage, Price = picked.Price
            };
            CarFormGrid.DataContext = formCar;
            lblForm.Content = $"Edit Car #{formCar.CarId}";
            btnSave.Content = "Update";
            btnCancel.Visibility = Visibility.Visible;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            ResetForm();
        }

        private void DeleteCar(object sender, RoutedEventArgs e) {

            if ((sender as FrameworkElement)?.DataContext is not Car car)
                return;

            MessageBoxResult answer = MessageBox.Show($"Delete the {car.Year} {car.Make} {car.Model}?", "Delete",
                                                      MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer != MessageBoxResult.Yes)
                return;

            if (formCar.CarId == car.CarId)
                ResetForm();

            crud.DeleteCar(car);
            CarGrid.ItemsSource = crud.GetCars();

        }

        private bool ReadyToSave(Car car) {

            foreach (object child in CarFormGrid.Children) {
                if (child is TextBox box && Validation.GetHasError(box)) {
                    MessageBox.Show("Year, mileage and price have to be numbers.");
                    return false;
                }
            }

            string problem = CarCheck.Problem(car, crud.GetCars());
            if (problem != "") {
                MessageBox.Show(problem);
                return false;
            }

            CarCheck.Tidy(car);
            return true;

        }

        private void ResetForm() {
            formCar = new Car();
            CarFormGrid.DataContext = formCar;
            lblForm.Content = "Add Car";
            btnSave.Content = "Add";
            btnCancel.Visibility = Visibility.Collapsed;
        }
    }
}
