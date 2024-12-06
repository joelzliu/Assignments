class Program
{
    static void Main()
    {
        List<string> itemList = new List<string>(); // List to store the items
        string command;

        while (true) // Infinite loop
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            command = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(command)) // Handle empty input
                continue;

            if (command.StartsWith("+")) // Add item
            {
                string itemToAdd = command.Substring(1).Trim();
                if (!string.IsNullOrEmpty(itemToAdd))
                {
                    itemList.Add(itemToAdd);
                    Console.WriteLine($"Added: {itemToAdd}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please specify an item to add.");
                }
            }
            else if (command.StartsWith("-"))
            {
                if (command == "--")
                {
                    itemList.Clear();
                    Console.WriteLine("List cleared.");
                }
                else
                {
                    string itemToRemove = command.Substring(1).Trim();
                    if (itemList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Removed: {itemToRemove}");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToRemove}' not found in the list.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid command. Use + to add, - to remove, or -- to clear.");
            }

            // Display current list contents
            Console.WriteLine("Current List: " + (itemList.Count > 0 ? string.Join(", ", itemList) : "Empty"));
        }
    }
}
