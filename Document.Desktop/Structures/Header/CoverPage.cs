using Document.Desktop.Contracts;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Header
{
    public sealed class CoverPage : ICloneable<CoverPage>, IValidable, IDisplayable
    {
        public TextContent Title { get; set; }
        public TextContent Subtitle { get; set; }
        public TextContent Author { get; set; }

        public CoverPage() { }

        public CoverPage(string title, string author)
        {
            Title = new TextContent(title);
            Subtitle = new TextContent(string.Empty);
            Author = new TextContent(author);
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Title.Content))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Author.Content))
                {
                    return false;
                }

                return true;
            }
        }

        public CoverPage Clone() => new CoverPage() 
        { 
            Title = Title.Clone(), 
            Subtitle = Subtitle.Clone(),
            Author = Author.Clone()
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}