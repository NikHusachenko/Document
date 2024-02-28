using Document.Desktop.Contracts;
using Document.Desktop.Structures.Components;

namespace Document.Desktop.Structures.Header
{
    public sealed class TitlePage : ICloneable<TitlePage>, IValidable, IDisplayable
    {
        public TextContent HeaderLabel { get; set; }
        public TextContent Title { get; set; }
        public Stamp? Stamp { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(HeaderLabel.Content) ||
                    string.IsNullOrWhiteSpace(Title.Content))
                {
                    return false;
                }

                return true;
            }
        }

        private TitlePage() { }

        public TitlePage(string headerLabel, string title)
        {
            HeaderLabel = new TextContent(headerLabel);
            Title = new TextContent(title);
        }

        public TitlePage Clone() => new TitlePage()
        {
            HeaderLabel = HeaderLabel.Clone(),
            Title = Title.Clone(),
            Stamp = Stamp?.Clone()
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}