class Program
{
    static void Main()
    {
        string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";

        string[] words = text.Split(new char[] { ' ', ',', '.', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        HashSet<string> palindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }

        var sortedPalindromes = palindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToArray();
        Console.WriteLine(string.Join(", ", sortedPalindromes));
    }

    static bool IsPalindrome(string word)
    {
        int len = word.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (char.ToLower(word[i]) != char.ToLower(word[len - 1 - i]))
            {
                return false;
            }
        }
        return true;
    }
}