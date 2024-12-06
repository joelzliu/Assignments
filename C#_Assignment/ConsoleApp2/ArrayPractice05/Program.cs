using System;

class Program
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 2, 2, 3, 3, 3, 2, 2, 1 };
        int[] result = FindLongestSequence(array);
        Console.WriteLine(string.Join(" ", result));
    }

    static int[] FindLongestSequence(int[] array)
    {
        int maxLength = 1;
        int currentLength = 1;
        int bestStartIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestStartIndex = i - maxLength + 1;
            }
        }

        int[] longestSequence = new int[maxLength];
        Array.Copy(array, bestStartIndex, longestSequence, 0, maxLength);
        return longestSequence;
    }
}