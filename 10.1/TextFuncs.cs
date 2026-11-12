namespace Assignment10_1 {
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

        internal static int? ReadCount(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? input = Console.ReadLine();

                if (input == null)
                    return null;

                if (int.TryParse(input.Trim(), out int count) && count >= 1 && count <= 8)
                    return count;

                Console.WriteLine("Whole number from 1 to 8, try again.");

            }
        }

        internal static void ShowBooks(string label, List<Book> books) {

            Console.WriteLine(label);
            foreach (Book book in books)
                Console.WriteLine($"  {book.Title} by {book.Author}, {book.Year}, {book.Pages} pages");

        }
    }
}
