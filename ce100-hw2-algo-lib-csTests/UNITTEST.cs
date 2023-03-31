using Microsoft.VisualStudio.TestTools.UnitTesting;
using ce100_hw2_algo_lib_cs;
using System;
using System.Collections.Generic;


namespace UNIT.Tests 
{
    [TestClass]
    public class HEAPSORTTEST : MATRIXMULTIPLICATION
    {
        [TestMethod]
        public void HeapSort_InputArraySortedDescending_ShouldReturnArraySortedAscending()
        {
            // Arrange
            int[] inputArray = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] expectedOutputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            int result = HeapSort(inputArray, out int[] outputArray);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }

        [TestMethod]
        public void HeapSort_InputArrayHasDuplicateValues_ShouldReturnArraySortedAscending()
        {
            // Arrange
            int[] inputArray = { 4, 5, 6, 1, 2, 3, 6 };
            int[] expectedOutputArray = { 1, 2, 3, 4, 5, 6, 6 };

            // Act
            int result = HeapSort(inputArray, out int[] outputArray);

            // Assert
            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }

        [TestMethod]
        public void HeapSort_InputArrayIsNull_ShouldReturnError()
        {
            // Arrange
            int[] inputArray = null;
            int[] expectedOutputArray = null;

            // Act
            int result = HeapSort(inputArray, out int[] outputArray);

            // Assert
            Assert.AreEqual(-1, result);
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
        }





       



            [TestClass]
            public class LongestCommonSubsequenceTest
            {

                [TestMethod]
                public void TestLCS()
                {
                    // Arrange
                    string A = "ABCDGH";
                    string B = "AEDFHR";
                    int expected = 3;

                    // Act
                    int actual = LCS(A, B);

                    // Assert
                    Assert.AreEqual(expected, actual);
                }

            }

        }


        [TestClass]
        public class MatrixChainMultiplicationTests
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
            public void TestMatrixChainMultiplication()
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
        }














        //[TestMethod]
        //public void MCMRecursiveMemorized_ReturnsCorrectOutput()
        //{
        //    // Arrange
        //    int[] matrixDimensions = { 10, 30, 5, 60 };
        //    int expectedOperationCount = 4500;
        //    string expectedMatrixOrder = "((A1(A2A3))A4)";

        //    // Act
        //    string matrixOrder;
        //    int operationCount;
        //    MATRIXMULTIPLICATION.MCMRecursiveMemorized(matrixDimensions, out matrixOrder, out operationCount);

        //    // Assert
        //    Assert.AreEqual(expectedOperationCount, operationCount);
        //    Assert.AreEqual(expectedMatrixOrder, matrixOrder);

        //}













    }











