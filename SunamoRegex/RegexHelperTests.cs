// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
﻿using Xunit;

public class RegexHelperTests
{
    [Fact]
    public void IsUriTest()
    {
        var u = RegexHelper.IsUri(@"https://www.microsoft.com/en-us/security/portal/submission/submit.aspx");
        Assert.True(u);
    }
}
