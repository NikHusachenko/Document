using Document.Desktop.Contracts;

namespace Document.Desktop.Structures.Footer
{
    public sealed class ConclusionPage : ICloneable<ConclusionPage>, IValidable, IDisplayable
    {
        private const string DEFAULT_CONCLUSION_UNIT_NAME = "Conclusion";
        
        public string ConclusionUnitName { get; set; }
        public TextContent Content { get; set; }

        public ConclusionPage() : this(DEFAULT_CONCLUSION_UNIT_NAME) { }

        public ConclusionPage(string unitName)
        {
            ConclusionUnitName = unitName;
            Content = new TextContent(string.Empty);
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ConclusionUnitName))
                {
                    return false;
                }

                return Content.IsValid;
            }
        }

        public ConclusionPage Clone() => new ConclusionPage()
        {
            ConclusionUnitName = ConclusionUnitName,
            Content = Content.Clone(),
        };

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}