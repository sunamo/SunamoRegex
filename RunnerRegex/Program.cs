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

        var temp = new RegexHelperTests();
        //temp.CzechAccountNumbersTest();
        temp.IsTelephoneTest();
    }
}
