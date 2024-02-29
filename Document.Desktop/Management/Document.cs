using Document.Desktop.Contracts;
using Document.Desktop.Management.FileManagement.Export;
using Document.Desktop.Management.FileManagement.Import;
using Document.Desktop.Response;
using Document.Desktop.Structures.Body;
using Document.Desktop.Structures.Footer;
using Document.Desktop.Structures.Header;

namespace Document.Desktop.Management
{
    public class Document : ICloneable<Document>, IValidable, IDisplayable
    {
        public Metadata Metadata { get; set; }
        public HeaderStructure Header { get; set; }
        public BodyStructure Body { get; set; }
        public FooterStructure Footer { get; set; }

        public bool IsValid
        {
            get
            {
                return Header.IsValid && 
                        Body.IsValid &&
                        Footer.IsValid;
            }
        }

        public Document() { }

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

    public class DocumentFileManager
    {
        private const string EXPORT_PROVIDER_DOESNT_ASSIGN = "Export provider doesn't assign";
        private const string IMPORT_PROVIDER_DOESNT_ASSIGN = "Import provider doesn't assign";
        
        private readonly Document _document;

        public ExportStrategy? ExportProvider { get; set; }
        public ImportStrategy? ImportProvider { get; set; }

        public DocumentFileManager(Document document)
        {
            _document = document;
        }

        public ResponseService<string> Export(string path)
        {   
            if (ExportProvider is null)
            {
                return ResponseService<string>.Error(EXPORT_PROVIDER_DOESNT_ASSIGN);
            }
            return ExportProvider!.Export(_document, path);
        }

        public ResponseService<Document> Import(string path)
        {
            if (ImportProvider is null)
            {
                return ResponseService<Document>.Error(IMPORT_PROVIDER_DOESNT_ASSIGN);
            }
            return ImportProvider!.Import(path);
        }
    }
}