class Program
{
    static void Main()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number between 1 and 3:");

        while (true)
        {
            int guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Out of range. Please enter a number between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Too low.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine("Too high.");
            }
            else
            {
                Console.WriteLine("Correct! You got the number!");
                break;
            }
        }
    }
}