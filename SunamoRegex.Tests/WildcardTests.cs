using SunamoStringSplit;

/// <summary>
/// Tests for <see cref="Wildcard"/> pattern matching functionality.
/// </summary>
public class WildcardTests
{
    /// <summary>
    /// Tests wildcard matching against a Facebook URL with a path segment.
    /// </summary>
    [Fact]
    public void WildcardTest()
    {
        var input = @"https://www.facebook.com/name.surname/photos_albums";
        var wildcardPattern = @"https://www.facebook.com/*/photos_albums";

        var wildcardRegex = Wildcard.CreateInstance(wildcardPattern);

        var regexPattern = Wildcard.WildcardToRegex(wildcardPattern);
        var matchCollection = SHSplit.SplitAndReturnRegexMatches(input, new System.Text.RegularExpressions.Regex(regexPattern));

        Assert.Matches(wildcardRegex, input);
    }

    /// <summary>
    /// Tests wildcard matching against an XML tag with a quoted attribute value.
    /// </summary>
    [Fact]
    public void WildcardWithXmlAttributeTest()
    {
        var input = "<M C=\"a\">";
        var wildcardPattern = @"<M C=""*"">";

        var wildcardRegex = Wildcard.CreateInstance(wildcardPattern);

        var regexPattern = Wildcard.WildcardToRegex(wildcardPattern);
        var matchCollection = SHSplit.SplitAndReturnRegexMatches(input, new System.Text.RegularExpressions.Regex(regexPattern));

        Assert.Matches(wildcardRegex, input);
    }
}
