namespace SunamoRegex;

/// <summary>
///     Most NotTranslateAble class due to many regex and duplicated \
/// </summary>
public static class RegexHelper
{
    public static Regex rCzechAccountNumber = new(@"(?:(\d{1,6})-)?(\d{1,10})/(\d{4})", RegexOptions.Compiled);

    public static Regex rHtmlScript =
        new(@"<script[^>]*>[\s\S]*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static Regex rHtmlComment = new(@"<!--[^>]*>[\s\S]*?-->", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static Regex rYtVideoLink = new("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)",
        RegexOptions.Compiled);

    public static Regex rBrTagCaseInsensitive = new(@"<br\s*/?>");

    public static Regex rUri = new(@"(https?://[^\s]+)");

    //static Regex rUriOnlyOutsideTags = new Regex("https?:\/\/[^\s]*|<\/?\w+\b(?=\s|>)(?:='[^']*'|="[^ "]*" |=[^ '"][^\s>]*|[^>])*>|\&nbsp;John|(John)/gi");
    //static Regex rUriOnlyOutsideTags = new Regex("(text|simple)(?![^<]*>|[^<>]*</)");
    // cant compile
    //static Regex rHtmlTag = new Regex(@"(?<==)["']?((?:.(?!["']?\\s+(?:\S+)=|[>"']))+.)["']?");
    public static Regex rHtmlTag = new("<\\s*([A-Za-z])*?[^>]*/?>");
    public static Regex rgColor6 = new(@"^(?:[0-9a-fA-F]{3}){1,2}$");
    public static Regex rgColor8 = new(@"^(?:[0-9a-fA-F]{3}){1,2}(?:[0-9a-fA-F]){2}$");
    public static Regex rPreTagWithContent = new(@"<\s*pre[^>]*>(.*?)<\s*/\s*pre>", RegexOptions.Multiline);

    public static Regex isGuid =
        new(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
            RegexOptions.Compiled);

    public static Regex rImgTag = new(@"<img\s+([^>]*)(.*?)[^>]*>");
    public static Regex rWpImgThumbnail = new(@"(https?:\/\/([^\s]+)-([0-9]*)x([0-9]*).jpg)");
    public static Regex rNonPairXmlTagsUnvalid = new("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");
    public static readonly Regex rWhitespace = new(@"\s+");
    public static string lastTelephone;

    static RegexHelper()
    {
        // this one I unfortunately cant use because I use .net core 2.0, available from 2.1
        // from https://haacked.com/archive/2004/10/25/usingregularexpressionstomatchhtml.aspx/ and https://gist.github.com/Haacked/7729259
        ////HtmlTagRegex.
        //RegexCompilationInfo[] compInfo =
        //{
        //        //HtmlTag Regex.
        //        new RegexCompilationInfo
        //        (
        //            @"<"
        //            +    @"(?<endTag>/)?"    //Captures the / if this is an end tag.
        //            +    @"(?<tagname>\w+)"    //Captures TagName
        //            +    @"("                //Groups tag contents
        //            +        @"(\s+"            //Groups attributes
        //            +            @"(?<attName>\w+)"  //Attribute name
        //            +            @"("                //groups =value portion.
        //            +                @"\s*=\s*"            // =
        //            +                @"(?:"        //Groups attribute "value" portion.
        //            +                    @"""(?<attVal>[^""]*)"""    // attVal='double quoted'
        //            +                    @"|'(?<attVal>[^']*)'"        // attVal='single quoted'
        //            +                    @"|(?<attVal>[^'"">\s]+)"    // attVal=urlnospaces
        //            +                @")"
        //            +            @")?"        //end optional att value portion.
        //            +        @")+\s*"        //One or more attribute pairs
        //            +        @"|\s*"            //Some white space.
        //            +    @")"
        //            + @"(?<completeTag>/)?>" //Captures the "/" if this is a complete tag.
        //            , RegexOptions.IgnoreCase
        //            , "HtmlTagRegex"
        //            , "Haack.RegularExpressions"
        //            , true
        //        )
        //        ,
        //        // Matches double words.
        //        new RegexCompilationInfo
        //        (
        //            @"\b(\w+)\s+\1\b"
        //            , RegexOptions.None
        //            , "DoubleWordRegex"
        //            , "Haack.RegularExpressions", true
        //        )
        //    };
        //AssemblyName assemblyName = new AssemblyName();
        //assemblyName.Name = "Haack.RegularExpressions";
        //assemblyName.Version = new Version("1.0.0.0");
        //Regex.CompileToAssembly(compInfo, assemblyName);
    }

    public static bool IsEmail(string email)
    {
        var r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return r.IsMatch(email);
    }

    public static bool IsValidEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsColor(string entry)
    {
        entry = entry.Trim().TrimStart('#');
        if (entry.Length == 6)
            return rgColor6.IsMatch(entry);
        if (entry.Length == 8) return rgColor8.IsMatch(entry);
        return false;
    }

    public static bool IsYtVideoUri(string text)
    {
        return rYtVideoLink.IsMatch(text);
    }

    /// <summary>
    ///     Dont use, parse uri with regex is total naive . Use DOM parser
    ///     Not working - keep in plain text, use ReplacePlainUrlWithLinks2
    /// </summary>
    /// <param name="plainText"></param>
    public static string ReplacePlainUrlWithLinks(string plainText)
    {
        var html = Regex.Replace(plainText, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+" +
                                            @"\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?" +
                                            @"([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$",
            "<a href=\"$1\">$1</a>");
        return html;
    }

    public static bool IsUri(string text)
    {
        return rUri.IsMatch(text) && (text.StartsWith("http://") || text.StartsWith("https://"));
    }

    public static List<string> AllFromGroup(MatchCollection m, int v)
    {
        var vr = new List<string>(m.Count);
        foreach (Match item in m) vr.Add(item.Groups[v].Value);
        return vr;
    }

    public static bool IsTelephone(string innerText)
    {
        lastTelephone = null;
        innerText = rWhitespace.Replace(innerText, string.Empty);
        var wasPlus = false;

        if (innerText == "")
        {
            return false;
        }

        if (innerText[0] == '+')
        {
            wasPlus = true;
            innerText = innerText.Substring(1);
        }

        if (innerText.Length != 9 && innerText.Length != 12) return false;
        var result = long.TryParse(innerText, out var ol);
        if (result) lastTelephone = (wasPlus ? "+" : "") + innerText;
        if (lastTelephone != null)
            // sanitize to common format
            lastTelephone = SanitizePhone(lastTelephone);
        return result;
    }

    public static string SanitizePhone(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return s;
        s = s.Replace(" ", "");
        if (!s.StartsWith("+")) s = "+420" + s;
        return s;
    }
}