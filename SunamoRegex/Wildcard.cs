namespace SunamoRegex;

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
    public new static bool IsMatch(string input, string pattern) =>
        Regex.IsMatch(input, WildcardToRegex(pattern));

    /// <summary>
    /// Creates a new <see cref="Regex"/> instance from a wildcard pattern.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert and compile.</param>
    /// <returns>A <see cref="Regex"/> instance representing the wildcard pattern.</returns>
    public static Regex CreateInstance(string pattern) =>
        new(WildcardToRegex(pattern));

    /// <summary>
    /// Creates a new <see cref="Regex"/> instance from a wildcard pattern with the specified options.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert and compile.</param>
    /// <param name="regexOptions">The regex options to apply.</param>
    /// <returns>A <see cref="Regex"/> instance representing the wildcard pattern.</returns>
    public static Regex CreateInstance(string pattern, RegexOptions regexOptions) =>
        new(WildcardToRegex(pattern), regexOptions);

    /// <summary>
    /// Converts a wildcard pattern to an equivalent regular expression.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert.</param>
    /// <returns>A regex equivalent of the given wildcard pattern.</returns>
    public static string WildcardToRegex(string pattern) =>
        "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
}
