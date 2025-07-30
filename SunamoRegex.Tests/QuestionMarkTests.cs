namespace SunamoRegex.Tests;
public class QuestionMarkTests
{
    [Fact]
    public void a()
    {
        // všechno bude true
        //var b = Wildcard.IsMatch("?", "\\?");
        //var b2 = Wildcard.IsMatch("??", "\\?");
        //var b3 = Wildcard.IsMatch("?!", "\\?");
        //var b4 = Wildcard.IsMatch("!?", "\\?");


    }

    [Fact]
    public void b()
    {
        // všechno bude true
        var r = Wildcard.CreateInstance("co*");
        var b1 = r.IsMatch("11 pokračování s autorizací a jwt tokenem");
        var b2 = r.IsMatch("co pokračování s autorizací a jwt tokenem");
    }
}

