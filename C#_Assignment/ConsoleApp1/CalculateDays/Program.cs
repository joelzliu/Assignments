class Program
{
    static void Main()
    {
        DateTime birthDate = new DateTime(1998, 3, 27);
        DateTime currentDate = DateTime.Now;

        int ageInDays = (currentDate - birthDate).Days;
        int daysToNextAnniversary = 10000 - (ageInDays % 10000);

        DateTime nextAnniversaryDate = currentDate.AddDays(daysToNextAnniversary);

        Console.WriteLine($"You are {ageInDays} days old.");
        Console.WriteLine($"Your next 10,000-day anniversary is in {daysToNextAnniversary} days, on {nextAnniversaryDate.ToShortDateString()}.");
    }
}