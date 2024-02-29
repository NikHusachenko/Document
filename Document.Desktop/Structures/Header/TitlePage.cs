using Document.Desktop.Contracts;
using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Header
{
    public sealed class TitlePage : ICloneable<TitlePage>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

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

        private TitlePage(DocumentSystemContext systemContext)
            : this(systemContext, string.Empty, string.Empty) { }

        public TitlePage(DocumentSystemContext systemContext, string headerLabel, string title)
        {
            _systemContext = systemContext;

            HeaderLabel = new TextContent(_systemContext, headerLabel);
            Title = new TextContent(_systemContext, title);
        }

        public TitlePage Clone(DocumentSystemContext systemContext) => new TitlePage(systemContext)
        {
            HeaderLabel = HeaderLabel.Clone(systemContext),
            Title = Title.Clone(systemContext),
            Stamp = Stamp?.Clone(systemContext)
        };

        public void Display()
        {
            Console.WriteLine(nameof(TitlePage));
            Console.WriteLine(new string('-', Console.WindowWidth));

            HeaderLabel.Display();
            Title.Display();

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}