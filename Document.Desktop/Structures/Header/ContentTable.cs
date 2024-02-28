using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Header
{
    public sealed class ContentTable : ICloneable<ContentTable>, IValidable, IDisplayable
    {
        private ContentTableItem[] _table;

        public bool IsValid
        {
            get
            {
                if (_table.Length == 0)
                {
                    return true;
                }

                return _table.FirstOrDefault(item => !item.IsValid) == null;
            }
        }

        public string this[int index]
        {
            get { return _table[index].Content; }
            set { _table[index].Content = value; }
        }

        public int Length => _table.Length;

        private ContentTable(ContentTableItem[] table)
        {
            _table = table;
        }

        public ContentTable()
        {
            _table = new ContentTableItem[0];
        }

        /// <summary>
        /// Append empty Invalid item to end of content table
        /// </summary>
        /// <returns>Returns a new length of content table</returns>
        public int Append(string label)
        {
            Array.Resize(ref _table, _table.Length + 1);
            _table[_table.Length - 1] = new ContentTableItem(label, _table.Length - 1);
            return _table.Length;
        }

        /// <summary>
        /// Remove item from end of content table
        /// </summary>
        /// <returns>Returns a new length of content table</returns>
        public int RemoveLast()
        {
            Array.Resize(ref _table, _table.Length - 1);
            return _table.Length;
        }

        public ContentTable Clone()
        {
            ContentTableItem[] cloneTable = new ContentTableItem[_table.Length];
            foreach (ContentTableItem item in _table)
            {
                cloneTable[item.Index] = item.Clone();
            }

            return new ContentTable(cloneTable);
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ContentTableItem : ICloneable<ContentTableItem>, IValidable, IDisplayable
    {
        public string Content { get; set; } = string.Empty;
        public int Index { get; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Content))
                {
                    return false;
                }

                if (Index <= 0)
                {
                    return false;
                }

                return true;
            }
        }

        public ContentTableItem(string content, int index)
        {
            Content = content;
            Index = index;
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public ContentTableItem Clone() => new ContentTableItem(Content, Index);
    }
}