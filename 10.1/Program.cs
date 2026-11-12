using static Assignment10_1.TextFuncs;
using static Assignment10_1.SaveFuncs;
using static Assignment10_1.BracketFuncs;
namespace Assignment10_1 {
    internal class Program {

        static void Main(string[] args) {

        startLoop:

            switch (ReadChoice("(1) Save and load books  (2) Bracket pairs:")) {
                case "1":
                    RunSaveLoad();
                    break;
                case "2":
                    RunBrackets();
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

        static void RunSaveLoad() {

            Console.WriteLine("Writes the book list to XML and JSON files, then reads each file back.");

            List<Book> books = new() {
                new Book { Title = "Let's Learn Shapes", Author = "Franz Ferdinand", Year = 2009, Pages = 296 },
                new Book { Title = "Tuesday Forever", Author = "Candance Wallerby", Year = 2013, Pages = 184 },
                new Book { Title = "Dunking and Weaving", Author = "Penny Lane", Year = 2019, Pages = 312 },
                new Book { Title = "A Dialectical Approach to the Themes and Provinces of Spongebob Squarepants", Author = "Silas Manderbuilt", Year = 1987, Pages = 401 },
                new Book { Title = "What A Lovely Day to be Me", Author = "Michael Jordan", Year = 1994, Pages = 278 }
            };

            string xmlPath = Path.Combine(AppContext.BaseDirectory, "books.xml");
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "books.json");

            try {

                SaveXml(books, xmlPath);
                SaveJson(books, jsonPath);
                Console.WriteLine($"Saved {xmlPath}");
                Console.WriteLine($"Saved {jsonPath}");
                Console.WriteLine();

                Console.WriteLine(File.ReadAllText(xmlPath));
                Console.WriteLine();
                Console.WriteLine(File.ReadAllText(jsonPath));
                Console.WriteLine();

                ShowBooks("Read back from XML:", LoadXml(xmlPath));
                ShowBooks("Read back from JSON:", LoadJson(jsonPath));

            }
            catch (Exception error) {
                Console.WriteLine($"File problem: {error.Message}");
            }

        }

        static void RunBrackets() {

            Console.WriteLine("Pick how many ( ) pairs to use.");

            if (ReadCount("Pairs:") is not int pairs) {
                Console.WriteLine("No input, try again.");
                return;
            }

            List<string> combos = AllPairs(pairs);
            Console.WriteLine($"{combos.Count} found: {string.Join(" ", combos)}");

        }
    }
}
