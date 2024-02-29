namespace Document.Desktop.Extensions
{
    public static class DisplayTextContent
    {
        public static string DisplayBold(this string content) 
            => !string.IsNullOrWhiteSpace(content) ? $"**{content}**" : string.Empty;

        public static string DisplayItalic(this string content) 
            => !string.IsNullOrWhiteSpace(content) ? $"``{content}``" : string.Empty;
    }
}