using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Header
{
    public sealed class HeaderStructure : ICloneable<HeaderStructure>, IValidable, IDisplayable
    {
        private const string DEFAULT_COVER_TITLE = "Default title here";
        private const string DEFAULT_AUTHOR_NAME = "Default author name here";
        private const string DEFAULT_HEADER_LABEL = "Default header label";
        private const string DEFAULT_TITLE_LABEL = "Default title";

        public CoverPage CoverPage { get; set; }
        public TitlePage TitlePage { get; set; }
        public ContentTable ContentTable { get; set; }

        private HeaderStructure() { }

        public bool IsValid => CoverPage.IsValid && TitlePage.IsValid && ContentTable.IsValid;

        public HeaderStructure Clone() => new HeaderStructure()
        {
            CoverPage = CoverPage.Clone(),
            TitlePage = TitlePage.Clone(),
            ContentTable = ContentTable.Clone(),
        };

        public static HeaderStructure BuildDefault() => new HeaderStructure()
        {
            CoverPage = BuildDefaultCoverPage(),
            TitlePage = BuildDefaultTitlePage(),
            ContentTable = BuildDefaultContentTable(),
        };

        private static CoverPage BuildDefaultCoverPage() => new CoverPage(DEFAULT_AUTHOR_NAME, DEFAULT_COVER_TITLE);

        private static TitlePage BuildDefaultTitlePage() => new TitlePage(DEFAULT_HEADER_LABEL, DEFAULT_TITLE_LABEL);

        private static ContentTable BuildDefaultContentTable() => new ContentTable();

        public void Display()
        {
            CoverPage.Display();
            TitlePage.Display();
            ContentTable.Display();
        }
    }
}