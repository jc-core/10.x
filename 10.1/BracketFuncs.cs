namespace Assignment10_1 {
    internal class BracketFuncs {

        public static List<string> AllPairs(int pairs) {

            List<string> validPairList = new();
            Build(validPairList, "", 0, 0, pairs);

            return validPairList;

        }

        static void Build(List<string> validPairList, string validPairs, int currentOpen, int currentClosed, int pairs) {

            if (validPairs.Length == pairs * 2) {
                validPairList.Add(validPairs);
                return;
            }

            if (currentOpen < pairs)
                Build(validPairList, validPairs + "(", currentOpen + 1, currentClosed, pairs);
            if (currentClosed < currentOpen)
                Build(validPairList, validPairs + ")", currentOpen, currentClosed + 1, pairs);

        }
    }
}
