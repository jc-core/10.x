namespace Assignment10_2 {
    internal class QueryFuncs {

        public static List<int> Positives(int[] numbers) {

            var positiveNums = from number in numbers
                               where number > 0
                               select number;

            return positiveNums.ToList();

        }

        public static List<Employee> FilterEmployees(List<Employee> employees) {

            var matches = from employee in employees
                          where employee.Salary > 5000 && employee.Age < 30
                          select employee;

            return matches.ToList();

        }

        public static List<string> MatchCities(string[] cities, char first, char last) {

            var matches = from city in cities
                          where char.ToUpper(city[0]) == char.ToUpper(first)
                             && char.ToUpper(city[^1]) == char.ToUpper(last)
                          select city;

            return matches.ToList();

        }

        public static List<int> FilterNumbers(int[] numbers) {

            var matches = from number in numbers
                          where number > 80
                          select number;

            return matches.ToList();

        }

        public static char NextLetter(char[] letters, char target) {

            int low = 0;
            int high = letters.Length - 1;

            while (low <= high) {
                int middle = (low + high) / 2;
                if (letters[middle] > target)
                    high = middle - 1;
                else
                    low = middle + 1;
            }

            return low < letters.Length ? letters[low] : letters[0];

        }
    }
}
