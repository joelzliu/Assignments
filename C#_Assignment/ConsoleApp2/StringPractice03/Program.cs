class Program
{
    static void Main()
    {
        string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";

        string[] words = text.Split(new char[] { ' ', ',', '.', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        HashSet<string> palins = new HashSet<string>();
        foreach(string word in words)
        {
            if(IsPalindrome(word))
                palins.Add(word);
        }

        var sortedPalindromes = palins.OrderBy(p => p).ToArray();
        Console.WriteLine(string.Join(", ", sortedPalindromes));
    }

    static bool IsPalindrome(string word)
    {
        int len = word.Length;
        for(int i = 0; i < len / 2; i++)
        {
            if(word[i] != word[len - 1 - i])
                return false;
        }
        return true;
    }
}