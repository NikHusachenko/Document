using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Body
{
    public sealed class BodyStructure : ICloneable<BodyStructure>, IValidable, IDisplayable
    {
        private Page[] _pages;

        public bool IsValid
        {
            get
            {
                for (int i = 0; i < _pages.Length; i++)
                {
                    if (!_pages[i].IsValid)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public int Length => _pages.Length;
        public Page this[int index] => _pages[index];

        public BodyStructure()
        {
            _pages = new Page[0];
        }

        private BodyStructure(Page[] pages)
        {
            _pages = pages;
        }

        public static BodyStructure BuildDefault() => new BodyStructure(new Page[0]);
        
        /// <summary>
        /// Append a new Page to pages array
        /// </summary>
        /// <returns>Return a new length of pages array</returns>
        public Page AppendPageToEnd()
        {
            Array.Resize(ref _pages, _pages.Length + 1);
            _pages[_pages.Length - 1] = new Page();
            return _pages[_pages.Length - 1];
        }

        /// <summary>
        /// Remove last Page from pages array
        /// </summary>
        /// <returns>Returns a new length of pages array</returns>
        public int RemoveLastPage()
        {
            Array.Resize(ref _pages, _pages.Length - 1);
            return _pages.Length;
        }

        public BodyStructure Clone()
        {
            Page[] pages = new Page[_pages.Length];
            for (int i = 0; i < _pages.Length; i++)
            {
                pages[i] = _pages[i].Clone();
            }

            return new BodyStructure(pages);
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}