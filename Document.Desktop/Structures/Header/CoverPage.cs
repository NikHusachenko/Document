using Document.Desktop.Contracts;
using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Header
{
    public sealed class CoverPage : ICloneable<CoverPage>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        public TextContent Title { get; set; }
        public TextContent Subtitle { get; set; }
        public TextContent Author { get; set; }

        private CoverPage(DocumentSystemContext systemContext) 
            : this(systemContext, string.Empty, string.Empty) { }

        public CoverPage(DocumentSystemContext systemContext, string title, string author)
        {
            _systemContext = systemContext;

            Title = new TextContent(_systemContext, title);
            Subtitle = new TextContent(_systemContext, string.Empty);
            Author = new TextContent(_systemContext, author);
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

        public CoverPage Clone(DocumentSystemContext systemContext) => new CoverPage(systemContext) 
        { 
            Title = Title.Clone(systemContext),
            Subtitle = Subtitle.Clone(systemContext),
            Author = Author.Clone(systemContext)
        };

        public void Display()
        {
            Console.WriteLine(nameof(CoverPage));
            Console.WriteLine(new string('-', Console.WindowWidth));

            Title.Display();
            Subtitle.Display();
            Author.Display();

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}