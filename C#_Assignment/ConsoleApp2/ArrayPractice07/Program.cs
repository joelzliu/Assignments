class Program
{
    static void Main()
    {
        int[] nums1 = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        FindMostFreqNum(nums1);

        int[] nums2 = { 7, 7, 7, 0, 2, 2, 2, 0, 10, 10, 10 };
        FindMostFreqNum(nums2);
    }

    static void FindMostFreqNum(int[] nums)
    {
        Dictionary<int, int> freqs = new Dictionary<int, int>();
        int maxFreq = 0;

        foreach(int num in nums)
        {
            if(!freqs.ContainsKey(num))
                freqs[num] = 0;
            freqs[num]++;
            maxFreq = Math.Max(maxFreq, freqs[num]);
        }

        List<int> mostFreqNums = new List<int>();
        foreach(var kvp in freqs)
        {
            if (kvp.Value == maxFreq)
                mostFreqNums.Add(kvp.Key);
        }

        int leftmostNum = mostFreqNums[0];
        foreach(int num in mostFreqNums)
        {
            if(Array.IndexOf(nums, num) < Array.IndexOf(nums, leftmostNum))
                leftmostNum = num;
        }

        Console.WriteLine($"The most frequent number(s): {string.Join(", ", mostFreqNums)} (occurs {maxFreq} times).");
        Console.WriteLine($"The leftmost most frequent number is: {leftmostNum}.");
    }
}