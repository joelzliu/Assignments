class Program
{
    static void Main()
    {
        string[] urls = {
            "https://www.apple.com/iphone",
            "ftp://www.example.com/employee",
            "https://google.com",
            "www.apple.com"
        };

        foreach (string url in urls)
        {
            ParseUrl(url);
        }
    }

    static void ParseUrl(string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";

        int protocolEnd = url.IndexOf("://");
        if (protocolEnd != -1)
        {
            protocol = url.Substring(0, protocolEnd);
            url = url.Substring(protocolEnd + 3); // Remove protocol and "://"
        }

        int resourceStart = url.IndexOf("/");
        if (resourceStart != -1)
        {
            server = url.Substring(0, resourceStart);
            resource = url.Substring(resourceStart + 1); // Remove "/"
        }
        else
        {
            server = url; // If no resource part
        }

        // Output parsed components
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
        Console.WriteLine();
    }
}