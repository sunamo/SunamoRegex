using System.Text;
using System.Text.RegularExpressions;

namespace SunamoRegex.Tests;

/// <summary>
/// Tests for <see cref="RegexHelper"/> methods.
/// </summary>
public class RegexHelperTests
{
    /// <summary>
    /// Tests telephone number validation with whitespace-heavy input.
    /// </summary>
    [Fact]
    public void IsTelephoneTest()
    {
        var isTelephone = RegexHelper.IsTelephone(@"













											");
        Assert.False(isTelephone);
    }

    /// <summary>
    /// Tests Czech account number extraction from a block of text.
    /// </summary>
    [Fact]
    public void CzechAccountNumbersTest()
    {
        var input = @"341944165/0300 3265290/Rosalinda34
3200117143/0800 tvoje_madam_69
2648539016/3030
336436684/0300
4973929033/0800
264095613/0600
2302596785/2010";

        MatchCollection matchCollection = RegexHelper.CzechAccountNumberRegex.Matches(input);

        List<string> accountNumbers = new();

        foreach (Match match in matchCollection)
        {
            accountNumbers.Add(match.Value);
        }

        Assert.True(accountNumbers.Count > 0);

        StringBuilder stringBuilder = new();

        foreach (var item in accountNumbers)
        {
            stringBuilder.AppendLine(item);
        }

        var text = stringBuilder.ToString();
        Assert.False(string.IsNullOrWhiteSpace(text));
    }
}
