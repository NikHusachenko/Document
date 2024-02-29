using Document.Desktop.Contracts;
using Document.Desktop.Management.FileManagement.Export;
using Document.Desktop.Management.FileManagement.Import;
using Document.Desktop.Response;
using Document.Desktop.Structures.Body;
using Document.Desktop.Structures.Footer;
using Document.Desktop.Structures.Header;

namespace Document.Desktop.Management
{
    public class Document : IValidable, IDisplayable
    {
        private const string DEFAULT_DOCUMENT_TITLE = "Document";

        private readonly DocumentSystemContext _context;

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

        private Document() : this(DEFAULT_DOCUMENT_TITLE) { }

        public Document(string title)
        {
            _context = new DocumentSystemContext(this);
            Metadata = new Metadata(_context);

            Header = HeaderStructure.BuildDefault(_context);
            Body = BodyStructure.BuildDefault(_context);
            Footer = FooterStructure.BuildDefault(_context);
        }

        public void Display()
        {
            DisplayMetadata();
            
            Header.Display();
            Body.Display();
            Footer.Display();
        }

        public void DisplayMetadata()
        {
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(Metadata.UniqueMetaUuid);
            Console.WriteLine(Metadata.Author);
            Console.WriteLine(Metadata.CreatedAt.ToString("dd.MM.yyyy HH:mm"));
            Console.WriteLine(Metadata.SavedAt);
            Console.WriteLine(Metadata.DocumentName);
            Console.WriteLine(Metadata.Extension);
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        public Document Clone() => new Document()
        {
            Body = Body.Clone(_context),
            Footer = Footer.Clone(_context),
            Header = Header.Clone(_context),
            Metadata = Metadata.Clone(_context),
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