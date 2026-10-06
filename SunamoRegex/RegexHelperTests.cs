namespace SunamoRegex;

using Xunit;

public class RegexHelperTests
{
    [Fact]
    public void IsUriTest()
    {
        var isUri = RegexHelper.IsUri(@"https://www.microsoft.com/en-us/security/portal/submission/submit.aspx");
        Assert.True(isUri);
    }
}
