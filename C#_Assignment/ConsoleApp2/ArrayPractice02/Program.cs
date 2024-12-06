class Program
{
    static void Main()
    {
        List<string> itemList = new List<string>();

        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string command = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(command))
            {
                continue;
            }

            if(command.StartsWith("+"))
            {
                string itemToAdd = command.Substring(1).Trim();
                if(!string.IsNullOrEmpty(itemToAdd))
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
                if(command == "--")
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
                        Console.WriteLine($"Item '{itemToRemove}' not found.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid command. Use + to add, - to remove, or -- to clear.");
            }

            Console.WriteLine("Current List: " + (itemList.Count > 0 ? string.Join(", ", itemList) : "Empty"));
        }
    }
}
