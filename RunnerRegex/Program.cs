using SunamoRegex.Tests;

namespace RunnerRegex;

internal class Program
{
    static void Main()
    {
        //var d = new QuestionMarkTests();
        //d.b();

        var t = new RegexHelperTests();
        //t.CzechAccountNumbersTest();
        t.IsTelephoneTest();
    }
}
