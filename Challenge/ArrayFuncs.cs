namespace Week10Challenge {
    internal class ArrayFuncs {

        public static char AddedLetter(string original, string shuffled) {

            int total = 0;

            foreach (char letter in shuffled)
                total += letter;
            foreach (char letter in original)
                total -= letter;

            return (char)total;

        }

        public static bool CheckAddedLetter(string original, string shuffled) {

            if (shuffled.Length != original.Length + 1)
                return false;

            int[] counts = new int[26];
            foreach (char letter in shuffled)
                counts[letter - 'a']++;
            foreach (char letter in original)
                if (--counts[letter - 'a'] < 0)
                    return false;

            return true;

        }

        public static void MergeInPlace(int[] first, int firstCount, int[] second, int secondCount) {

            int fromFirst = firstCount - 1;
            int fromSecond = secondCount - 1;
            int index = firstCount + secondCount - 1;

            while (fromSecond >= 0) {
                if (fromFirst >= 0 && first[fromFirst] > second[fromSecond])
                    first[index--] = first[fromFirst--];
                else
                    first[index--] = second[fromSecond--];
            }

        }
    }
}
