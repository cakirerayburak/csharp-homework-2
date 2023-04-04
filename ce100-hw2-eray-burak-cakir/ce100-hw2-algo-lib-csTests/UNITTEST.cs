using Microsoft.VisualStudio.TestTools.UnitTesting;
using ce100_hw2_algo_lib_cs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Policy;

namespace UNIT.Tests
{

    /*

    This is a test class for the HeapSortAlgorithm class.

    It includes three test methods for best case, average case and worst case scenarios of the algorithm.

    Author: [Eray Burak ÇAKIR and Süleyman Mert ALMALI]
        */




    [TestClass]
    public class HeapSortTest : HeapSortAlgorithm
    {
        [TestMethod]
        public void BestCase()
        {
            // Arrange
            int[] inputArray = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] expectedOutputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            int result = HeapSort(inputArray, out int[] outputArray, true);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }

        [TestMethod]
        public void AverageCase()
        {
            // Arrange
            int[] inputArray = { 4, 5, 6, 1, 2, 3, 6 };
            int[] expectedOutputArray = { 1, 2, 3, 4, 5, 6, 6 };

            // Act
            int result = HeapSort(inputArray, out int[] outputArray, true);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }

        [TestMethod]
        public void WorstCase()
        {
            // Arrange
            int[] inputArray = null;
            int[] expectedOutputArray = null;

            // Act
            int result = HeapSort(inputArray, out int[] outputArray, true);

            // Assert
            Assert.AreEqual(-1, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }






    }

    [TestClass]
    public class MemorizedRecursiveMultiplicationTest : MemorizedRecursiveMultiplicationAlgorithm 
    {

        [TestMethod]
        public void BestCase()
        {
            int[] p = { 10, 20, 30, 40, 50, 60, 70 };
            int expected = 110000;


            int n = p.Length - 1;
            int[,] m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = -1;
                }
            }

            int result = MCMMRM(p, true);

            Assert.AreEqual(expected, result);
        }



        [TestMethod]
        public void AverageCase()
        {
            int[] p = { 30, 35, 15, 30, 10, 20, 25 };
            int expected = 32750;


            int n = p.Length - 1;
            int[,] m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = -1;
                }
            }

            int result = MCMMRM(p, true);

            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void WorstCase()
        {
            int[] p = { 10, 20, 30, 40, 30 };
            int expected = 30000;


            int n = p.Length - 1;
            int[,] m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = -1;
                }
            }


            int result = MCMMRM(p,true);

            Assert.AreEqual(expected, result);

        }



    }


        [TestClass]
        public class LongestCommonSubsequenceTest : LongestCommonSubsequence
        {
            [TestMethod]
            public void BestCaseTest()
            {
                string A = "ABC";
                string B = "DEF";
                int expected = 0;
                int result = LCS(A, B, true);
                Assert.AreEqual(expected, result);


            }

            [TestMethod]
            public void AverageCaseTest()
            {
                string A = "ABCDEF";
                string B = "DEFABC";
                int expected = 3;
                int result = LCS(A, B, true);
                Assert.AreEqual(expected, result);


            }

            [TestMethod]
            public void WorstCaseTest()
            {
                // Arrange
                string A = "ABCDEFGHIJKLMNO";
                string B = "PQRSTUVWXYZ1234567890";
                int expected = 0;

                // Act
                int result = LCS(A, B, true);

                // Assert
                Assert.AreEqual(expected, result);
            }







        }




    [TestClass]
    public class MatrixChainMultiplicationTests : MatrixChainMultiplicationAlgorithm
    {
        private int[,] dp;

        private int MatrixChainMultiplication(List<int> arr, int left, int right)
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
                tempCost = MatrixChainMultiplication(arr, left, k) + MatrixChainMultiplication(arr, k + 1, right) + (arr[left - 1] * arr[k] * arr[right]);

                minCost = Math.Min(minCost, tempCost);
            }

            dp[left, right] = minCost;
            return minCost;
        }




        [TestMethod]
        public void MatrixChainMultiplication_Recursive()
        {

            List<int> arr = new List<int> { 10, 20, 30, 40, 30 };
            int expectedCost = 30000;

            dp = new int[arr.Count + 1, arr.Count + 1];
            for (int i = 0; i <= arr.Count; i++)
            {
                for (int j = 0; j <= arr.Count; j++)
                {
                    dp[i, j] = -1;
                }
            }

            int actualCost = MatrixChainMultiplication(arr, 1, arr.Count - 1);

            Assert.AreEqual(expectedCost, actualCost);
        }




        [TestMethod]
        public void MatrixChainMultiplication_DP_AverageCase()
        {

            int[] p = new int[] { 10, 20, 30, 40, 30 };
            int n = p.Length;


            int result = MatrixChainOrder_DP(p, n, true);


            Assert.AreEqual(30000, result);

        }

        [TestMethod]
        public void MatrixChainMultiplication_DP_WorstCase()
        {

            int[] p = new int[] { 30, 35, 15, 5, 10, 20, 25 };
            int n = p.Length;


            int result = MatrixChainOrder_DP(p, n, true);


            Assert.AreEqual(15125, result);

        }
    }






    [TestClass]
    public class KnapsackProblemTest : KnapsackAlgorithm
    {

        [TestMethod]
        public void BestCaseTest()
        {
            int[] weights = { 5, 3, 4, 2 };
            int[] values = { 10, 8, 11, 7 };

            int maxBenefit = 13;
            int expected = 5;

            int output = Knapsack01(weights, values, maxBenefit, true);

            Assert.AreEqual(expected, output);





        }

        [TestMethod]
        public void AverageCaseTest()
        {
            int[] weights = { 6, 5, 4, 3, 2, 1 };
            int[] values = { 10, 8, 11, 7, 5, 3 };

            int maxBenefit = 10;


            int expected = 6;

            int output = Knapsack01(weights, values, maxBenefit, true);

            Assert.AreEqual(expected, output);

        }

        [TestMethod]
        public void WorstCaseTest()
        {
            int[] weights = { 10, 20, 30, 40 };
            int[] values = { 5, 10, 15, 20 };

            int maxBenefit = 0;

            int expected = 0;

            int output = Knapsack01(weights, values, maxBenefit, true);

            Assert.AreEqual(expected, output);



        }






    }
}











