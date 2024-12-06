class Program
{
    static void Main()
    {
        int[] primes = FindPrimesInRange(10, 100);
        Console.WriteLine(string.Join(", ", primes));
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();

        for (int i = Math.Max(startNum, 2); i <= endNum; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }

        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}