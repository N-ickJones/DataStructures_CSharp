using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using DataStructures.LinkedList;
using DataStructures.Arrays;


namespace DataStructures
{
    class Program
    {
        static void Main()
        {
            //BinarySearchPrint();
            //BinarySearchTreePrint();
            //LeastSquaresPrint();
            //LinkedSumPrint();

            LeetCodePrint();


            Console.Read();
        }

        static void LeetCodePrint()
        {
            //var fb = new LeetCode.FooBar(3);
            //fb.Run();

            var leetCode = new LeetCode.Solutions();
            Console.WriteLine(leetCode.MaxArea(new int[] { 1, 1 }));

            //Console.WriteLine(leetCode.LengthOfLongestSubstring("aab"));
            //Console.WriteLine(leetCode.LongestPalindrome("babad"));
            //Console.WriteLine(leetCode.ReverseInteger(1463847412));
        }

        static void LinkedSumPrint()
        {
            var value1 = new int[] { 2, 4, 3 };
            var value2 = new int[] { 5, 6, 4 };

            var linkedSum = new LinkedSum();
            var l1 = new ListNode();
            var l2 = new ListNode();

            var resultL1 = l1;
            for (int i = 0; i < value1.Length; i++)
            {
                l1.val = value1[i];
                if (i < value1.Length-1)
                {
                    l1.next = new ListNode();
                    l1 = l1.next;
                }
            }

            var resultL2 = l2;
            for (int i = 0; i < value2.Length; i++)
            {
                l2.val = value2[i];
                if (i < value2.Length-1)
                {
                    l2.next = new ListNode();
                    l2 = l2.next;
                }
            }

            linkedSum.PrintList(resultL1); Console.WriteLine();
            linkedSum.PrintList(resultL2); Console.WriteLine();

            var result = linkedSum.AddTwoNumbers(resultL1, resultL2);
            linkedSum.PrintList(result);
        }

        static void TwoSumPrint()
        {
            var obj = new TwoSum();
            //var nums = new int[] { 3, 2, 4 };
            var nums = new int[] { 2, 7, 11, 15 }; //;//;
            var target = 9;  //6
            var result = obj.TwoSum3(nums, target);
            if (result != null)
            {
                Console.WriteLine($"{result[0]}, {result[1]}");
            }
        }

        static void LeastSquaresPrint()
        {
            var mtx = new Matrix();


            var matrixA = new double[,] 
            {
                { 1, 2 },
                { 0, 1 },
                { 2, 1 }
            };
            Console.WriteLine("Matrix A");
            mtx.Print(matrixA); Hr();

            var matrixB = new double[,]
            {
                { 3 },
                { 1 },
                { 1 }
            };
            Console.WriteLine("Matrix B");
            mtx.Print(matrixB); Hr();

            var matrixAInvert = mtx.Invert(matrixA);
            var matrixATA = mtx.Transpose(matrixA, matrixAInvert);
            Console.WriteLine("Matrix AtA");
            mtx.Print(matrixATA); Hr();

            var matrixATB = mtx.Transpose(matrixA, matrixB);
            Console.WriteLine("Matrix AtB");
            mtx.Print(matrixATB); Hr();

            var matrixNew = mtx.LeastSquares(matrixATA, matrixATB);

            Console.WriteLine("AtA after zeroing");
            mtx.Print(matrixNew.A); Hr();
            Console.WriteLine("AtB after zeroing");
            mtx.Print(matrixNew.B); Hr();
            Console.WriteLine("x*");
            mtx.Print(matrixNew.C); Hr();

            //Ax*
            var matrixATX = mtx.Transpose(matrixA, matrixNew.C);
            Console.WriteLine("Matrix Ax*");
            mtx.Print(matrixATX); Hr();

            //Ax* -b

            var matrixATXB = mtx.Subtract(matrixATX, matrixB);
            Console.WriteLine("Matrix Ax* - b");
            mtx.Print(matrixATXB); Hr();

            var rmse = mtx.RMSE(matrixATXB, matrixNew.C);
            Console.WriteLine($"RMSE = {rmse}"); Hr();
        }

        static void BinarySearchTreePrintString()
        {
            var array = new string[] 
            { 
                "dog",
                "cat",
                "bird",
                "rabbit",
                "frog",
                "fox",
                "cow",
                "squirrel",
                "mouse"
            };
            var bst = new BinarySearchTree<string>(Comparer<string>.Create((x, y) => x.CompareTo(y)), null, true);
            bst.Add(array);

            Console.WriteLine($"The depth is {bst.GetTreeDepth()}");

            Console.WriteLine("Attempt to Find 9");
            Console.WriteLine(bst.Find("bird").Data);
            Hr();

            Console.WriteLine("Attempt to Remove 9");
            bst.Remove("fox");
            Hr();

            Console.WriteLine("PreOrder Traversal");
            bst.TraversePreOrder();
            Hr();

            Console.WriteLine("InOrder Traversal");
            bst.TraverseInOrder();
            Hr();

            Console.WriteLine("PostOrder Traversal");
            bst.TraversePostOrder();
            Hr();
        }

        static void BinarySearchTreePrint()
        {
            var array = new int[] { 5, 3, 4, 7, 1, 9, 3, 8, 2 };
            var bst = new BinarySearchTree<int>(Comparer<int>.Create((x, y) => x.CompareTo(y)), null, true);
            bst.Add(array);

            Console.WriteLine($"The depth is {bst.GetTreeDepth()}");

            Console.WriteLine("Attempt to Find 9");

            var found = bst.Find(7);
            if (found != null)
            {
                Console.WriteLine($"Found {found.Data}");
            }
            Hr();

            Console.WriteLine("Attempt to Remove 9");
            bst.Remove(3);
            Hr();

            Console.WriteLine("PreOrder Traversal");
            bst.TraversePreOrder();
            Hr();

            Console.WriteLine("InOrder Traversal");
            bst.TraverseInOrder();
            Hr();

            Console.WriteLine("PostOrder Traversal");
            bst.TraversePostOrder();
            Hr();
        }

        static void BinarySearchPrint()
        {
            Hr();
            Console.WriteLine("Binary Search Algorithm");
            var arr = new int[10] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var key = 10;
            Console.Write("Integer Array: (");
            foreach (var item in arr)
            {
                Console.Write($"{item},");
            }
            Console.Write(")\n");
            Console.WriteLine($"Search Key: {key}");
            Console.WriteLine($"Iterative Key Index: {BinarySearch.Iterative(arr, key)}");
            Console.WriteLine($"Recursive Key Index: {BinarySearch.Recursive(arr, key)}");
            Hr();
        }

        static void Hr()
        {
            Console.WriteLine("------------------------------------------------");
        }
        
    }
}


/*

var matrixA = new double[,] 
            {
                {  3, -1, 2 },
                {  4,  1, 0 },
                { -3,  2, 1 },
                {  1,  1, 5 },
                { -2,  0, 3 }
            };
            Console.WriteLine("Matrix A");
            mtx.Print(matrixA); Hr();

            var matrixB = new double[,]
            {
                { 10 },
                { 10 },
                { -5 },
                { 15 },
                { 0  }
            };
            Console.WriteLine("Matrix B");
            mtx.Print(matrixB); Hr();



*/