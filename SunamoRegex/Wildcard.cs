namespace SunamoRegex;

public class Wildcard : Regex
{
    private Wildcard()
    {
    }

    public new static bool IsMatch(string input, string pattern) =>
        Regex.IsMatch(input, WildcardToRegex(pattern));

    public static Regex CreateInstance(string pattern) =>
        new(WildcardToRegex(pattern));

    public static Regex CreateInstance(string pattern, RegexOptions regexOptions) =>
        new(WildcardToRegex(pattern), regexOptions);

    public static string WildcardToRegex(string pattern) =>
        "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
}
