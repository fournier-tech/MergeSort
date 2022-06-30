using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertionSort {
    class Program {

        static void Main(string[] args) {

            int[] integerArray = { 6, 5, 6, 0, 3, 10, 4, 6, 5, 0 };
            int i = 0;
            int j = integerArray.Length - 1;

            Console.WriteLine("\nUnsorted List of Integers: ");
            PrintList(integerArray);
            Console.WriteLine("\nSorted List of Integers: ");
            MergeSort(integerArray, i, j);
            PrintList(integerArray);
            Console.WriteLine("\n");
        }

        // infinity(∞) = alt + 236
        // less than or equal (≤) = alt + 243
        //floor function ⌊ ⌋

        //Merge-Sort(A, i, k)           //
        //  if i < k
        //      j = ⌊ (i + k) / 2 ⌋
        //      Merge-Sort(A, i, j)
        //      Merge-Sort(A, j + 1, k)
        //      Merge(A, i, j, k)

        //Merge(A, i, j, k)
        //  n1 = j - i + 1
        //  n2 = k - j
        //  new arrays Left[1... n1 + 1] and Right[1...n2 + 1]
        //  for l = 1 to n1
        //      Left[l] = A[i + l - 1]
        //  for m = 1 to n2
        //      Right[m] = A[j + m]
        //  Left[n1 + 1] = ∞
        //  Right[n2 + 1] = ∞
        //  l = 1
        //  m = 1
        //  for n = i to k
        //      if Left[l] ≤ Right[m]
        //          A[n] = Left[l]
        //          l = l + 1
        //      else A[n] = Right[m]
        //          m = m + 1

        public static void MergeSort(int[] A, int p, int r) {

            if (p < r) {
                int q = (p + r) / 2;
                MergeSort(A, p, q);
                MergeSort(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }

        public static void Merge(int[] A, int p, int q, int r) {

            int i, j, k;
            //calculate the needed array elements for the left sub array
            int n1 = q - p + 1;
            //calculate the needed array elements for the right sub array
            int n2 = r - q;
            //create left and right aux arrays
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];

            double zero = 0;
            double infinity = (1 / zero) - 1;

            for (i = 1; i < n1; i++) {
                L[i] = A[p + i - 1];
            }

            for (j = 1; j < n2; j++) {
                R[j] = A[q + j];
            }

            L[n1 + 1] = (int)infinity;
            R[n2 + 1] = (int)infinity;

            i = 0;
            j = 0;

            for (k = p; k < r; k++) {
                if (L[i] < R[j]) {
                    A[k] = L[i];
                    i++;
                } else {
                    A[k] = R[j];
                    j++;
                }
            }

            //return A;
        }

        public static void PrintList(int[] integerArray) {
            foreach (int i in integerArray) {
                Console.Write(i + " ");
            }
        }
    }
}