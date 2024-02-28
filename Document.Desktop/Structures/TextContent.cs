using Document.Desktop.Contracts;

namespace Document.Desktop.Structures
{
    public sealed class TextContent : ICloneable<TextContent>, IValidable, IDisplayable
    {
        public string Content { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public TextMargin Margin { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Content);

        public TextContent() : this(string.Empty, false, false) { }

        public TextContent(string content) : this(content, false, false) { }

        public TextContent(string content, bool isBold, bool isItalic)
        {
            Content = content;
            IsBold = isBold;
            IsItalic = isItalic;
        }

        public TextContent Clone() => new TextContent()
        {
            Content = Content,
            Margin = Margin,
            IsBold = IsBold,
            IsItalic = IsItalic,
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }

    public enum TextMargin
    {
        None = 1,
        Left = 2,
        Center = 3,
        Right = 4,
    }
}