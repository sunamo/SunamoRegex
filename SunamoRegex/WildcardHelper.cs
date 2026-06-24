namespace SunamoRegex;

public class WildcardHelper
{
    public static bool IsWildcard(string text) =>
        text.ToCharArray().Any(character => character == '?') || text.ToCharArray().Any(character => character == '*');
}
