using Document.Desktop.Management;
using Document.Desktop.Structures.Components.Common;

namespace Document.Desktop.Structures.Components.BodyComponents
{
    public class List : Component
    {
        private readonly DocumentSystemContext _systemContext;

        private TextContent[] _list;

        public ListType Type { get; private set; }

        public override bool IsValid
        {
            get
            {
                for (int i = 0; i < _list.Length; i++)
                {
                    if (!_list[i].IsValid)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        
        public int Count => _list.Length;

        public string this[int index]
        {
            get { return _list[index].Content; }
            set { _list[index].Content = value; }
        }

        public List(DocumentSystemContext systemContext, ListType listType)
        {
            _systemContext = systemContext;
            _list = [];

            Type = listType;
        }

        public void ChangeListType (ListType listType) => Type = listType;

        /// <summary>
        /// Append Invalid item to end of list
        /// </summary>
        /// <returns>Returns a new instance of list item</returns>
        public TextContent AppendItem(string content)
        {
            Array.Resize(ref _list, _list.Length + 1);
            _list[_list.Length - 1] = new TextContent(_systemContext, content);
            return _list[_list.Length - 1];
        }

        /// <summary>
        /// Remove last item from list
        /// </summary>
        /// <returns>Returns a new length of list</returns>
        public int RemoveLastItem()
        {
            if (_list.Length == 0)
            {
                return 0;
            }

            Array.Resize(ref _list, _list.Length - 1);
            return _list.Length;
        }

        public override void Display()
        {
            Console.WriteLine(new string('*', Console.WindowWidth));

            Console.WriteLine(nameof(List));
            foreach (TextContent item in _list)
            {
                item.Display();
            }

            Console.WriteLine(new string('*', Console.WindowWidth));
        }

        public override List Clone(DocumentSystemContext systemContext)
        {
            TextContent[] list = new TextContent[_list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = _list[i].Clone(systemContext);
            }

            return new List(systemContext, Type)
            {
                InnerFontHeight = InnerFontHeight,
                MarginLeft = MarginLeft,
                MarginRight = MarginRight,
                _list = list,
            };
        }
    }

    public enum ListType
    {
        Numerable = 1,
        Enumerable = 2,
    }
}