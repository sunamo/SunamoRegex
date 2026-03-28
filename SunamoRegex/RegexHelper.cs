namespace SunamoRegex;

/// <summary>
/// Provides helper methods and precompiled regular expressions for common text validation
/// and pattern matching tasks such as email, URL, phone number, and HTML parsing.
/// </summary>
public static class RegexHelper
{
    /// <summary>
    /// Matches Czech bank account numbers in format [prefix-]account/bankCode.
    /// </summary>
    public static Regex CzechAccountNumberRegex { get; set; } =
        new(@"(?:(\d{1,6})-)?(\d{1,10})/(\d{4})", RegexOptions.Compiled);

    /// <summary>
    /// Matches HTML script tags with their content.
    /// </summary>
    public static Regex HtmlScriptRegex { get; set; } =
        new(@"<script[^>]*>[\s\S]*?</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// Matches HTML comment blocks.
    /// </summary>
    public static Regex HtmlCommentRegex { get; set; } =
        new(@"<!--[^>]*>[\s\S]*?-->", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// Matches YouTube video links and captures the video ID.
    /// </summary>
    public static Regex YtVideoLinkRegex { get; set; } =
        new("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.Compiled);

    /// <summary>
    /// Matches BR tags in HTML (case insensitive by pattern).
    /// </summary>
    public static Regex BrTagCaseInsensitiveRegex { get; set; } = new(@"<br\s*/?>");

    /// <summary>
    /// Matches HTTP and HTTPS URIs.
    /// </summary>
    public static Regex UriRegex { get; set; } = new(@"(https?://[^\s]+)");

    /// <summary>
    /// Matches HTML tags.
    /// </summary>
    public static Regex HtmlTagRegex { get; set; } = new("<\\s*([A-Za-z])*?[^>]*/?>");

    /// <summary>
    /// Matches 6-character hex color codes.
    /// </summary>
    public static Regex Color6Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}$");

    /// <summary>
    /// Matches 8-character hex color codes (with alpha channel).
    /// </summary>
    public static Regex Color8Regex { get; set; } = new(@"^(?:[0-9a-fA-F]{3}){1,2}(?:[0-9a-fA-F]){2}$");

    /// <summary>
    /// Matches HTML pre tags with their content.
    /// </summary>
    public static Regex PreTagWithContentRegex { get; set; } =
        new(@"<\s*pre[^>]*>(.*?)<\s*/\s*pre>", RegexOptions.Multiline);

    /// <summary>
    /// Matches GUID strings with optional braces.
    /// </summary>
    public static Regex GuidRegex { get; set; } =
        new(
            @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$",
            RegexOptions.Compiled);

    /// <summary>
    /// Matches HTML img tags.
    /// </summary>
    public static Regex ImgTagRegex { get; set; } = new(@"<img\s+([^>]*)(.*?)[^>]*>");

    /// <summary>
    /// Matches WordPress image thumbnail URLs with dimensions.
    /// </summary>
    public static Regex WpImgThumbnailRegex { get; set; } =
        new(@"(https?:\/\/([^\s]+)-([0-9]*)x([0-9]*).jpg)");

    /// <summary>
    /// Matches non-pair XML tags that may be invalid.
    /// </summary>
    public static Regex NonPairXmlTagsUnvalidRegex { get; set; } =
        new("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");

    /// <summary>
    /// Matches one or more whitespace characters.
    /// </summary>
    public static readonly Regex WhitespaceRegex = new(@"\s+");

    /// <summary>
    /// Stores the last validated telephone number after calling <see cref="IsTelephone"/>.
    /// </summary>
    public static string? LastTelephone { get; set; }

    /// <summary>
    /// Determines whether the specified text is a valid email address using regex.
    /// </summary>
    /// <param name="text">The text to validate as an email address.</param>
    /// <returns>True if the text matches the email pattern; otherwise, false.</returns>
    public static bool IsEmail(string text)
    {
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return emailRegex.IsMatch(text);
    }

    /// <summary>
    /// Determines whether the specified text is a valid email address using <see cref="System.Net.Mail.MailAddress"/>.
    /// </summary>
    /// <param name="text">The text to validate as an email address.</param>
    /// <returns>True if the text is a valid email address; otherwise, false.</returns>
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
    /// Determines whether the specified text is a valid hex color code (6 or 8 characters).
    /// </summary>
    /// <param name="text">The text to validate as a hex color code.</param>
    /// <returns>True if the text is a valid hex color code; otherwise, false.</returns>
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
    public static bool IsYtVideoUri(string text)
    {
        return YtVideoLinkRegex.IsMatch(text);
    }

    /// <summary>
    /// Replaces plain URLs in text with HTML anchor tags.
    /// Do not use this method - parsing URIs with regex is naive. Use a DOM parser instead.
    /// </summary>
    /// <param name="text">The plain text containing URLs to convert.</param>
    /// <returns>Text with URLs wrapped in anchor tags.</returns>
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
    public static bool IsUri(string text)
    {
        return UriRegex.IsMatch(text) && (text.StartsWith("http://") || text.StartsWith("https://"));
    }

    /// <summary>
    /// Extracts all values from a specific capture group across all matches in a collection.
    /// </summary>
    /// <param name="matchCollection">The match collection to extract values from.</param>
    /// <param name="groupIndex">The zero-based index of the capture group to extract.</param>
    /// <returns>A list of strings from the specified capture group in each match.</returns>
    public static List<string> AllFromGroup(MatchCollection matchCollection, int groupIndex)
    {
        var result = new List<string>(matchCollection.Count);
        foreach (Match match in matchCollection) result.Add(match.Groups[groupIndex].Value);
        return result;
    }

    /// <summary>
    /// Determines whether the specified text is a valid telephone number.
    /// Supports formats with optional leading + and 9 or 12 digit numbers.
    /// The validated number is stored in <see cref="LastTelephone"/>.
    /// </summary>
    /// <param name="text">The text to validate as a telephone number.</param>
    /// <returns>True if the text is a valid telephone number; otherwise, false.</returns>
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
        if (LastTelephone != null)
            LastTelephone = SanitizePhone(LastTelephone);
        return isParsed;
    }

    /// <summary>
    /// Sanitizes a phone number by removing spaces and adding the +420 country code prefix if missing.
    /// </summary>
    /// <param name="text">The phone number text to sanitize.</param>
    /// <returns>The sanitized phone number with country code prefix.</returns>
    public static string SanitizePhone(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        text = text.Replace(" ", "");
        if (!text.StartsWith("+")) text = "+420" + text;
        return text;
    }
}
