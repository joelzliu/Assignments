using System;

class Program01
{
    static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers();

        Reverse(numbers);

        PrintNumbers(numbers);
    }

    static int[] GenerateNumbers()
    {
        int length = 10;
        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = i + 1;
        }

        return array;
    }
    
    static void Reverse(int[] array)
    {
        int length = array.Length;

        for (int i = 0; i < length / 2; i++)
        {
            int temp = array[i];
            array[i] = array[length - 1 - i];
            array[length - 1 - i] = temp;
        }
    }

    static void PrintNumbers(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
    }
}