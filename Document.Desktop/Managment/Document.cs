using Document.Desktop.Contracts;
using Document.Desktop.Structures.Body;
using Document.Desktop.Structures.Footer;
using Document.Desktop.Structures.Header;

namespace Document.Desktop.Structures
{
    public class Document : ICloneable<Document>, IValidable, IDisplayable
    {
        public Metadata Metadata { get; private init; }
        public HeaderStructure Header { get; private init; }
        public BodyStructure Body { get; private init; }
        public FooterStructure Footer { get; private init; }

        public bool IsValid
        {
            get
            {
                return Header.IsValid && 
                        Body.IsValid &&
                        Footer.IsValid;
            }
        }

        private Document() { }

        public Document(string title)
        {
            Metadata = new Metadata("Faraday");

            Header = HeaderStructure.BuildDefault();
            Body = BodyStructure.BuildDefault();
            Footer = FooterStructure.BuildDefault();
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public Document Clone() => new Document()
        {
            Body = Body.Clone(),
            Footer = Footer.Clone(),
            Header = Header.Clone(),
            Metadata = Metadata.Clone(),
        };
    }
}