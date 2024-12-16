using System;
using ThrowBall;

class Program
{
    static void Main(string[] args)
    {
        Color redColor = new Color(255, 0, 0);
        Color blueColor = new Color(0, 0, 255);

        Ball ball1 = new Ball(10, redColor);
        Ball ball2 = new Ball(5, blueColor);

        ball1.Throw();
        ball1.Throw();
        ball2.Throw();

        ball1.Pop();

        ball1.Throw();
        ball2.Throw();

        Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}");
        Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}");
    }
}