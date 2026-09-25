namespace SunamoRegex;

public static class RegexHelper
{
    public static Regex CzechAccountNumberRegex { get; set; } =
        new(@"(?:(\d{1,6})-)?(\d{1,10})/(\d{4})", RegexOptions.Compiled);

    public static Regex HtmlScriptRegex { get; set; } =
        new(@"<script[^>]*>[\s\S]*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static Regex HtmlCommentRegex { get; set; } =
        new(@"<!--[^>]*>[\s\S]*?-->", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static Regex YtVideoLinkRegex { get; set; } =
        new("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.Compiled);

    public static Regex BrTagCaseInsensitiveRegex { get; set; } = new(@"<br\s*/?>");

    public static Regex UriRegex { get; set; } = new(@"(https?://[^\s]+)");

    public static Regex HtmlTagRegex { get; set; } = new("<\\s*([A-Za-z])*?[^>]*/?>");

    public static Regex Color6Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}$");

    public static Regex Color8Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}(?:[0-9a-fA-F]){2}$");

    public static Regex PreTagWithContentRegex { get; set; } =
        new(@"<\s*pre[^>]*>(.*?)<\s*/\s*pre>", RegexOptions.Multiline);

    public static Regex GuidRegex { get; set; } =
        new(
            @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
            RegexOptions.Compiled);

    public static Regex ImgTagRegex { get; set; } = new(@"<img\s+([^>]*)(.*?)[^>]*>");

    public static Regex WpImgThumbnailRegex { get; set; } =
        new(@"(https?:\/\/([^\s]+)-([0-9]*)x([0-9]*).jpg)");

    public static Regex NonPairXmlTagsUnvalidRegex { get; set; } =
        new("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");

    public static readonly Regex WhitespaceRegex = new(@"\s+");

    public static string? LastTelephone { get; set; }

    public static bool IsEmail(string text)
    {
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return emailRegex.IsMatch(text);
    }

    public static bool IsValidEmail(string text)
    {
        var trimmedEmail = text.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(text);
            return mailAddress.Address == trimmedEmail;
        }
        catch (FormatException exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }

    public static bool IsColor(string text)
    {
        text = text.Trim().TrimStart('#');
        if (text.Length == 6)
            return Color6Regex.IsMatch(text);
        if (text.Length == 8) return Color8Regex.IsMatch(text);
        return false;
    }

    public static bool IsYtVideoUri(string text) => YtVideoLinkRegex.IsMatch(text);

    // Do not use this method - parsing URIs with regex is naive. Use a DOM parser instead.
    public static string ReplacePlainUrlWithLinks(string text)
    {
        var html = Regex.Replace(text, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+" +
                                            @"\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?" +
                                            @"([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$",
            "<a href=\"$1\">$1</a>");
        return html;
    }

    public static bool IsUri(string text) =>
        UriRegex.IsMatch(text) && (text.StartsWith("http://") || text.StartsWith("https://"));

    public static List<string> AllFromGroup(MatchCollection matchCollection, int groupIndex)
    {
        var result = new List<string>(matchCollection.Count);
        foreach (Match match in matchCollection) result.Add(match.Groups[groupIndex].Value);
        return result;
    }

    public static bool IsTelephone(string text)
    {
        LastTelephone = null;
        text = WhitespaceRegex.Replace(text, string.Empty);
        var hadPlusPrefix = false;

        if (text == "")
        {
            return false;
        }

        if (text[0] == '+')
        {
            hadPlusPrefix = true;
            text = text.Substring(1);
        }

        if (text.Length != 9 && text.Length != 12) return false;
        var isParsed = long.TryParse(text, out _);
        if (isParsed) LastTelephone = (hadPlusPrefix ? "+" : "") + text;
        if (LastTelephone is not null)
            LastTelephone = SanitizePhone(LastTelephone);
        return isParsed;
    }

    public static string SanitizePhone(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        text = text.Replace(" ", "");
        if (!text.StartsWith("+")) text = "+420" + text;
        return text;
    }
}
