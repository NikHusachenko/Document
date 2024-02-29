using Document.Desktop.Contracts;
using Document.Desktop.Management;

namespace Document.Desktop.Structures.Header
{
    public sealed class ContentTable : ICloneable<ContentTable>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;
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

        private ContentTable(DocumentSystemContext systemContext, ContentTableItem[] table)
        {
            _systemContext = systemContext;
            _table = table;
        }

        public ContentTable(DocumentSystemContext systemContext) : this(systemContext, []) { }

        /// <summary>
        /// Append empty Invalid item to end of content table
        /// </summary>
        /// <returns>Returns a new length of content table</returns>
        public int Append(string label)
        {
            Array.Resize(ref _table, _table.Length + 1);
            _table[_table.Length - 1] = new ContentTableItem(_systemContext, label, _table.Length - 1);
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

        public ContentTable Clone(DocumentSystemContext systemContext)
        {
            ContentTableItem[] cloneTable = new ContentTableItem[_table.Length];
            foreach (ContentTableItem item in _table)
            {
                cloneTable[item.Index] = item.Clone(systemContext);
            }

            return new ContentTable(systemContext, cloneTable);
        }

        public void Display()
        {
            Console.WriteLine(nameof(ContentTable));
            Console.WriteLine(new string('-', Console.WindowWidth));
            
            foreach (ContentTableItem item in _table)
            {
                item.Display();
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }

    public sealed class ContentTableItem : ICloneable<ContentTableItem>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        public string Content { get; set; } = string.Empty;
        public int Index { get; set; }

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

        public ContentTableItem(DocumentSystemContext systemContext, string content, int index)
        {
            _systemContext = systemContext;
            Content = content;
            Index = index;
        }

        public void Display()
        {
            Console.WriteLine($"[{Index}] {Content}");
        }

        public ContentTableItem Clone(DocumentSystemContext systemContext) => new ContentTableItem(systemContext, Content, Index);
    }
}