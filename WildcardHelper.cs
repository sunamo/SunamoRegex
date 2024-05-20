namespace
#if SunamoStringReplace
SunamoStringReplace
#else
SunamoRegex
#endif
;
public class WildcardHelper
{
    public static bool IsWildcard(string text)
    {
        return text.ToCharArray().Any(d => d == AllChars.q) || text.ToCharArray().Any(d => d == AllChars.asterisk);
    }
}