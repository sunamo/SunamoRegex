namespace SunamoRegex;

/// <summary>
/// Represents the regex helper type.
/// </summary>
public static class RegexHelper
{
    /// <summary>
    /// Gets or sets the czech account number regex.
    /// </summary>
    public static Regex CzechAccountNumberRegex { get; set; } =
        new(@"(?:(\d{1,6})-)?(\d{1,10})/(\d{4})", RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the html script regex.
    /// </summary>
    public static Regex HtmlScriptRegex { get; set; } =
        new(@"<script[^>]*>[\s\S]*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the html comment regex.
    /// </summary>
    public static Regex HtmlCommentRegex { get; set; } =
        new(@"<!--[^>]*>[\s\S]*?-->", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the yt video link regex.
    /// </summary>
    public static Regex YtVideoLinkRegex { get; set; } =
        new("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the br tag case insensitive regex.
    /// </summary>
    public static Regex BrTagCaseInsensitiveRegex { get; set; } = new(@"<br\s*/?>");

    /// <summary>
    /// Gets or sets the uri regex.
    /// </summary>
    public static Regex UriRegex { get; set; } = new(@"(https?://[^\s]+)");

    /// <summary>
    /// Gets or sets the html tag regex.
    /// </summary>
    public static Regex HtmlTagRegex { get; set; } = new("<\\s*([A-Za-z])*?[^>]*/?>");

    /// <summary>
    /// Gets or sets the color 6 regex.
    /// </summary>
    public static Regex Color6Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}$");

    /// <summary>
    /// Gets or sets the color 8 regex.
    /// </summary>
    public static Regex Color8Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}(?:[0-9a-fA-F]){2}$");

    /// <summary>
    /// Gets or sets the pre tag with content regex.
    /// </summary>
    public static Regex PreTagWithContentRegex { get; set; } =
        new(@"<\s*pre[^>]*>(.*?)<\s*/\s*pre>", RegexOptions.Multiline);

    /// <summary>
    /// Gets or sets the guid regex.
    /// </summary>
    public static Regex GuidRegex { get; set; } =
        new(
            @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
            RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the img tag regex.
    /// </summary>
    public static Regex ImgTagRegex { get; set; } = new(@"<img\s+([^>]*)(.*?)[^>]*>");

    /// <summary>
    /// Gets or sets the wp img thumbnail regex.
    /// </summary>
    public static Regex WpImgThumbnailRegex { get; set; } =
        new(@"(https?:\/\/([^\s]+)-([0-9]*)x([0-9]*).jpg)");

    /// <summary>
    /// Gets or sets the non pair xml tags unvalid regex.
    /// </summary>
    public static Regex NonPairXmlTagsUnvalidRegex { get; set; } =
        new("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");

    /// <summary>
    /// The whitespace regex.
    /// </summary>
    public static readonly Regex WhitespaceRegex = new(@"\s+");

    /// <summary>
    /// Gets or sets the last telephone.
    /// </summary>
    public static string? LastTelephone { get; set; }

    /// <summary>
    /// Is email.
    /// </summary>
    /// <param name="@"^(?:[0-9a-fA-F]{3}){1,2}$"">The 0 9 a f a f 3 1 2.</param>
    /// <returns>The is email result.</returns>
    public static bool IsEmail(string text)
    {
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return emailRegex.IsMatch(text);
    }

    /// <summary>
    /// Is valid email.
    /// </summary>
    /// <param name="RegexOptions.Multiline">The regex options multiline.</param>
    /// <returns>The is valid email result.</returns>
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

    /// <summary>
    /// Is color.
    /// </summary>
    /// <param name="@"(https?:\/\/([^\s]+)-([0-9]*)x([0-9]*).jpg)"">The https s 0 9 x 0 9 jpg.</param>
    /// <returns>The is color result.</returns>
    public static bool IsColor(string text)
    {
        text = text.Trim().TrimStart('#');
        if (text.Length == 6)
            return Color6Regex.IsMatch(text);
        if (text.Length == 8) return Color8Regex.IsMatch(text);
        return false;
    }

    /// <summary>
    /// Determines whether the specified text is a YouTube video URI.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <returns>True if the text matches a YouTube video URI pattern; otherwise, false.</returns>
    public static bool IsYtVideoUri(string text) => YtVideoLinkRegex.IsMatch(text);

    // Do not use this method - parsing URIs with regex is naive. Use a DOM parser instead.
    /// <summary>
    /// Replace plain url with links.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The replace plain url with links result.</returns>
    public static string ReplacePlainUrlWithLinks(string text)
    {
        var html = Regex.Replace(text, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+" +
                                            @"\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?" +
                                            @"([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$",
            "<a href=\"$1\">$1</a>");
        return html;
    }

    /// <summary>
    /// Determines whether the specified text is an HTTP or HTTPS URI.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <returns>True if the text is a valid HTTP/HTTPS URI; otherwise, false.</returns>
    public static bool IsUri(string text) =>
        UriRegex.IsMatch(text) && (text.StartsWith("http://") || text.StartsWith("https://"));

    /// <summary>
    /// All from group.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The all from group result.</returns>
    public static List<string> AllFromGroup(MatchCollection matchCollection, int groupIndex)
    {
        var result = new List<string>(matchCollection.Count);
        foreach (Match match in matchCollection) result.Add(match.Groups[groupIndex].Value);
        return result;
    }

    /// <summary>
    /// Initializes a new instance of the is telephone class.
    /// </summary>
    /// <param name="exception">The exception.</param>
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

    /// <summary>
    /// Sanitize phone.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="@"([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\">The a z a z 0 9 amp.</param>
    /// <param name="href">The href.</param>
    /// <returns>The sanitize phone result.</returns>
    public static string SanitizePhone(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        text = text.Replace(" ", "");
        if (!text.StartsWith("+")) text = "+420" + text;
        return text;
    }
}
