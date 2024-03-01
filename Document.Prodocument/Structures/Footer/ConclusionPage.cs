using Document.Prodocument.Contracts;
using Document.Prodocument.Management;
using Document.Prodocument.Structures.Components.Common;

namespace Document.Prodocument.Structures.Footer
{
    public sealed class ConclusionPage : ICloneable<ConclusionPage>, IValidable, IDisplayable
    {
        private const string DEFAULT_CONCLUSION_UNIT_NAME = "Conclusion";

        private readonly DocumentSystemContext _systemContext;

        public string ConclusionUnitName { get; set; }
        public TextContent Content { get; set; }

        private ConclusionPage(DocumentSystemContext systemContext) 
            : this(systemContext, DEFAULT_CONCLUSION_UNIT_NAME) { }

        public ConclusionPage(DocumentSystemContext systemContext, string unitName)
        {
            _systemContext = systemContext;
            ConclusionUnitName = unitName;
            Content = new TextContent(_systemContext, string.Empty);
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

        public ConclusionPage Clone(DocumentSystemContext systemContext) => new ConclusionPage(systemContext)
        {
            ConclusionUnitName = ConclusionUnitName,
            Content = Content.Clone(systemContext),
        };

        public void Display()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(nameof(ConclusionPage));

            Console.WriteLine(ConclusionUnitName);
            Content.Display();

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}