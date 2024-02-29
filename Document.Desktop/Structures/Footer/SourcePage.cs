using Document.Desktop.Contracts;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Footer
{
    public sealed class SourcePage : ICloneable<SourcePage>, IValidable, IDisplayable
    {
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

        private SourcePage(SourceItem[] sources)
        {
            _sources = sources;
        }

        public SourcePage()
        {
            _sources = new SourceItem[0];
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
            _sources[_sources.Length - 1] = new SourceItem(content, url);
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
            throw new NotImplementedException();
        }

        public SourcePage Clone()
        {
            SourceItem[] sources = new SourceItem[_sources.Length];
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i] = _sources[i].Clone();
            }

            return new SourcePage(sources);
        }
    }

    public sealed class SourceItem : ICloneable<SourceItem>, IValidable, IDisplayable
    {
        public TextContent Content { get; set; }
        public string SourceUrl { get; set; } = string.Empty;

        public SourceItem()
        {
            Content = new TextContent(string.Empty);
        }

        public SourceItem(string content, string url)
        {
            Content = new TextContent(content);
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

        public SourceItem Clone() => new SourceItem()
        {
            Content = Content.Clone(),
            SourceUrl = SourceUrl,
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}