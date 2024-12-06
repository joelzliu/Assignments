class Program
{
    static void Main()
    {
        Console.Write("Please enter the height of pyramid: ");
        int numLines = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numLines; i++)
        {
            for (int j = 1; j <= numLines - i; j++) 
            {
                Console.Write(" ");
            }
            
            for (int k = 1; k <= (2 * i) - 1; k++) 
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}