namespace Assignment10_2 {
    internal class TextFuncs {

        internal static string ReadChoice(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return "";

                input = input.Trim();

                if (input.Length == 1 && input[0] >= '1' && input[0] <= '5')
                    return input;

                Console.WriteLine("1 to 5 only, try again.");

            }
        }

        internal static int[]? ReadNumbers(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                string[] strNumbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[strNumbers.Length];

                bool HasNumbers() => strNumbers.Length > 0;
                bool AllWhole() => Enumerable.Range(0, strNumbers.Length).All(index => int.TryParse(strNumbers[index], out numbers[index]));

                if (!HasNumbers())
                    Console.WriteLine("Can't be blank, try again.");
                else if (!AllWhole())
                    Console.WriteLine("Whole numbers only, separated by spaces, try again.");
                else
                    return numbers;

            }
        }

        internal static char? ReadLetter(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                input = input.Trim();

                if (input.Length == 1 && char.IsLetter(input[0]))
                    return char.ToLower(input[0]);

                Console.WriteLine("One letter only, try again.");

            }
        }

        internal static char[]? ReadLetters(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                string[] strLetters = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                bool ValidChars() => strLetters.All(strLetter => strLetter.Length == 1 && char.IsAsciiLetterLower(strLetter[0]));
                bool AlphaOrder() => strLetters.SequenceEqual(strLetters.Order());
                bool UniqueChars() => strLetters.Distinct().Count() >= 2;

                if (!ValidChars())
                    Console.WriteLine("Single letters a to z only, separated by spaces, try again.");
                else if (!AlphaOrder())
                    Console.WriteLine("Letters have to be in a to z order, try again.");
                else if (!UniqueChars())
                    Console.WriteLine("Need at least two different letters, try again.");
                else
                    return strLetters.Select(char.Parse).ToArray();

            }
        }

        internal static void ShowNumbers(string label, List<int> numbers) {

            Console.WriteLine(numbers.Count == 0 ? $"{label} none" : $"{label} {string.Join(" ", numbers)}");

        }
    }
}
