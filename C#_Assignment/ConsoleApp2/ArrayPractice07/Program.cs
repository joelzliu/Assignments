class Program
{
    static void Main()
    {
        int[] numbers1 = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        FindMostFrequentNumbers(numbers1);

        int[] numbers2 = { 7, 7, 7, 0, 2, 2, 2, 0, 10, 10, 10 };
        FindMostFrequentNumbers(numbers2);
    }

    static void FindMostFrequentNumbers(int[] numbers)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        int maxFrequency = 0;

        foreach (int number in numbers)
        {
            if (!frequency.ContainsKey(number))
            {
                frequency[number] = 0;
            }
            frequency[number]++;
            maxFrequency = Math.Max(maxFrequency, frequency[number]);
        }

        List<int> mostFrequentNumbers = new List<int>();
        foreach (var kvp in frequency)
        {
            if (kvp.Value == maxFrequency)
            {
                mostFrequentNumbers.Add(kvp.Key);
            }
        }

        int leftmostNumber = mostFrequentNumbers[0];
        foreach (int number in mostFrequentNumbers)
        {
            if (Array.IndexOf(numbers, number) < Array.IndexOf(numbers, leftmostNumber))
            {
                leftmostNumber = number;
            }
        }

        Console.WriteLine($"The most frequent number(s): {string.Join(", ", mostFrequentNumbers)} (occurs {maxFrequency} times).");
        Console.WriteLine($"The leftmost most frequent number is: {leftmostNumber}.");
    }
}