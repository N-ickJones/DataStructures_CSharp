using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Fibonacci
{
    class FibonacciSeries
    {
        public int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        public int Fibonacci(int n, int[] memo)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else if (memo[n] == 0)
            {
                memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            }
            return memo[n];
        }
    }
}
