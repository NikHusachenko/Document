using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Footer
{
    public sealed class FooterStructure : ICloneable<FooterStructure>, IValidable, IDisplayable
    {
        public ConclusionPage ConclusionPage { get; private set; }
        public SourcePage SourcePage { get; private set; }

        public bool IsValid => throw new NotImplementedException();

        private FooterStructure() { }

        public static FooterStructure BuildDefault()
        {
            return new FooterStructure()
            {
                ConclusionPage = BuildDefaultConclusion(),
                SourcePage = BuildDefaultSourcePage(),
            };
        }

        private static ConclusionPage BuildDefaultConclusion() => new ConclusionPage();

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