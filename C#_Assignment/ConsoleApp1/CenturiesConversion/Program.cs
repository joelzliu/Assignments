Console.Write("Enter the number of centuries: ");
int centuries = int.Parse(Console.ReadLine());

int years = centuries * 100;
int days = years * 3652425 / 10000; // 365.2425
long hours = days * 24L;
long minutes = hours * 60L;
long seconds = minutes * 60L;
long milliseconds = seconds * 1000L;
ulong microseconds = (ulong)milliseconds * 1000;
ulong nanoseconds = microseconds * 1000;

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes " +
                   $"= {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");