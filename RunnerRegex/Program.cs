// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using SunamoRegex.Tests;

namespace RunnerRegex;

internal class Program
{
    static void Main()
    {
        //var data = new QuestionMarkTests();
        //data.b();

        // EN: Test methods cannot be called directly as they are marked with [Fact] attribute
        // CZ: Testovací metody nelze volat přímo, protože jsou označeny atributem [Fact]
        var regexTests = new RegexHelperTests();
        //regexTests.CzechAccountNumbersTest();
        //regexTests.IsTelephoneTest();
    }
}
