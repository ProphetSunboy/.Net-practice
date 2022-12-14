using System.Text.RegularExpressions;

try
{
    string s = Console.ReadLine();
    Regex regex = new Regex(@"[^0-9]([1-9]{1,2})[^0-9]");
    MatchCollection matches = regex.Matches(s);
    if (matches.Count > 0)
    {
        foreach (Match match in matches)
            Console.WriteLine(match.Groups[1]);
    }
    else
    {
        Console.WriteLine("Совпадений не найдено");
    }
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}       