using System;
using Task1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing MyStack<T>:");
        MyStack<int> myStack = new MyStack<int>();
        myStack.Push(10);
        myStack.Push(20);
        myStack.Push(30);
        Console.WriteLine($"Stack Count: {myStack.Count()}");
        Console.WriteLine($"Popped: {myStack.Pop()}");
        Console.WriteLine($"Stack Count after Pop: {myStack.Count()}");

        Console.WriteLine("\nTesting MyList<T>:");
        MyList<string> myList = new MyList<string>();
        myList.Add("Alice");
        myList.Add("Bob");
        myList.Add("Charlie");
        Console.WriteLine($"Contains 'Bob': {myList.Contains("Bob")}");
        Console.WriteLine($"Element at index 1: {myList.Find(1)}");
        myList.InsertAt("Dave", 1);
        Console.WriteLine($"Element after InsertAt: {myList.Find(1)}");
        myList.DeleteAt(2);
        Console.WriteLine($"Removed 'Charlie', New Element at index 1: {myList.Find(1)}");
        myList.Clear();
        
        if (myList.Contains("Charlie"))
            myList.Remove(0);
        else
            Console.WriteLine("List is empty or element not found. Cannot remove.");

    }
}