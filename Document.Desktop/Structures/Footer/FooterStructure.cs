using Document.Desktop.Contracts;
using Document.Desktop.Management;

namespace Document.Desktop.Structures.Footer
{
    public sealed class FooterStructure : ICloneable<FooterStructure>, IValidable, IDisplayable
    {
        private const string DEFAULT_CONCLUSION_UNIT_NAME = "Conclusion";

        private readonly DocumentSystemContext _systemContext;

        public ConclusionPage ConclusionPage { get; private set; }
        public SourcePage SourcePage { get; private set; }

        public bool IsValid
        {
            get
            {
                if (!ConclusionPage.IsValid)
                {
                    return false;
                }

                if (!SourcePage.IsValid)
                {
                    return false;
                }

                return true;
            }
        }

        public FooterStructure(DocumentSystemContext systemContext)
        {
            _systemContext = systemContext;

            ConclusionPage = BuildDefaultConclusionPage(systemContext);
            SourcePage = BuildDefaultSourcePage(systemContext);
        }

        public static FooterStructure BuildDefault(DocumentSystemContext systemContext) => new FooterStructure(systemContext)
        {
            ConclusionPage = BuildDefaultConclusionPage(systemContext),
            SourcePage = BuildDefaultSourcePage(systemContext),
        };

        private static ConclusionPage BuildDefaultConclusionPage(DocumentSystemContext systemContext) 
            => new ConclusionPage(systemContext, DEFAULT_CONCLUSION_UNIT_NAME);

        private static SourcePage BuildDefaultSourcePage(DocumentSystemContext systemContext) 
            => new SourcePage(systemContext);

        public FooterStructure Clone(DocumentSystemContext systemContext) => new FooterStructure(systemContext)
        {
            ConclusionPage = ConclusionPage.Clone(systemContext),
            SourcePage = SourcePage.Clone(systemContext),
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}