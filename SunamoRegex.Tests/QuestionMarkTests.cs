// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoRegex.Tests;
public class QuestionMarkTests
{
    [Fact]
    public void a()
    {
        // všechno bude true
        //var builder = Wildcard.IsMatch("?", "\\?");
        //var b2 = Wildcard.IsMatch("??", "\\?");
        //var b3 = Wildcard.IsMatch("?!", "\\?");
        //var b4 = Wildcard.IsMatch("!?", "\\?");


    }

    [Fact]
    public void builder()
    {
        // všechno bude true
        var result = Wildcard.CreateInstance("co*");
        var b1 = result.IsMatch("11 pokračování s autorizací a jwt tokenem");
        var b2 = result.IsMatch("co pokračování s autorizací a jwt tokenem");
    }
}

