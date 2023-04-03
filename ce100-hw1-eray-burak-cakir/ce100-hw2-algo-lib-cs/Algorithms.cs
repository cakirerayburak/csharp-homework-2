using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 
 * @author Eray Burak ÇAKIR and Süleyman Mert ALMALI
 
 */
namespace ce100_hw2_algo_lib_cs
{
     


    public class HeapSortAlgorithm
    {


        /// <summary>
        /// Sorts an input array using the heap sort algorithm.
        /// </summary>
        /// <param name="inputArray">The input array to be sorted.</param>
        /// <param name="outputArray">The sorted output array.</param>
        /// <returns>Returns 0 on success or -1 on failure.</returns>

        public static int HeapSort(int[] inputArray, out int[] outputArray)
        {
            outputArray = null;

            if (inputArray == null || inputArray.Length == 0)
            {
                return -1; // Hata durumunu belirtmek için -1 döndürüyoruz.
            }

            outputArray = new int[inputArray.Length];
            Array.Copy(inputArray, outputArray, inputArray.Length);

            int n = outputArray.Length;

            // Max heap oluşturma işlemi
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(outputArray, n, i);
            }

            // Max heap üzerinde dolaşarak sıralama işlemi
            for (int i = n - 1; i > 0; i--)
            {
                // Max elemanı sondaki eleman ile yer değiştirme
                int temp = outputArray[0];
                outputArray[0] = outputArray[i];
                outputArray[i] = temp;

                // Sondaki eleman haricinde kalan elemanlar için max heap oluşturma
                Heapify(outputArray, i, 0);
            }

            return 0; // İşlem başarılı olduğunda 0 döndürüyoruz.
        }

        /// <summary>
        /// Rebuilds a max heap from a given index in an array.
        /// </summary>
        /// <param name="arr">The input array.</param>
        /// <param name="n">The size of the heap.</param>
        /// <param name="i">The index to start the heapify process.</param>

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;

            int left = 2 * i + 1;
            int right = 2 * i + 2;


            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }


            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }


            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;


                Heapify(arr, n, largest);
            }
        }

    }


    public class MatrixChainMultiplicationAlgorithm
    {
        /**

        Calculates the minimum cost of multiplying a sequence of matrices using dynamic programming.

        Also updates the optimal matrix order and the number of operations performed.

        @param matrixDimensionArray An array containing the dimensions of the matrices.

        @param matrixOrder A string reference that will be updated with the optimal matrix order.

        @param operationCount An integer reference that will be updated with the number of operations performed.

        @return The minimum cost of multiplying the matrices.

        */

        private readonly static int[,] dp2 = new int[100, 100];

        // Function for matrix chain multiplication
        static int matrixChainMemoised(int[] p, int i, int j)
        {
            if (i == j)
            {
                return 0;
            }
            if (dp2[i, j] != -1)
            {
                return dp2[i, j];
            }
            dp2[i, j] = Int32.MaxValue;
            for (int k = i; k < j; k++)
            {
                dp2[i, j] = Math.Min(
                  dp2[i, j], matrixChainMemoised(p, i, k)
                  + matrixChainMemoised(p, k + 1, j)
                  + p[i - 1] * p[k] * p[j]);
            }
            return dp2[i, j];
        }

        public static int MatrixChainMultiplication_DP(int[] p, int n)
        {
            int i = 1, j = n - 1;
            return matrixChainMemoised(p, i, j);
        }















        /**

        @brief Computes the minimum cost of multiplying a sequence of matrices using dynamic programming

        @param arr An array of integers representing the dimensions of the matrices

        @param left The index of the leftmost matrix in the sequence

        @param right The index of the rightmost matrix in the sequence

        @param dp A 2D array used to store previously computed results

        @return The minimum cost of multiplying the sequence of matrices
        */


        static int[,] dp;

        public static int MatrixChainMultiplication(int[] arr, int left, int right, int[,] dp)
        {
            if (left == right)
            {
                return 0;
            }

            if (dp[left, right] != -1)
            {
                return dp[left, right];
            }

            int minCost = int.MaxValue, tempCost;

            for (int k = left; k < right; k++)
            {
                tempCost = MatrixChainMultiplication(arr, left, k, dp) + MatrixChainMultiplication(arr, k + 1, right, dp) + (arr[k] * arr[left - 1] * arr[right]);

                minCost = Math.Min(minCost, tempCost);
            }

            dp[left, right] = minCost;
            return minCost;
        }


    }




        public class LongestCommonSubsequence
        {
            /**

            Computes the length of the Longest Common Subsequence (LCS) between two strings.

            @param A The first string.

            @param B The second string.

            @return The length of the LCS.
            */

            public static int LCS(string A, string B)
            {
                int m = A.Length;
                int n = B.Length;

                // create table to store LCS length
                int[,] dp = new int[m + 1, n + 1];

                // fill table with LCS length values
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (A[i - 1] == B[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                        }
                    }
                }

                // LCS length is in the last cell of the table
                return dp[m, n];
            }



        }


            /**

        @brief This method solves the 0-1 knapsack problem using dynamic programming.

        @param values An array containing the values of the items.

        @param weight An array containing the weights of the items.

        @param maxBenefit The maximum benefit that can be obtained from the knapsack.

        @return The maximum value that can be obtained from the knapsack.

        @details This method solves the 0-1 knapsack problem using dynamic programming.

        The problem is defined as follows: given a set of items, each with a weight and a value,

        determine the number of each item to include in a collection so that the total weight

        is less than or equal to a given limit and the total value is as large as possible.

        The method returns the maximum value that can be obtained from the knapsack.

        */


            public class KnapsackAlgorithm
            {


                public static int Knapsack01(int[] values, int[] weigth, int maxBenefit)
                {
                    int N = values.Length;
                    int[,] m = new int[N + 1, maxBenefit + 1];

                    for (int c = 0; c <= maxBenefit; c++)
                    {
                        m[0, c] = 0;
                    }

                    for (int i = 1; i <= N; i++)
                    {
                        for (int c = 0; c <= maxBenefit; c++)
                        {
                            if (weigth[i - 1] <= c)
                            {
                                m[i, c] = Math.Max(m[i - 1, c], values[i - 1] + m[i - 1, c - weigth[i - 1]]);
                            }
                            else
                            {
                                m[i, c] = m[i - 1, c];
                            }
                        }
                    }

                    if (m[N, maxBenefit] == int.MinValue)
                    {
                        return -1;
                    }
                    else
                    {
                        return m[N, maxBenefit];
                    }
                }





    }










}











