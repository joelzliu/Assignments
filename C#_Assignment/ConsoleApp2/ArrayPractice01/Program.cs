class Program
{
    static void Main()
    {
        // Assign values
        int[] originalArr = new int[10];
        for(int i = 0; i < originalArr.Length; i++)
        {
            originalArr[i] = i + 1;
        }

        // Copy values
        int[] copiedArr = new int[originalArr.Length];
        for (int i = 0; i < originalArr.Length; i++)
        {
            copiedArr[i] = originalArr[i];
        }

        // Compare
        Console.WriteLine("Original Array: " + string.Join(", ", originalArr));
        Console.WriteLine("Copied Array: " + string.Join(", ", copiedArr));
    }
}