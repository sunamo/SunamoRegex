namespace SunamoRegex.Tests;

/// <summary>
/// Tests for wildcard question mark matching behavior.
/// </summary>
public class QuestionMarkTests
{
    /// <summary>
    /// Tests that a single question mark wildcard matches a single character.
    /// </summary>
    [Fact]
    public void SingleQuestionMarkMatchesSingleCharacter()
    {
        var isMatch = Wildcard.IsMatch("?", "?");
        Assert.True(isMatch);
    }

    /// <summary>
    /// Tests that a question mark does not match multiple characters.
    /// </summary>
    [Fact]
    public void QuestionMarkDoesNotMatchMultipleCharacters()
    {
        var isMatch = Wildcard.IsMatch("ab", "?");
        Assert.False(isMatch);
    }

    /// <summary>
    /// Tests that a wildcard pattern starting with a prefix matches correctly.
    /// </summary>
    [Fact]
    public void WildcardPatternWithPrefixMatchesCorrectly()
    {
        var wildcardRegex = Wildcard.CreateInstance("co*");
        var isMatchingWithPrefix = wildcardRegex.IsMatch("co pokracovani s autorizaci a jwt tokenem");
        var isNotMatchingWithoutPrefix = wildcardRegex.IsMatch("11 pokracovani s autorizaci a jwt tokenem");

        Assert.True(isMatchingWithPrefix);
        Assert.False(isNotMatchingWithoutPrefix);
    }
}