//public void KnapsackDyProg(int[] W, int[] V, int M, int n)
//{
//    int[,] B = new int[n + 1, M + 1];

//    for (int i = 0; i <= n; i++)
//        for (int j = 0; j <= M; j++)
//        {
//            B[i, j] = 0;
//        }

//    for (int i = 1; i <= n; i++)
//    {
//        for (int j = 0; j <= M; j++)
//        {
//            B[i, j] = B[i - 1, j];

//            if ((j >= W[i - 1]) && (B[i, j] < B[i - 1, j - W[i - 1]] + V[i - 1]))
//            {
//                B[i, j] = B[i - 1, j - W[i - 1]] + V[i - 1];
//            }

//            Console.Write(B[i, j] + " ");
//        }
//        Console.Write("\n");
//    }

//    Console.WriteLine("Max Value:\t" + B[n, M]);

//    Console.WriteLine("Selected Packs: ");

//    while (n != 0)
//    {
//        if (B[n, M] != B[n - 1, M])
//        {
//            Console.WriteLine("\tPackage " + n + " with W = " + W[n - 1] + " and Value = " + V[n - 1]);

//            M = M - W[n - 1];
//        }

//        n--;
//    }
//}

















//public int mcmrem(int[] matrixDimensionArray, ref string matrixOrder, ref int operationCount)
//    {
//        int n = matrixDimensionArray.Length - 1;
//        int[,] s = new int[n + 1, n + 1];
//        int[,] m = new int[n + 1, n + 1];

//        for (int i = 1; i <= n; i++)
//        {
//            m[i, i] = 0;
//        }

//        MatrixChainOrder(matrixDimensionArray, m, s, 1, n);

//        matrixOrder = PrintOptimalParens(s, 1, n);
//        operationCount = m[1, n];

//        return 0;
//    }

//    private void MatrixChainOrder(int[] p, int[,] m, int[,] s, int i, int j)
//    {
//        if (i == j)
//        {
//            return;
//        }

//        m[i, j] = int.MaxValue;

//        for (int k = i; k < j; k++)
//        {
//            int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];

//            if (q < m[i, j])
//            {
//                m[i, j] = q;
//                s[i, j] = k;
//            }
//        }

//        MatrixChainOrder(p, m, s, i, s[i, j]);
//        MatrixChainOrder(p, m, s, s[i, j] + 1, j);
//    }

//    private string PrintOptimalParens(int[,] s, int i, int j)
//    {
//        if (i == j)
//        {
//            return "A" + i;
//        }
//        else
//        {
//            return "(" + PrintOptimalParens(s, i, s[i, j]) + PrintOptimalParens(s, s[i, j] + 1, j) + ")";
//...
//        }
//    }













