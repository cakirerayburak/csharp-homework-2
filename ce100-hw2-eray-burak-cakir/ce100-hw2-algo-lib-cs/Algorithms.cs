using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 
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

        public static int HeapSort(int[] inputArray, out int[] outputArray, bool enableDebug = false)
        {
            outputArray = null;

            if (inputArray == null || inputArray.Length == 0)
            {
                return -1; // Hata durumunu belirtmek için -1 döndürüyoruz.
            }

            outputArray = new int[inputArray.Length];
            Array.Copy(inputArray, outputArray, inputArray.Length);

            int n = outputArray.Length;
            int finalScore = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                finalScore += inputArray[i] * Convert.ToInt32(Math.Pow(10, inputArray.Length - i - 1));
            }
            if (enableDebug == true) { Console.WriteLine("Iteration1: " + finalScore); }
            // Max heap oluşturma işlemi
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(outputArray, n, i);
            }
            int finalScore1 = 0;
            for (int i = 0; i < outputArray.Length; i++)
            {
                finalScore1 += outputArray[i] * Convert.ToInt32(Math.Pow(10, outputArray.Length - i - 1));
            }
            if (enableDebug == true) { Console.WriteLine("Iteration2: " + finalScore1); }
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
            int finalScore2 = 0;
            for (int i = 0; i < outputArray.Length; i++)
            {
                finalScore2 += outputArray[i] * Convert.ToInt32(Math.Pow(10, outputArray.Length - i - 1));
            }
            if (enableDebug == true) { Console.WriteLine("Iteration3: " + finalScore2); }
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


    /**
     * @brief This class provides a method for multiplying matrices using a dynamic programming approach.
     */

    public class MemorizedRecursiveMultiplicationAlgorithm
    {

        /**
     * @brief Computes the minimum number of scalar multiplications needed to multiply the given matrices.

     * This method uses a recursive approach with memoization to compute the minimum number of scalar

     * multiplications needed to multiply the given matrices. The results of subproblems are stored in
     
     * a two-dimensional array for efficiency. If the `enableDebug` parameter is set to `true`, the
     * values of the memoization table will be printed to the console during execution.
      
     * @param p An array containing the dimensions of the matrices to be multiplied.
     * @param enableDebug If `true`, print the values of the memoization table to the console.
     * @return The minimum number of scalar multiplications needed to multiply the given matrices.
     */




        public static int MCMMRM(int[] p, bool enableDebug = false)
        {
            int n = p.Length;
            int[,] m = new int[n, n];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    m[i, j] = -1;
                }
            }

            int LookupChain(int i, int j)
            {
                if (m[i, j] != -1)
                {
                    return m[i, j];
                }

                if (i == j)
                {
                    m[i, j] = 0;
                }
                else
                {
                    for (int k = i; k < j; k++)
                    {
                        int q = LookupChain(i, k) + LookupChain(k + 1, j) + p[i - 1] * p[k] * p[j];

                        if (m[i, j] == -1 || q < m[i, j])
                        {
                            m[i, j] = q;
                        }
                    }
                }

                if (enableDebug)
                {
                    Console.WriteLine($"m[{i}, {j}] = {m[i, j]}");
                }

                return m[i, j];
            };

            return LookupChain(1, n - 1);
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
        public static int MatrixChainOrder_DP(int[] p, int n, bool enableDebug = false)
        {
            int[,] m = new int[n, n];

            for (int i = 1; i < n; i++)
            {
                m[i, i] = 0;
            }

            for (int L = 2; L < n; L++)
            {
                for (int i = 1; i < n - L + 1; i++)
                {
                    int j = i + L - 1;
                    m[i, j] = int.MaxValue;

                    for (int k = i; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < m[i, j])
                        {
                            m[i, j] = q;
                        }
                    }
                }
            }

            if (enableDebug)
            {
                Console.WriteLine("Dynamic Programming matrix:");
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        Console.Write("{0,7}", m[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            return m[1, n - 1];
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

        public static int LCS(string A, string B, bool enableDebug = false)
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
                        if (enableDebug == true) { Console.WriteLine("Iteration: " + dp[i, j] + " changed with " + dp[i - 1, j - 1] + 1); }
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                        if (enableDebug == true) { Console.WriteLine("Iteration: " + dp[i, j] + " changed with " + Math.Max(dp[i - 1, j], dp[i, j - 1])); }
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


        public static int Knapsack01(int[] values, int[] weigth, int maxBenefit, bool enableDebug = false)
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
                        int a = Math.Max(m[i - 1, c], values[i - 1] + m[i - 1, c - weigth[i - 1]]);
                        m[i, c] = a;
                        if (enableDebug == true) { Console.WriteLine("Iteration: " + m[i, c] + " changed with " + a); }
                    }
                    else
                    {
                        m[i, c] = m[i - 1, c];
                        if (enableDebug == true) { Console.WriteLine("Iteration: " + m[i, c] + " changed with " + m[i - 1, c]); }
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









