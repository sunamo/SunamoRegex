namespace SunamoRegex;

/// <summary>
/// Provides helper methods for detecting wildcard patterns in strings.
/// </summary>
public class WildcardHelper
{
    /// <summary>
    /// Determines whether the specified text contains wildcard characters (* or ?).
    /// </summary>
    /// <param name="text">The text to check for wildcard characters.</param>
    /// <returns>True if the text contains * or ? characters; otherwise, false.</returns>
    public static bool IsWildcard(string text)
    {
        return text.ToCharArray().Any(character => character == '?') || text.ToCharArray().Any(character => character == '*');
    }
}
