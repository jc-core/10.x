using static Assignment10_2.TextFuncs;
using static Assignment10_2.QueryFuncs;
namespace Assignment10_2 {
    internal class Program {

        static void Main(string[] args) {

        startLoop:

            switch (ReadChoice("(1) Positives  (2) Employees  (3) City letters  (4) Over 80  (5) Next letter:")) {
                case "1":
                    RunPositives();
                    break;
                case "2":
                    RunEmployees();
                    break;
                case "3":
                    RunCities();
                    break;
                case "4":
                    RunOverCheck();
                    break;
                case "5":
                    RunNextLetter();
                    break;
                default:
                    Console.WriteLine("No input, try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("...");
            Console.ReadKey(true);
            Console.Clear();

            goto startLoop;

        }

        static void RunPositives() {

            Console.WriteLine("Whole numbers, separated by spaces. Negatives allowed.");

            if (ReadNumbers("Numbers:") is not int[] numbers) {
                Console.WriteLine("No input, try again.");
                return;
            }

            ShowNumbers("Above zero:", Positives(numbers));

        }

        static void RunEmployees() {

            List<Employee> employees = new() {
                new Employee { Name = "Harold Linzer", Age = 26, Salary = 6200 },
                new Employee { Name = "Delia Morose", Age = 34, Salary = 7100 },
                new Employee { Name = "Patricia Hartman", Age = 23, Salary = 4800 },
                new Employee { Name = "Timothy Beckham", Age = 29, Salary = 5400 },
                new Employee { Name = "Alicia Greunzig", Age = 41, Salary = 3900 },
                new Employee { Name = "Kelly Solis", Age = 30, Salary = 5800 },
                new Employee { Name = "Rosalin Jacobs", Age = 27, Salary = 5000 }
            };

            Console.WriteLine("Staff list:");
            foreach (Employee employee in employees)
                Console.WriteLine($"  {employee.Name}, {employee.Age}, ${employee.Salary}");

            Console.WriteLine();
            Console.WriteLine("Over $5000 and under 30:");
            foreach (Employee employee in FilterEmployees(employees))
                Console.WriteLine($"  {employee.Name}, {employee.Age}, ${employee.Salary}");

        }

        static void RunCities() {

            string[] cities = { "Atlanta", "Austin", "Boston", "Baltimore", "Denver", "Dallas",
                                "Miami", "Memphis", "Omaha", "Orlando", "Salem", "Seattle", "Tampa", "Topeka" };

            Console.WriteLine($"Cities: {string.Join(", ", cities)}");

            if (ReadLetter("First letter:") is not char first || ReadLetter("Last letter:") is not char last) {
                Console.WriteLine("No input, try again.");
                return;
            }

            List<string> matches = MatchCities(cities, first, last);
            Console.WriteLine(matches.Count == 0 ? "No match." : $"Match: {string.Join(", ", matches)}");

        }

        static void RunOverCheck() {

            Console.WriteLine("Whole numbers, separated by spaces.");

            if (ReadNumbers("Numbers:") is not int[] numbers) {
                Console.WriteLine("No input, try again.");
                return;
            }

            Console.WriteLine("Over 80:");
            foreach (int number in FilterNumbers(numbers))
                Console.WriteLine(number);

        }

        static void RunNextLetter() {

            Console.WriteLine("Letters in a to z order, separated by spaces, at least two different.");

            if (ReadLetters("Letters:") is not char[] letters || ReadLetter("Target:") is not char target) {
                Console.WriteLine("No input, try again.");
                return;
            }

            Console.WriteLine($"Next letter after {target}: {NextLetter(letters, target)}");

        }
    }
}
