namespace SunamoRegex;

/// <summary>
/// Provides wildcard pattern matching built on top of the <see cref="System.Text.RegularExpressions.Regex"/> engine.
/// Cannot be derived directly from Regex because then a wildcard would be passed where a regex is expected.
/// An instance must be created via <see cref="CreateInstance(string)"/> to ensure proper wildcard-to-regex conversion.
/// </summary>
public class Wildcard : Regex
{
    private Wildcard()
    {
    }

    /// <summary>
    /// Determines whether the input string matches the specified wildcard pattern.
    /// </summary>
    /// <param name="input">The input string to match against.</param>
    /// <param name="pattern">The wildcard pattern using * and ? characters.</param>
    /// <returns>True if the input matches the wildcard pattern; otherwise, false.</returns>
    public new static bool IsMatch(string input, string pattern)
    {
        return Regex.IsMatch(input, WildcardToRegex(pattern));
    }

    /// <summary>
    /// Creates a new <see cref="Regex"/> instance from a wildcard pattern.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert and compile.</param>
    /// <returns>A <see cref="Regex"/> instance representing the wildcard pattern.</returns>
    public static Regex CreateInstance(string pattern)
    {
        return new Regex(WildcardToRegex(pattern));
    }

    /// <summary>
    /// Creates a new <see cref="Regex"/> instance from a wildcard pattern with the specified options.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert and compile.</param>
    /// <param name="regexOptions">The regex options to apply.</param>
    /// <returns>A <see cref="Regex"/> instance representing the wildcard pattern.</returns>
    public static Regex CreateInstance(string pattern, RegexOptions regexOptions)
    {
        return new Regex(WildcardToRegex(pattern), regexOptions);
    }

    /// <summary>
    /// Converts a wildcard pattern to an equivalent regular expression.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert.</param>
    /// <returns>A regex equivalent of the given wildcard pattern.</returns>
    public static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
    }
}
