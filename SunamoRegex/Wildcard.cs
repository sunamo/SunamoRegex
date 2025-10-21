// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoRegex;

/// <summary>
///     Represents a wildcard running on the
///     <see cref="System.Text.RegularExpressions" /> engine.
///     Nemůžu to odvodit přímo z Regexu, protože pak předávám wildcard tam kde se očekává regex (předávám to přímo např. do Regex.IsMatch)
///     Je třeba vytvořit instanci Wildcard, protože jak volám Wildcard.IsRegex nepoužívám wildcard ať tam vložím cokoliv!
/// </summary>
public class Wildcard : Regex
{
    private Wildcard()
    {

    }

    public static bool IsMatch(string input, string pattern)
    {
        return Regex.IsMatch(input, WildcardToRegex(pattern));
    }

    public static Regex CreateInstance(string pattern)
    {
        return new Regex(WildcardToRegex(pattern));
    }

    public static Regex CreateInstance(string pattern, RegexOptions options)
    {
        return new Regex(WildcardToRegex(pattern), options);
    }

    /// <summary>
    ///     Converts a wildcard to a regex.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert.</param>
    /// <returns>A regex equivalent of the given wildcard.</returns>
    public static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
    }
}