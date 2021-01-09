namespace DataStructures
{
    public class BinarySearch
    {
        public static object Iterative(int[] arr, int key, int minNum = 0, int maxNum = int.MaxValue)
        {
            if (maxNum == int.MaxValue)
                maxNum = arr.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + (maxNum - minNum) / 2);
                if (key == arr[mid])
                    return ++mid;
                else if (key < arr[mid])
                    maxNum = mid - 1;
                else
                    minNum = mid + 1;
            }

            return "No Match";
        }

        public static object Recursive(int[] arr, int key, int minNum = 0, int maxNum = int.MaxValue)
        {
            if (maxNum < minNum)
                return "No Match";

            if (maxNum == int.MaxValue)
                maxNum = arr.Length - 1;

            int mid = (minNum + (maxNum - minNum) / 2);

            if (key == arr[mid])
                return ++mid;
            else if (key < arr[mid])
                return Recursive(arr, key, minNum, --maxNum);
            else
                return Recursive(arr, key, ++minNum, maxNum);
        }
    }
}