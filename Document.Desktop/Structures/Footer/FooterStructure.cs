using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Footer
{
    public sealed class FooterStructure : ICloneable<FooterStructure>, IValidable, IDisplayable
    {
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

        public FooterStructure()
        {
            ConclusionPage = BuildDefaultConclusionPage();
            SourcePage = BuildDefaultSourcePage();
        }

        public static FooterStructure BuildDefault()
        {
            return new FooterStructure()
            {
                ConclusionPage = BuildDefaultConclusionPage(),
                SourcePage = BuildDefaultSourcePage(),
            };
        }

        private static ConclusionPage BuildDefaultConclusionPage() => new ConclusionPage();

        private static SourcePage BuildDefaultSourcePage() => new SourcePage();

        public FooterStructure Clone() => new FooterStructure()
        {
            ConclusionPage = ConclusionPage.Clone(),
            SourcePage = SourcePage.Clone(),
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}