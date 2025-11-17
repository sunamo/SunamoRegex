
using SunamoStringSplit;

public class WildcardTests
{
    [Fact]
    public void WildcardTest()
    {
        var input = @"https://www.facebook.com/name.surname/photos_albums";
        var wildcard = @"https://www.facebook.com/*/photos_albums";

        var wc = Wildcard.CreateInstance(wildcard);

        var regex = Wildcard.WildcardToRegex(wildcard);
        var matches = SHSplit.SplitAndReturnRegexMatches(input, new System.Text.RegularExpressions.Regex(regex));

        // EN: Verify that wildcard pattern matching works
        // CZ: Ověření že wildcard pattern matching funguje
        Assert.True(wc.IsMatch(input));
    }

    [Fact]
    public void WildcardTest1()
    {
        var input = "<M C=\"a\">";
        var wildcard = @"<M C=""*"">";

        var wc = Wildcard.CreateInstance(wildcard);

        var regex = Wildcard.WildcardToRegex(wildcard);
        var matches = SHSplit.SplitAndReturnRegexMatches(input, new System.Text.RegularExpressions.Regex(regex));

        // EN: Verify that wildcard pattern matching works for XML attributes
        // CZ: Ověření že wildcard pattern matching funguje pro XML atributy
        Assert.True(wc.IsMatch(input));
    }
}
