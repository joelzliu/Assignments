using System;

class Program
{
    static void Main()
    {
        int[] arr1 = {2, 1, 1, 2, 2, 2, 3, 3, 3, 2, 2, 1};
        int[] res1 = FindLongestSequence(arr1);
        Console.WriteLine(string.Join(" ", res1));
        
        int[] arr2 = {0, 1, 1, 5, 2, 2, 6, 3, 3};
        int[] res2 = FindLongestSequence(arr2);
        Console.WriteLine(string.Join(" ", res2));
    }

    static int[] FindLongestSequence(int[] arr)
    {
        int maxLen = 1;
        int currLen = 1;
        int startIdx = 0;

        for(int i = 1; i < arr.Length; i++)
        {
            if(arr[i] == arr[i - 1])
                currLen++;
            else
                currLen = 1;

            if(currLen > maxLen)
            {
                maxLen = currLen;
                startIdx = i - maxLen + 1;
            }
        }

        int[] longestSeq = new int[maxLen];
        Array.Copy(arr, startIdx, longestSeq, 0, maxLen);
        return longestSeq;
    }
}