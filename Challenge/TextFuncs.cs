namespace Week10Challenge {
    internal class TextFuncs {

        internal static string ReadChoice(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return "";

                input = input.Trim();

                if (input == "1" || input == "2")
                    return input;

                Console.WriteLine("1 or 2 only, try again.");

            }
        }

        internal static string? ReadWord(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                input = input.Trim().ToLower();

                if (input.All(char.IsAsciiLetterLower))
                    return input;

                Console.WriteLine("Letters a to z only, no spaces, try again.");

            }
        }

        internal static int[]? ReadSorted(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                string[] strNumbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[strNumbers.Length];

                bool AllWholeNums() => Enumerable.Range(0, strNumbers.Length).All(index => int.TryParse(strNumbers[index], out numbers[index]));
                bool InOrder() => numbers.SequenceEqual(numbers.Order());

                if (!AllWholeNums())
                    Console.WriteLine("Whole numbers only, separated by spaces, try again.");
                else if (!InOrder())
                    Console.WriteLine("Numbers have to go smallest to largest, try again.");
                else
                    return numbers;

            }
        }
    }
}
