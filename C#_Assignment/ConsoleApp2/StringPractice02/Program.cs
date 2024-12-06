using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // Define separators as regex
        string pattern = @"[.,;:()&[\]""'/!? ]"; // Word separators
        string[] words = Regex.Split(sentence, pattern); // Split words by separators
        string[] separators = Regex.Matches(sentence, pattern).Select(m => m.Value).ToArray();

        // Reverse the words
        Array.Reverse(words);

        // Reconstruct the sentence
        string result = string.Empty;
        for (int i = 0; i < separators.Length; i++)
        {
            if (i < words.Length && !string.IsNullOrEmpty(words[i]))
            {
                result += words[i];
            }
            result += separators[i];
        }

        if (words.Length > separators.Length) // Add any leftover words
        {
            result += words[words.Length - 1];
        }

        Console.WriteLine($"Reversed sentence: {result}");
    }
}