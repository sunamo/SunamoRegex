namespace SunamoRegex;

using Xunit;

/// <summary>
/// Basic tests for <see cref="RegexHelper"/> methods within the library project.
/// </summary>
public class RegexHelperTests
{
    /// <summary>
    /// Tests that a valid HTTPS URI is correctly identified.
    /// </summary>
    [Fact]
    public void IsUriTest()
    {
        var isUri = RegexHelper.IsUri(@"https://www.microsoft.com/en-us/security/portal/submission/submit.aspx");
        Assert.True(isUri);
    }
}
