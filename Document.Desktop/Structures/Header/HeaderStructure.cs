using Document.Desktop.Contracts;
using Document.Desktop.Management;

namespace Document.Desktop.Structures.Header
{
    public sealed class HeaderStructure : ICloneable<HeaderStructure>, IValidable, IDisplayable
    {
        private readonly DocumentSystemContext _systemContext;

        private const string DEFAULT_COVER_TITLE = "Default title here";
        private const string DEFAULT_AUTHOR_NAME = "Default author name here";
        private const string DEFAULT_HEADER_LABEL = "Default header label";
        private const string DEFAULT_TITLE_LABEL = "Default title";

        public CoverPage CoverPage { get; set; }
        public TitlePage TitlePage { get; set; }
        public ContentTable ContentTable { get; set; }

        public HeaderStructure(DocumentSystemContext systemContext)
        {
            _systemContext = systemContext;

            CoverPage = BuildDefaultCoverPage(systemContext);
            TitlePage = BuildDefaultTitlePage(systemContext);
            ContentTable = BuildDefaultContentTable(systemContext);
        }

        public bool IsValid => CoverPage.IsValid && TitlePage.IsValid && ContentTable.IsValid;

        public HeaderStructure Clone(DocumentSystemContext systemContext) => new HeaderStructure(systemContext)
        {
            CoverPage = CoverPage.Clone(systemContext),
            TitlePage = TitlePage.Clone(systemContext),
            ContentTable = ContentTable.Clone(systemContext),
        };

        public static HeaderStructure BuildDefault(DocumentSystemContext systemContext) => new HeaderStructure(systemContext)
        {
            CoverPage = BuildDefaultCoverPage(systemContext),
            TitlePage = BuildDefaultTitlePage(systemContext),
            ContentTable = BuildDefaultContentTable(systemContext),
        };

        private static CoverPage BuildDefaultCoverPage(DocumentSystemContext systemContext) 
            => new CoverPage(systemContext, DEFAULT_AUTHOR_NAME, DEFAULT_COVER_TITLE);

        private static TitlePage BuildDefaultTitlePage(DocumentSystemContext systemContext) 
            => new TitlePage(systemContext, DEFAULT_HEADER_LABEL, DEFAULT_TITLE_LABEL);

        private static ContentTable BuildDefaultContentTable(DocumentSystemContext systemContext) 
            => new ContentTable(systemContext);

        public void Display()
        {
            CoverPage.Display();
            TitlePage.Display();
            ContentTable.Display();
        }
    }
}