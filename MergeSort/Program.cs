namespace MergeSort {
    class Program {

        static void Main(string[] args) {

            //arbitrary list of unsorted integers
            int[] integerArray = { 6, 5, -6, 0, 3, 10, 4, 6, -5, 0 };
            int lowIndex = 0;
            int highIndex = integerArray.Length - 1;

            Console.WriteLine("\nUnsorted List of Integers: ");
            PrintList(integerArray);
            Console.WriteLine("\nSorted List of Integers: ");
            MergeSort(integerArray, lowIndex, highIndex);
            PrintList(integerArray);
            Console.WriteLine("\n");
        }

        public static void PrintList(int[] integerArray) {

            foreach (int i in integerArray) {
                Console.Write(i + " ");
            }
            Console.WriteLine('\n');
        }

        //Merge-Sort(Array[], low, high)
        //  if low < high
        //      //round down to find the midpoint
        //      mid = ⌊(low + high) / 2⌋
        //      //recurrsive method calls
        //      Merge-Sort(Array[], low, mid)
        //      Merge-Sort(Array[], mid + 1, high)
        //      Merge(Array[], low, mid, high)

        public static void MergeSort(int[] integerArray, int lowIndex, int highIndex) {

            if (lowIndex < highIndex) {
                int midIndex = (lowIndex + highIndex) / 2;
                MergeSort(integerArray, lowIndex, midIndex);
                MergeSort(integerArray, midIndex + 1, highIndex);
                Merge(integerArray, lowIndex, midIndex, highIndex);
            }
        }

        //Merge(Array[], low, mid, high)
        //  elementsLeft = mid - low + 1
        //  elementsRight = high - mid
        //  new array Left[1... elementsLeft + 1]
        //  new array Right[1...elementsRight + 1]
        //  for i = 1 to elementsLeft
        //      Left[i] = Array[low + i - 1]
        //  for j = 1 to elementsRight
        //      Right[j] = Array[mid + j]
        //  Left[elementsLeft + 1] = ∞
        //  Right[elementsRight + 1] = ∞
        //  i = 1
        //  j = 1
        //  for k = low to high
        //      if Left[i] ≤ Right[j]
        //          Array[k] = Left[i]
        //          i = i + 1
        //      else Array[k] = Right[j]
        //          j = j + 1

        public static void Merge(int[] integerArray, int lowIndex, int midIndex, int highIndex) {

            int i, j, k;
            //calculate the needed array elements for the left sub array
            int elementsLeftArray = midIndex - lowIndex + 1;
            //calculate the needed array elements for the right sub array
            int elementsRightArray = highIndex - midIndex;
            //create left and right aux arrays
            int[] leftSubArray = new int[elementsLeftArray + 1];
            int[] rightSubArray = new int[elementsRightArray + 1];

            leftSubArray[elementsLeftArray] = int.MaxValue;
            rightSubArray[elementsRightArray] = int.MaxValue;

            //initialize sub array with first half of original array
            for (i = 0; i < elementsLeftArray; i++) {
                leftSubArray[i] = integerArray[lowIndex + i];
            }

            //initialize sub array with second half of original array
            for (j = 0; j < elementsRightArray; j++) {
                rightSubArray[j] = integerArray[midIndex + j + 1];
            }

            i = 0;
            j = 0;

            //merge left and right sub arrays into original
            for (k = lowIndex; k <= highIndex; k++) {
                if (leftSubArray[i] <= rightSubArray[j]) {
                    integerArray[k] = leftSubArray[i];
                    i++;
                } else {
                    integerArray[k] = rightSubArray[j];
                    j++;
                }
            }
        }
    }
}