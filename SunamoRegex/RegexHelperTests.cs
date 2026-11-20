namespace SunamoRegex;

using Xunit;

/// <summary>
/// Represents the regex helper tests type.
/// </summary>
public class RegexHelperTests
{
    /// <summary>
    /// Is uri test.
    /// </summary>
    [Fact]
    public void IsUriTest()
    {
        var isUri = RegexHelper.IsUri(@"https://www.microsoft.com/en-us/security/portal/submission/submit.aspx");
        Assert.True(isUri);
    }
}
