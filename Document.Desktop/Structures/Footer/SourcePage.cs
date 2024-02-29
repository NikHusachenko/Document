using Document.Desktop.Contracts;
using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Footer
{
    public sealed class SourcePage : ICloneable<SourcePage>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        private SourceItem[] _sources;

        public bool IsValid
        {
            get
            {
                for (int i = 0; i < _sources.Length; i++)
                {
                    if (!_sources[i].IsValid)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        
        public int Count => _sources.Length;

        public SourceItem this[int index]
        {
            get { return _sources[index]; }
            set { _sources[index] = value; }
        }

        public SourcePage(DocumentSystemContext systemContext) : this(systemContext, []) { }

        private SourcePage(DocumentSystemContext systemContext, SourceItem[] sources)
        {
            _systemContext = systemContext;
            _sources = sources;
        }

        /// <summary>
        /// Append new source url to end of list
        /// </summary>
        /// <param name="content">Displaying text of source</param>
        /// <param name="url">URL to source</param>
        /// <returns>Returns a new Instance of sources list</returns>
        public SourceItem Append(string content, string url)
        {
            Array.Resize(ref _sources, _sources.Length + 1);
            _sources[_sources.Length - 1] = new SourceItem(_systemContext, content, url);
            return _sources[_sources.Length - 1];
        }

        /// <summary>
        /// Remove last item from list of sources
        /// </summary>
        /// <returns>Returns a new length of sources list</returns>
        public int RemoveLast()
        {
            Array.Resize(ref _sources, _sources.Length - 1);
            return _sources.Length;
        }

        public void Display()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(nameof(SourcePage));

            foreach (var item in _sources)
            {
                item.Display();
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        public SourcePage Clone(DocumentSystemContext systemContext)
        {
            SourceItem[] sources = new SourceItem[_sources.Length];
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i] = _sources[i].Clone(systemContext);
            }

            return new SourcePage(systemContext, sources);
        }
    }

    public sealed class SourceItem : ICloneable<SourceItem>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        public TextContent Content { get; set; }
        public string SourceUrl { get; set; } = string.Empty;

        public SourceItem(DocumentSystemContext systemContext) 
            : this(systemContext, string.Empty, string.Empty) { }

        public SourceItem(DocumentSystemContext systemContext, string content, string url)
        {
            _systemContext = systemContext;
            Content = new TextContent(_systemContext, content);
            SourceUrl = url;
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(SourceUrl))
                {
                    return false;
                }

                return Content.IsValid;
            }
        }

        public SourceItem Clone(DocumentSystemContext systemContext) => new SourceItem(systemContext)
        {
            Content = Content.Clone(systemContext),
            SourceUrl = SourceUrl,
        };

        public void Display()
        {
            Content.Display();
            Console.WriteLine(SourceUrl);
        }
    }
}