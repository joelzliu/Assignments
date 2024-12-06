class Program
{
    static void Main()
    {
        string input1 = "C# is not C++, and PHP is not Delphi!";
        string input2 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/.";

        Console.WriteLine(ReverseWords(input1));
        Console.WriteLine(ReverseWords(input2));
    }

    static string ReverseWords(string sentence)
    {
        char[] separators = { '.', ',', ';', ':', '(', ')', '&', '[', ']', '"', '\'', '/', '!', '?', ' ' };
        List<string> words = new List<string>();
        List<string> separatorsList = new List<string>();

        string currWord = "";
        foreach(char ch in sentence)
        {
            if(Array.Exists(separators, sep => sep == ch))
            {
                if(!string.IsNullOrEmpty(currWord))
                {
                    words.Add(currWord);
                    currWord = "";
                }

                separatorsList.Add(ch.ToString());
            }
            else
            {
                currWord += ch;
            }
        }

        // Add the last word
        if(!string.IsNullOrEmpty(currWord))
        {
            words.Add(currWord);
        }

        words.Reverse();

        string res = "";
        int wordIdx = 0;

        foreach(string separator in separatorsList)
        {
            if (wordIdx < words.Count)
            {
                res += words[wordIdx];
                wordIdx++;
            }

            res += separator;
        }

        if (wordIdx < words.Count)
            res += words[wordIdx];

        return res;
    }
}