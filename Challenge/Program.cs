using static Week10Challenge.TextFuncs;
using static Week10Challenge.ArrayFuncs;
namespace Week10Challenge {
    internal class Program {

        static void Main(string[] args) {

        startLoop:

            switch (ReadChoice("(1) Find added letter  (2) Merge sorted lists:")) {
                case "1":
                    RunAddedLetter();
                    break;
                case "2":
                    RunMerge();
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

        static void RunAddedLetter() {

            Console.WriteLine("First word can be blank. Second word is the same letters, any order, plus one.");

            if (ReadWord("First word:") is not string original || ReadWord("Second word:") is not string shuffled)
                Console.WriteLine("No input, try again.");
            else if (!CheckAddedLetter(original, shuffled))
                Console.WriteLine("Second word has to be the first word's letters plus exactly one more.");
            else
                Console.WriteLine($"Added letter: {AddedLetter(original, shuffled)}");

        }

        static void RunMerge() {

            Console.WriteLine("Two lists, smallest to largest, separated by spaces. Either one can be blank.");

            if (ReadSorted("First list:") is not int[] firstNumbers || ReadSorted("Second list:") is not int[] second) {
                Console.WriteLine("No input, try again.");
                return;
            }

            int[] first = new int[firstNumbers.Length + second.Length];
            firstNumbers.CopyTo(first, 0);

            Console.WriteLine($"Before: [{string.Join(", ", first)}]  +  [{string.Join(", ", second)}]");
            MergeInPlace(first, firstNumbers.Length, second, second.Length);
            Console.WriteLine($"After:  [{string.Join(", ", first)}]");

        }
    }
}
