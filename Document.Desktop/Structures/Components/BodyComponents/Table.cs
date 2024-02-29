using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Components.BodyComponents
{
    public class Table : Component
    {
        private readonly DocumentSystemContext _systemContext;

        private TextContent[][] _table;

        public override bool IsValid
        {
            get
            {
                for(int i = 0; i < _table.Length; i++)
                {
                    for (int j = 0; j < _table[i].Length ; j++)
                    {
                        if (!_table[i][j].IsValid)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public TextContent this[int row, int column]
        {
            get { return _table[row][column]; }
            set { _table[row][column] = value; }
        }

        private Table(DocumentSystemContext systemContext, TextContent[][] table)
        {
            _systemContext = systemContext;
            _table = table;
        }

        public Table(DocumentSystemContext systemContext, int rows, int columns)
        {
            _systemContext = systemContext;

            if (rows < 0 || columns < 0)
            {
                throw new ArgumentOutOfRangeException("Parameters must be greater than or equal to one");
            }

            _table = new TextContent[rows][];
            for (int i = 0; i < _table.Length; i++)
            {
                _table[i] = new TextContent[columns];
            }
        }

        /// <summary>
        /// Append row to table of content
        /// </summary>
        /// <returns>Return a new rows count</returns>
        public int AppendRow()
        {
            Array.Resize(ref _table, _table.Length + 1);

            int columns = 0;
            try
            {
                columns = _table[_table.Length - 1].Length;
            }
            catch (IndexOutOfRangeException ex) { }

            _table[_table.Length - 1] = new TextContent[columns];
            return _table.Length;
        }

        /// <summary>
        /// Remove last row from table of content
        /// </summary>
        /// <returns>Returns a new row count</returns>
        public int RemoveLastRow()
        {
            if (_table.Length == 0)
            {
                return 0;
            }

            Array.Resize(ref _table, _table.Length - 1);
            return _table.Length;
        }
        
        /// <summary>
        /// Append column to table of content
        /// </summary>
        /// <returns>Returns a new columns count</returns>
        public int AppendColumn()
        {
            for (int i = 0; i < _table.Length; i++)
            {
                Array.Resize(ref _table[i], _table[i].Length + 1);
                _table[i][_table[i].Length - 1] = new TextContent(_systemContext, string.Empty);
            }
            return _table.First().Length;
        }

        /// <summary>
        /// Remove last column from all rows
        /// </summary>
        /// <returns>Returns a new columns count</returns>
        public int RemoveLastColumn()
        {
            for (int i = 0; i < _table.Length; i++)
            {
                if (_table[i].Length == 0)
                {
                    return 0;
                }

                Array.Resize(ref _table[i], _table[i].Length - 1);
            }
            return _table.First().Length;
        }

        public override Table Clone(DocumentSystemContext systemContext)
        {
            TextContent[][] table = new TextContent[_table.Length][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new TextContent[_table[i].Length];
                for (int j = 0; j < table[i].Length; j++)
                {
                    table[i][j] = _table[i][j].Clone(systemContext);
                }
            }

            return new Table(systemContext, table)
            {
                InnerFontHeight = InnerFontHeight,
                MarginLeft = MarginLeft,
                MarginRight = MarginRight,
            };
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}