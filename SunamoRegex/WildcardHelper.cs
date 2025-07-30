namespace SunamoRegex;

public class WildcardHelper
{
    public static bool IsWildcard(string text)
    {
        return text.ToCharArray().Any(d => d == '?') || text.ToCharArray().Any(d => d == '*');
    }
}