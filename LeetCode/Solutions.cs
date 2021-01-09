using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace DataStructures.LeetCode
{
    /// <summary>
    /// Completed Questions: 5
    /// </summary>
    public class Solutions
    {







        /// <summary>
        /// https://leetcode.com/problems/container-with-most-water/
        /// </summary>
        public int MaxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }

            /*
            //Brute Force
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    maxarea = Math.Max(maxarea,Math.Min(height[l], height[r]) * (r - 1));
                }
            }
            */

            return maxarea;
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-integer/
        /// </summary>
        public int ReverseInteger(int x)
        {
            int MAX = int.MaxValue / 10;
            int MIN = int.MinValue / 10;
            int reverse = 0;

            int pop;
            while (x != 0)
            {
                pop = x % 10;
                x /= 10;
                if (reverse > MAX || (reverse == MAX && pop > 7)) return 0;
                if (reverse < MIN || (reverse == MIN && pop < -8)) return 0;
                reverse = reverse * 10 + pop;
            }

            return reverse;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// </summary>
        public string LongestPalindrome(string s)
        {
            var result = "";

            for (int i = 0; i < s.Length; i++)
            {
                var odd = ExpandCenter(s, i, i);
                var even = ExpandCenter(s, i, i + 1);
                var maxLength = Math.Max(odd, even);

                if (maxLength > result.Length)
                {
                    var startIndex = i - ((maxLength - 1) / 2);
                    //var length = i + (maxLength / 2) + 1;
                    result = s.Substring(startIndex, maxLength);
                }
            }

            return result;
        }

        private int ExpandCenter(string s, int left, int right)
        {
            var l = left;
            var r = right;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return r - l - 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        public int LengthOfLongestSubstring(string s)
        {
            int answer = 0;
            var map = new Dictionary<char, int>();

            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }

                answer = Math.Max(answer, j - i + 1);
                map[s[j]] = j + 1;
            }

            return answer;
        }
    }


    /// <summary>
    /// https://leetcode.com/problems/print-foobar-alternately/
    /// </summary>
    public class FooBar
    {
        private readonly int n;
        private readonly SemaphoreSlim _Lock;
        private readonly SemaphoreSlim _Lock2;

        public FooBar(int n)
        {
            this.n = n;
            _Lock = new SemaphoreSlim(0, n);
            _Lock2 = new SemaphoreSlim(0, n);
        }

        public void Foo()
        {

            for (int i = 0; i < n; i++)
            {
                Console.Write("foo");
                _Lock.Release();
                _Lock2.Wait();
            }
        }

        public void Bar()
        {

            for (int i = 0; i < n; i++)
            {
                _Lock.Wait();
                Console.Write("bar");
                _Lock2.Release();
            }
        }

        public void Run()
        {
            var t1 = new Thread(new ThreadStart(Foo));
            var t2 = new Thread(new ThreadStart(Bar));
            t2.Start();
            t1.Start();
        }

    }

}
