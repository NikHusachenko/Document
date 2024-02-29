namespace Document.Desktop.Extensions
{
    public static class DisplayTextContent
    {
        public static string DisplayBold(this string content) => $"**{content}**";
        public static string DisplayItalic(this string content) => $"``{content}``";
    }
}