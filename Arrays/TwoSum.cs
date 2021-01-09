using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class TwoSum
    {
 
        public int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        //2 pass hash best O(1) worst (n)
        public int[] TwoSum2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement) && dict[complement] != i)
                {
                    return new int[] { i, dict[complement] };
                }
            }
            return null;
        }

        public int[] TwoSum3(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                dict[nums[i]] = i;
            }
            return null;
        }

    }
}