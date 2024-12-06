class Program
{
    static void Main()
    {
        for(int increment = 1; increment <= 4; increment++)
        {
            for(int i = 0; i <= 24; i += increment)
            {
                Console.Write(i + (i < 24 && i + increment <= 24 ? ", " : ""));
            }
            Console.WriteLine();
        }
    }
}